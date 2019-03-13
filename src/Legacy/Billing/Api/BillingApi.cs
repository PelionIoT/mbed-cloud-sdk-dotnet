// <copyright file="BillingApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Billing.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using billing.Api;
    using billing.Model;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Billing.Model;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Exceptions;
    using Newtonsoft.Json;
    using RestSharp;

    /// <summary>
    /// Billing
    /// </summary>
    /// <seealso cref="MbedCloudSDK.Common.Api" />
    public class BillingApi : Api
    {
        private readonly DefaultApi api;
        private readonly IMapper mapper;

        private readonly string baseUrl = "https://s3.eu-west-1.amazonaws.com";

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public BillingApi(Config config)
            : base(config)
        {
            var billingConfig = new billing.Client.Configuration
            {
                BasePath = config.Host,
                DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
                UserAgent = UserAgent,
            };
            billingConfig.AddApiKey("Authorization", config.ApiKey);
            billingConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            billingConfig.CreateApiClient();

            api = new billing.Api.DefaultApi(billingConfig);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ActiveServicePackage, ServicePackage>()
                    .ForMember(m => m.CreatedAt, o => o.MapFrom(src => src.Created))
                    .ForMember(m => m.ModifiedAt, o => o.MapFrom(src => src.Modified))
                    .ForMember(m => m.StartsAt, o => o.MapFrom(src => src.StartTime))
                    .ForMember(m => m.ExpiresAt, o => o.MapFrom(src => src.Expires))
                    .ReverseMap();
                cfg.CreateMap<PendingServicePackage, ServicePackage>()
                    .ForMember(m => m.CreatedAt, o => o.MapFrom(src => src.Created))
                    .ForMember(m => m.ModifiedAt, o => o.MapFrom(src => src.Modified))
                    .ForMember(m => m.StartsAt, o => o.MapFrom(src => src.StartTime))
                    .ForMember(m => m.ExpiresAt, o => o.MapFrom(src => src.Expires))
                    .ReverseMap();
                cfg.CreateMap<PreviousServicePackage, ServicePackage>()
                    .ForMember(m => m.CreatedAt, o => o.MapFrom(src => src.Created))
                    .ForMember(m => m.ModifiedAt, o => o.MapFrom(src => src.Modified))
                    .ForMember(m => m.StartsAt, o => o.MapFrom(src => src.StartTime))
                    .ForMember(m => m.ExpiresAt, o => o.MapFrom(src => src.Expires))
                    .ForMember(m => m.EndsAt, o => o.MapFrom(src => src.EndTime))
                    .ReverseMap();
                cfg.CreateMap<ServicePackageQuotaHistoryServicePackage, ServicePackage>()
                    .ForMember(m => m.ExpiresAt, o => o.MapFrom(src => src.Expires))
                    .ForMember(m => m.StartsAt, o => o.MapFrom(src => src.StartTime))
                    .ReverseMap();
                cfg.CreateMap<ServicePackageQuotaHistoryItem, QuotaHistory>()
                    .ForMember(m => m.CreatedAt, o => o.MapFrom(src => src.Added))
                    .ForMember(m => m.Delta, o => o.MapFrom(src => src.Amount))
                    .ForMember(m => m.AccountId, o => o.MapFrom(src => src.Reservation.AccountId))
                    .ForMember(m => m.CampaignName, o => o.MapFrom(src => src.Reservation.CampaignName))
                    .ForMember(m => m.ServicePackage, o => o.ResolveUsing((a, b, i, context) =>
                    {
                        return context.Mapper.Map<ServicePackageQuotaHistoryServicePackage, ServicePackage>(a.ServicePackage);
                    }))
                    .ReverseMap();
            });

            mapper = mapperConfig.CreateMapper();
        }

        /// <summary>
        /// Gets the report overview.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="filepath">The filepath.</param>
        /// <returns>bool</returns>
        /// <exception cref="CloudApiException">exception</exception>
        public bool GetReportOverview(DateTime month, string filepath)
        {
            try
            {
                var report = api.GetBillingReport(month.ToBillingMonth());
                var serializedReport = JsonConvert.SerializeObject(report);
                WriteFile(filepath, serializedReport);
                return true;
            }
            catch (billing.Client.ApiException e) when (e.ErrorCode == 404)
            {
                return false;
            }
            catch (billing.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
            catch (Exception)
            {
                throw;
            }

            void WriteFile(string path, string text)
            {
                if (!string.IsNullOrEmpty(path))
                {
                    System.IO.File.WriteAllText(path, text);
                }
            }
        }

        private void StreamFileFromUrl(string url, string filepath, BillingReportRawDataResponse report)
        {
            using (var writer = File.OpenWrite(filepath))
            {
                var client = new RestClient(baseUrl);
                var request = new RestRequest(report.Url.Replace(baseUrl, string.Empty))
                {
                    ResponseWriter = (responseStream) => responseStream.CopyTo(writer)
                };
                var response = client.Execute(request);
            }
        }

        /// <summary>
        /// Gets the report active devices.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="filepath">The filepath.</param>
        /// <returns>report filepath</returns>
        /// <exception cref="CloudApiException">exception</exception>
        public string GetReportActiveDevices(DateTime month, string filepath)
        {
            try
            {
                var report = api.GetBillingReportActiveDevices(month.ToBillingMonth());
                StreamFileFromUrl(report.Url, filepath, report);
                return report.DebugDump();
            }
            catch (billing.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the report firmware updates.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="filepath">The filepath.</param>
        /// <returns>filepath</returns>
        /// <exception cref="CloudApiException">exception</exception>
        public string GetReportFirmwareUpdates(DateTime month, string filepath)
        {
            try
            {
                var report = api.GetBillingReportFirmwareUpdates(month.ToBillingMonth());
                StreamFileFromUrl(report.Url, filepath, report);
                return report.DebugDump();
            }
            catch (billing.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the service packages.
        /// </summary>
        /// <returns>ServicePackages</returns>
        /// <exception cref="CloudApiException">exception</exception>
        public IEnumerable<ServicePackage> GetServicePackages()
        {
            try
            {
                var res = api.GetServicePackages();
                var list = new List<ServicePackage>();
                if (res.Pending != null)
                {
                    list.Add(mapper.Map<PendingServicePackage, ServicePackage>(res.Pending, new ServicePackage("pending")));
                }

                if (res.Active != null)
                {
                    list.Add(mapper.Map<ActiveServicePackage, ServicePackage>(res.Active, new ServicePackage("active")));
                }

                if (res.Previous != null)
                {
                    list.AddRange(res.Previous.Select(s => mapper.Map<PreviousServicePackage, ServicePackage>(s, new ServicePackage("previous"))));
                }

                return list;
            }
            catch (billing.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the quota history.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>PaginatedResponse</returns>
        /// <exception cref="CloudApiException">exception</exception>
        public PaginatedResponse<QueryOptions, QuotaHistory> GetQuotaHistory(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, QuotaHistory>(ListQuotaHistoryFunc, options);
            }
            catch (billing.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private async System.Threading.Tasks.Task<ResponsePage<QuotaHistory>> ListQuotaHistoryFunc(QueryOptions options)
        {
            try
            {
                var resp = await api.GetServicePackageQuotaHistoryAsync(limit: options.Limit, after: options.After);
                var responsePage = new ResponsePage<QuotaHistory>(after: resp.After, hasMore: resp.HasMore, totalCount: resp.TotalCount);
                responsePage.MapData<ServicePackageQuotaHistoryItem>(resp.Data, mapper.Map<ServicePackageQuotaHistoryItem, QuotaHistory>);
                return responsePage;
            }
            catch (billing.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the quota remaining.
        /// </summary>
        /// <returns>RemainingQuota</returns>
        /// <exception cref="CloudApiException">exception</exception>
        public long GetQuotaRemaining()
        {
            try
            {
                var remaining = api.GetServicePackageQuota().Quota;
                return remaining ?? 0;
            }
            catch (billing.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
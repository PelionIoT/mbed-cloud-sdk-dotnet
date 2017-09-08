using System.Collections.Generic;
using mbedCloudSDK.Connect.Model.Subscription;

namespace mbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Update pre-subscription data. Pre-subscription data will be removed for empty list.
        /// </summary>
        /// <param name="presubscriptions">Id of device.</param>
        public void UpdatePresubscriptions(mds.Model.Presubscription[] presubscriptions)
        {
            var presubscriptionArray = new mds.Model.PresubscriptionArray();
            foreach (var presubscription in presubscriptions)
            {
                var updatedPresubscription = new mds.Model.Presubscription(presubscription.EndpointName, presubscription.EndpointType, presubscription.ResourcePath);
                presubscriptionArray.Add(updatedPresubscription);
            }
            try
            {
                subscriptionsApi.V2SubscriptionsPut(presubscriptionArray);
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Get a list of pre-subscription data.
        /// </summary>
        public List<Presubscription> ListPresubscriptions()
        {
            try
            {
                var response = subscriptionsApi.V2SubscriptionsGet();
                var mappedResponse = new List<Presubscription>();
                foreach (var presubscription in response)
                {
                    mappedResponse.Add(Connect.Model.Subscription.Presubscription.Map(presubscription));
                }
                return mappedResponse;
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Delete the presubscriptions
        /// </summary>
        public void DeletePresubscriptions()
        {
            try
            {
                subscriptionsApi.V2SubscriptionsPut(new mds.Model.PresubscriptionArray());
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using MbedCloud.SDK.Common;
using MbedCloudSDK.Exceptions;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    public class CrudTest<T> where T : BaseEntity, new()
    {
        private readonly string commonProperty;
        private Func<T, T> preListFunc;
        private readonly Func<T, T> preGetFunc;
        private List<int> expectedFails = new List<int>();

        public CrudTest(
            string commonProperty = "CreatedAt",
            Func<T, T> preListFunc = null,
            Func<T, T> preGetFunc = null,
            List<int> expectedFails = null
        )
        {
            this.commonProperty = commonProperty;
            this.preListFunc = preListFunc;
            this.preGetFunc = preGetFunc;
            if (expectedFails != null)
            {
                this.expectedFails = expectedFails;
            }
        }

        public async Task Test()
        {
            try
            {
                var entity = new T();

                if (preListFunc != null)
                {
                    entity = preListFunc.Invoke(entity);
                }

                var first = (entity.GetType().GetMethod("List").Invoke(entity, GetDefaultParamList(typeof(T), "List")) as PaginatedResponse<QueryOptions, T>).First();

                if (first == default(T))
                {
                    Console.WriteLine("no items retrieved");
                }

                Assert.IsInstanceOf(typeof(T), first);

                var gotEntity = new T();

                if (preGetFunc != null)
                {
                    gotEntity = preGetFunc.Invoke(gotEntity);
                }

                gotEntity.Id = first.Id;
                await (gotEntity.GetType().GetMethod("Get").Invoke(gotEntity, GetDefaultParamList(typeof(T), "Get")) as Task<T>);

                var gotProperty = gotEntity.GetType().GetProperty(this.commonProperty).GetValue(gotEntity, null);
                var firstProperty = first.GetType().GetProperty(this.commonProperty).GetValue(gotEntity, null);

                Assert.AreEqual(firstProperty, gotProperty);
            }
            catch(TargetInvocationException e) when (e.InnerException is CloudApiException)
            {
                if (expectedFails.Contains(((CloudApiException)e.InnerException).ErrorCode))
                {
                    return;
                }

                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private object[] GetDefaultParamList(Type type, string methodName)
        {
            var paramLength = type.GetMethod(methodName).GetParameters().Length;
            var defaultList = new List<object>();
            for (int i = 0; i < paramLength; i++)
            {
                defaultList.Add(Type.Missing);
            }

            return defaultList.ToArray();
        }
    }
}
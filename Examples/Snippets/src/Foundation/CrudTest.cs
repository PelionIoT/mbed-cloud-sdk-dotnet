using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using MbedCloud.SDK.Common;
using MbedCloudSDK.Exceptions;
using NUnit.Framework;
using MbedCloudSDK.Common.Extensions;

namespace Snippets.src.Foundation
{
    public class CrudTest<T> where T : BaseEntity, new()
    {
        private readonly string commonProperty;
        private readonly Func<T, T> preListFunc;
        private readonly Func<T, T> preGetFunc;
        private readonly Func<T, T> preCreateFunc;
        private readonly Func<T, T> preUpdateFunc;
        private readonly Func<T, T> preDeleteFunc;
        private readonly T objectInstance;
        private readonly Dictionary<string, object> propsToUpdate;
        private readonly bool list;
        private readonly bool get;
        private readonly bool create;
        private readonly bool update;
        private string idToGet;
        private T firstObj;
        private List<int> expectedFails = new List<int>();

        public CrudTest(
            bool list = true,
            bool get = true,
            bool create = false,
            bool update = false,
            string commonProperty = "CreatedAt",
            Func<T, T> preListFunc = null,
            Func<T, T> preGetFunc = null,
            Func<T, T> preCreateFunc = null,
            Func<T, T> preUpdateFunc = null,
            Func<T, T> preDeleteFunc = null,
            List<int> expectedFails = null,
            string idToGet = null,
            Dictionary<string, object> propsToUpdate = null,
            T firstObj = null,
            T objectInstance = null
        )
        {
            this.list = list;
            this.get = get;
            this.create = create;
            this.update = update;
            this.commonProperty = commonProperty;
            this.preListFunc = preListFunc;
            this.preGetFunc = preGetFunc;
            this.preCreateFunc = preCreateFunc;
            this.preUpdateFunc = preUpdateFunc;
            this.preDeleteFunc = preDeleteFunc;
            this.objectInstance = objectInstance;
            this.propsToUpdate = propsToUpdate;
            this.idToGet = idToGet;
            this.firstObj = firstObj;
            if (expectedFails != null)
            {
                this.expectedFails = expectedFails;
            }
        }

        public async Task Test()
        {
            try
            {
                if (list)
                {
                    // create new entity
                    var entity = new T();

                    if (preListFunc != null)
                    {
                        entity = preListFunc.Invoke(entity);
                    }

                    // call list method on entity and get the first entity
                    var first = (entity.GetType().GetMethod("List").Invoke(entity, GetDefaultParamList(typeof(T), "List")) as PaginatedResponse<QueryOptions, T>).First();

                    if (first == default(T))
                    {
                        Console.WriteLine("no items retrieved");
                        return;
                    }

                    Assert.IsInstanceOf(typeof(T), first);

                    idToGet = first.Id;
                    firstObj = first;
                }

                if (get)
                {

                    // get an entity using the ID of the first entity
                    var gotEntity = new T();

                    if (preGetFunc != null)
                    {
                        gotEntity = preGetFunc.Invoke(gotEntity);
                    }

                    gotEntity.Id = idToGet;
                    await (gotEntity.GetType().GetMethod("Get").Invoke(gotEntity, GetDefaultParamList(typeof(T), "Get")) as Task<T>);

                    var gotProperty = gotEntity.GetType().GetProperty(this.commonProperty).GetValue(gotEntity, null);
                    var firstProperty = firstObj.GetType().GetProperty(this.commonProperty).GetValue(gotEntity, null);

                    Assert.AreEqual(firstProperty, gotProperty);
                }

                if (create)
                {
                    await (objectInstance.GetType().GetMethod("Create").Invoke(objectInstance, GetDefaultParamList(typeof(T), "Create")) as Task<T>);

                    var createdAt = objectInstance.GetType().GetProperty("CreatedAt").GetValue(objectInstance, null);
                    Assert.IsNotNull(createdAt);
                }

                if (update)
                {
                    foreach (var item in propsToUpdate)
                    {
                        objectInstance.GetType().GetProperty(item.Key).SetValue(objectInstance, item.Value);
                    }

                    await (objectInstance.GetType().GetMethod("Update").Invoke(objectInstance, GetDefaultParamList(typeof(T), "Update")) as Task<T>);
                    Console.WriteLine(objectInstance.DebugDump());

                    foreach (var item in propsToUpdate)
                    {
                        var updatedProp = objectInstance.GetType().GetProperty(item.Key).GetValue(objectInstance, null);
                        Assert.IsNotNull(updatedProp);
                    }
                }

                if (create)
                {
                    await (objectInstance.GetType().GetMethod("Delete").Invoke(objectInstance, GetDefaultParamList(typeof(T), "Delete")) as Task<T>);
                }
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
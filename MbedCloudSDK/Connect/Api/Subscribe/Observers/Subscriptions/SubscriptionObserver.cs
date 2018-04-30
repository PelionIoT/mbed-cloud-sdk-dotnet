using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Subscription;
using Newtonsoft.Json;

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.Subscriptions
{
    /// <summary>
    /// <see cref="SubscriptionObserver"/>
    /// </summary>
    public class SubscriptionObserver : Observer<PresubscriptionReturnPlaceholder, string>
    {
        public delegate void PresubAddedRaiser();

        public event PresubAddedRaiser OnPresubAdded;

        public List<PresubscriptionPlaceholder> Presubscriptions { get; } = new List<PresubscriptionPlaceholder>();

        public new void Notify(NotificationData data)
        {
            if (!Presubscriptions.Any() || Presubscriptions.FirstOrDefault(p => p.Equals(data)) != null)
            {
                base.Notify(PresubscriptionReturnPlaceholder.Map(data));
            }
        }

        public SubscriptionObserver Where(PresubscriptionPlaceholder subscription)
        {
            Presubscriptions.Add(subscription);
            OnPresubAdded();
            return this;
        }

        public SubscriptionObserver Where(string DeviceId, params string[] ResourcePaths)
        {
            var sub = new PresubscriptionPlaceholder() { DeviceId = DeviceId, ResourcePaths = ResourcePaths.ToList() };
            Presubscriptions.Add(sub);
            OnPresubAdded();
            return this;
        }

        public SubscriptionObserver Where(Expression<Func<ResourceValueChangeFilter, bool>> predicate)
        {
            if (predicate.Body.NodeType == ExpressionType.OrElse)
            {
                // central or so split into left and right
                var body = predicate.Body as BinaryExpression;

                var left = body.Left;
                var leftSub = ConstructSubscription(left);
                var right = body.Right;
                var rightSub = ConstructSubscription(right);

                Presubscriptions.Add(leftSub);
                Presubscriptions.Add(rightSub);
                OnPresubAdded();
            }
            return this;
        }

        private PresubscriptionPlaceholder ConstructSubscription(Expression exp)
        {
            if (exp.NodeType == ExpressionType.AndAlso)
            {
                var subDict = new Dictionary<string, object>();

                var binExp = exp as BinaryExpression;
                ExtractProperty(binExp.Left, subDict);
                ExtractProperty(binExp.Right, subDict);

                var sub = JsonConvert.DeserializeObject<PresubscriptionPlaceholder>(JsonConvert.SerializeObject(subDict));
                return sub;
            }

            return default(PresubscriptionPlaceholder);
        }

        private void ExtractProperty(Expression exp, Dictionary<string, object> dict)
        {
            if (exp as BinaryExpression != null)
            {
                if (exp.NodeType == ExpressionType.Equal)
                {
                    var binExp = exp as BinaryExpression;
                    var prop = binExp.Left as MemberExpression;
                    var value = binExp.Right as ConstantExpression;

                    dict.Add(prop.Member.Name, value.Value);
                }
            }

            // types don't seem to match even though they should...
            if (exp as MethodCallExpression != null)
            {
                if (exp.NodeType == ExpressionType.Call)
                {
                    var callExp = exp as MethodCallExpression;
                    if (callExp.Method.Name == "Contains")
                    {
                        var propExp = callExp.Object as MemberExpression;
                        var value = (ConstantExpression)callExp.Arguments.FirstOrDefault();
                        dict.Add(propExp.Member.Name, new List<string> { (string)value.Value });
                    }
                }
            }
        }
    }
}
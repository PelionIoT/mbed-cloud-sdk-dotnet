using System.Threading.Tasks;
using MbedCloud.SDK.Entities;

namespace MbedCloud.SDK.Common
{
    public static class CustomFunctions
    {
        public static bool IsDeveloperCertificateGetter(TrustedCertificate self)
        {
            return self.DeviceExecutionMode.HasValue ? (self.DeviceExecutionMode != 0) : false;
        }

        public static void IsDeveloperCertificateSetter(TrustedCertificate self, bool? value)
        {
            self.DeviceExecutionMode = value.HasValue ? 1 : 0;
            self.IsDeveloperCertificate = value;
        }

        public static async Task<User> SubtenantAccountSwitchGet(User user)
        {
            var myAccount = await new MyAccount().Get();
            if (user.AccountId != null || user.Id == myAccount.Id)
            {
                return await user.GetOnSubtenant();
            }

            return await user.GetOnAggregator();
        }

        public static async Task<User> SubtenantAccountSwitchCreate(User user, string action)
        {
            var myAccount = await new MyAccount().Get();
            if (user.AccountId != null || user.Id == myAccount.Id)
            {
                return await user.CreateOnSubtenant(action);
            }

            return await user.CreateOnAggregator(action);
        }
    }
}
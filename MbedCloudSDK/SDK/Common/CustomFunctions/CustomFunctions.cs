using System.Threading.Tasks;
using MbedCloud.SDK.Entities;

namespace MbedCloud.SDK.Common
{
    public static class CustomFunctions
    {
        public static bool DeveloperCertificateGetter(TrustedCertificate self)
        {
            return true;
        }

        public static void DeveloperCertificateSetter(TrustedCertificate self, bool? value)
        {
        }

        public static async Task<User> SubtenantAccountSwitchGet(User user)
        {
            return user;
        }

        public static async Task<User> SubtenantAccountSwitchCreate(User user, string action)
        {
            return user;
        }
    }
}
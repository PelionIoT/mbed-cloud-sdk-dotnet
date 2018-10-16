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

        public static User SubtenantAccountSwitchGet(User user)
        {
            return user;
        }

        public static User SubtenantAccountSwitchCreate(User user, string action)
        {
            return user;
        }
    }
}
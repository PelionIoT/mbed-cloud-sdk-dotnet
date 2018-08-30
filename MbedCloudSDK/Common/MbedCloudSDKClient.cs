namespace MbedCloudSDK.Common
{
    public static class MbedCloudSDKClient
    {
        private static Config _config;

        public static Config Config
        {
            get
            {
                if (_config != null)
                {
                    return _config;
                }

                var sdkConfig = new Config();
                _config = sdkConfig;

                return sdkConfig;
            }
        }

        public static void Init(Config config)
        {
            _config = config;
        }

        public static void Reset()
        {
            _config = null;
        }
    }
}
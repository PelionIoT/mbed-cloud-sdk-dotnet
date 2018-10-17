using MbedCloud.SDK.Common;

namespace MbedCloud.SDK
{
    public partial class EntityFactory
    {
        public EntityFactory(Config config)
        {
            this.config = config;
        }

        private Config config;
    }
}
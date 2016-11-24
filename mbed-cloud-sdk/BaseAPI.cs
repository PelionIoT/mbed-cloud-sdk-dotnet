using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbed_cloud_sdk
{
    public class BaseAPI
    {
        protected Config config;
        public BaseAPI(Config config)
        {
            this.config = config;
        }
    }
}

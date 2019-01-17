// <copyright file="EntityFactory.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using Mbed.Cloud.Foundation.Common;
using Mbed.Cloud.Foundation.RestClient;

namespace Mbed.Cloud
{
    public partial class EntityFactory
    {
        public EntityFactory(Config config, Client client)
        {
            this.config = config;
            this.client = client;
        }

        private Config config;
        private Client client;
    }
}
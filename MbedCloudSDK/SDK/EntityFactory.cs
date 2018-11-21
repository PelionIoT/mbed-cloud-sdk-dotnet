// <copyright file="EntityFactory.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloud.SDK
{
    using MbedCloud.SDK.Common;
    
    public partial class EntityFactory
    {
        public EntityFactory(Config config)
        {
            this.config = config;
        }

        private Config config;
    }
}
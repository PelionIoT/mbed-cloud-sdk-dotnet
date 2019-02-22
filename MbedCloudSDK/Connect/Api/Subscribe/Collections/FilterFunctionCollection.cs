namespace MbedCloudSDK.Connect.Api.Subscribe.Collections
{
    using System;
    using System.Collections.Generic;

    public class FilterFunctionCollection<T> : List<Func<T, bool>>
    {
    }
}
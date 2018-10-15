using System.Collections.Generic;
using Manhasset.Core.src.Extensions;

namespace Manhasset.Generator.src.CustomContainers
{
    public class DeferedMethodCallContainer
    {
        public string Method { get; set; }

        public string field { get; set; }

        public Dictionary<string, string> Assignments { get; set; } = new Dictionary<string, string>();

        public void AddAsignment(string externalKey, string selfKey)
        {
            Assignments.SafeAdd<string, string>(externalKey, selfKey);
        }
    }
}
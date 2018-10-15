using System.Collections.Generic;
using Manhasset.Core.src.Containers;

namespace Manhasset.Generator.src.CustomContainers
{
    public class BaseMethodContainer : MethodContainer
    {
        public string EntityName { get; set; }
        public string HttpMethod { get; set; }
        public string Path { get; set; }
        public bool Paginated { get; set; }
        public List<MyParameterContainer> PathParams { get; set; }
        public List<MyParameterContainer> QueryParams { get; set; }
        public List<MyParameterContainer> BodyParams { get; set; }
        public List<MyParameterContainer> FileParams { get; set; }
        public bool DeferToForeignKey { get; set; }
        public DeferedMethodCallContainer DeferedMethodCall { get; set; }
        public bool CustomMethodCall { get; set; }
        public string CustomMethodName { get; set; }
        public bool privateMethod { get; set; }
    }
}
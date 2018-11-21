using Manhasset.Core.src.Containers;

namespace Manhasset.Generator.src.CustomContainers
{
    public class MyParameterContainer : ParameterContainer
    {
        public bool External { get; set; }
        public string FieldName { get; set; }
        public bool ReplaceBody { get; set; }
    }
}
using System;

namespace mbedCloudSDK.Common
{
    public static class Utils{
        public static object MapToUpdate(object origObj, object updateObj){
            var type = updateObj.GetType();
            var props = type.GetProperties();
            var newObj = Activator.CreateInstance(type);

            foreach(var prop in props){
                var targetProperty = type.GetProperty(prop.Name);
                if(targetProperty.GetSetMethod(true) == null){
                    continue;
                }else{
                    var val = prop.GetValue(updateObj,null);
                    if(val != null){
                        targetProperty.SetValue(newObj,val,null);
                    }else{
                        targetProperty.SetValue(newObj,prop.GetValue(origObj,null));
                    }
                }
            }
            return newObj;
        }
    }
}
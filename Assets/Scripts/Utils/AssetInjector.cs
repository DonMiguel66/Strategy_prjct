using System;
using System.Reflection;

namespace SimpleStrategy3D.Utils
{
    public static  class AssetInjector
    {
        private readonly static Type InjectAssetAttributeType = typeof(InjectAssetAttribute); 
        public static T Inject<T>(this AssetsContext context, T target)
        {
            var targetType = target.GetType();
            while (targetType != null)
            {
                var allFields = targetType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < allFields.Length; i++)
                {
                    var fieldInfo = allFields[i];
                    var injectAssetAttribute = fieldInfo.GetCustomAttribute(InjectAssetAttributeType) as InjectAssetAttribute;
                    if (injectAssetAttribute == null)
                    {
                        continue;
                    }

                    var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                    fieldInfo.SetValue(target, objectToInject);
                }

                targetType = targetType.BaseType;
            }
            return target;
        }
    }
}

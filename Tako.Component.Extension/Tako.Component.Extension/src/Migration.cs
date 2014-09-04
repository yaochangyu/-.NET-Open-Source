using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tako.Component.Extension
{
    public class Migration
    {
        private static Dictionary<string, List<PropertyInfo>> s_PropertyInfos = new Dictionary<string, List<PropertyInfo>>();

        public UTarget Migrate<TSource, UTarget>(TSource source, UTarget target)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (target == null)
                throw new ArgumentNullException("target");

            List<PropertyInfo> propertyInfos = null;

            var sourceType = typeof(TSource);
            Type[] sourceInterfaceTypes = sourceType.GetInterfaces();
            var typeName = sourceType.FullName;

            if (sourceInterfaceTypes.Length != 0)
            {
                propertyInfos = GetPropertyInfos(typeName, sourceInterfaceTypes);
                SetPropertyValue(source, target, propertyInfos);
                return target;
            }
            else if (sourceType.BaseType.FullName != "System.Object")
            {
                var baseType = sourceType.BaseType;
                var baseTypeName = baseType.Name;
                propertyInfos = GetPropertyInfos(baseTypeName, baseType);
                SetPropertyValue(source, target, propertyInfos);
                return target;
            }
            else
            {
                propertyInfos = GetPropertyInfos(typeName, sourceType);
                SetPropertyValue(source, target, propertyInfos);
            }
            return default(UTarget);
        }

        private List<PropertyInfo> GetPropertyInfos(string name, Type[] interfaceTypes)
        {
            var propertyInfos = new List<PropertyInfo>();
            if (!s_PropertyInfos.ContainsKey(name))
            {
                foreach (var interfaceType in interfaceTypes)
                {
                    foreach (var property in interfaceType.GetProperties())
                    {
                        propertyInfos.Add(property);
                    }
                }
                s_PropertyInfos.Add(name, propertyInfos);
            }
            else
            {
                propertyInfos = s_PropertyInfos[name];
            }
            return propertyInfos;
        }

        private List<PropertyInfo> GetPropertyInfos(string name, Type sourceType)
        {
            List<PropertyInfo> propertyInfos = null;
            if (!s_PropertyInfos.ContainsKey(name))
            {
                propertyInfos = sourceType.GetProperties().ToList();
                s_PropertyInfos.Add(name, propertyInfos);
            }
            else
            {
                propertyInfos = s_PropertyInfos[name];
            }
            return propertyInfos;
        }

        private void SetPropertyValue<T, U>(T source, U target, List<PropertyInfo> propertyInfos)
        {
            foreach (var property in propertyInfos)
            {
                //var name = property.Name;
                var data = property.GetValue(source, null);
                property.SetValue(target, data, null);
            }
        }
    }
}
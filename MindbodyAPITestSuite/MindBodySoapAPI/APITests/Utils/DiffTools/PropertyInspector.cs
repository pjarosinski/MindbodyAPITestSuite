using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace MindbodySoapAPI.APITests.Utils.DiffTools
{
    public abstract class PropertyInspector
    {
        public static void InvokeWithGenericTypes(Type objectType, object obj, string methodName, Type[] genericTypes, object[] parameters)
        {
            MethodInfo method = objectType.GetMethod(methodName)
                             .MakeGenericMethod(genericTypes);
            method.Invoke(obj, parameters);
        }

        //DataBinder.Eval(source, expression)
        public static object GetObjectProperty(object item, string property)
        {
            if (item == null)
                return null;

            int dotIdx = property.IndexOf('.');

            if (dotIdx > 0)
            {
                object obj = GetObjectProperty(item, property.Substring(0, dotIdx));

                return GetObjectProperty(obj, property.Substring(dotIdx + 1));
            }

            PropertyInfo propInfo = null;
            Type objectType = item.GetType();

            while (propInfo == null && objectType != null)
            {
                propInfo = objectType.GetProperty(property,
                          BindingFlags.Public
                        | BindingFlags.Instance
                        | BindingFlags.DeclaredOnly);

                objectType = objectType.BaseType;
            }

            if (propInfo != null)
                return propInfo.GetValue(item, null);

            FieldInfo fieldInfo = item.GetType().GetField(property,
                          BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfo != null)
                return fieldInfo.GetValue(item);

            return null;
        }

        public static object GetPropertyValue<T>(T item, string propertyName) 
        {
            PropertyInfo p = typeof(T).GetProperty(propertyName);
            return p.GetValue(item);
        }
        
        public static object GetPropertyValue(object item, string propertyName)
        {
            PropertyInfo p = item.GetType().GetProperty(propertyName);
            return p.GetValue(item);
        }

        public static PropertyInfo GetPropertyInfo(object obj, string propName)
        {
            Type objType = obj.GetType();
            return objType.GetProperty(propName);
        }

        public static T2[] ExtractArray<T, T2>(T item, T2 dummy, PropertyInfo p) 
        {
            var property = typeof(T).GetProperty(p.Name);
            var val = property.GetValue(item);
            if (val == null)
            {
                return new T2[1];
            }
            return (T2[]) val;
        }

        public static void SetProp<T>(PropertyInfo prop, object obj, T value)
        {
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
            }
        }

        public static void SetProperyWith(PropertyDescriptor propDescrip, object obj, string value)
        {
            if (propDescrip.Converter == null) return;
            if (propDescrip.Converter.ConvertFromInvariantString(value)!= null)
            {
                propDescrip.SetValue(obj, propDescrip.Converter.ConvertFromInvariantString(value));
            }
        }

        public static List<PropertyInfo> GetInnerPropertiesFromType(Type T)
        {
           return  T.GetProperties().ToList();
        } 

        public static bool IsPropertyNestedType(PropertyInfo property)
        {
            return property.PropertyType.IsClass && property.PropertyType != typeof(string);
        }

        public static bool IsPropertyNestedType(Type propertyType)
        {
            return propertyType.IsClass && propertyType != typeof(string);
        }

        public static List<PropertyInfo> GetPublicInnerNestedTypeProperties(Type T)
        {
            var allProps = T.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public).ToList();
            return allProps.Where(prop => prop.PropertyType.IsClass).ToList();
        }

        public static bool ArePropertyValuesSame<T>(T obj1, T obj2, string property) where T : class
        {
            var valueOne = GetPropertyValue(obj1, property).ToString();
            var valueTwo = GetPropertyValue(obj2, property).ToString();
            return valueOne.Equals(valueTwo);
        }

        public static bool ArePropertyValuesSame<T>(T propertyValue, T propertyValue2)
        {
            return EqualityComparer<T>.Default.Equals(propertyValue, propertyValue2);
        }

        public bool IsAnyObjectNull<T>(T obj1, T obj2) where T : class
        {
            return obj1 == null || obj2 == null;
        }

        public bool AreBothObjectsNull<T>(T obj1, T obj2) where T : class
        {
            return obj1 == null && obj2 == null;
        }
    }
}

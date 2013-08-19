using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using MindbodySoapAPI.APITests.Utils.Credentials;
using MindbodySoapAPI.APITests.Utils.DiffTools;
using MindbodySoapAPI.APITests.Utils.ParsingTools;

namespace MindbodySoapAPI.APITests.Utils
{
    public class RequestBuilder
    {
        private readonly List<PropertyInfo> _requestProperties;
        private readonly PropertyDescriptorCollection _allProppertyDescriptors;
        private readonly List<Argument> _arguments;
        private readonly Type _requestType;
        private readonly object _request;

        public RequestBuilder(object baseRequest, List<Argument> args)
        {
            _request = baseRequest;
            _requestType = _request.GetType();
            _arguments = args;
            _requestProperties = GetPropertyInfo(_requestType);
            _allProppertyDescriptors = GetCollectionOfPropDescriptions();
        }

        //Todo
        public object Build()
        {
            return SetArgumentValuesWithDescriptors();
        }

        public static T BuildRequestFromBase<T>(List<Argument> args, bool production, bool useStaffCreds = false) where T : new()
        {
            var baseRequest = GetBaseRequest<T>(production, useStaffCreds);
            return (T) new RequestBuilder(baseRequest ,args).Build();
        }

        private List<PropertyInfo> GetPropertyInfo(Type type)
        {
            return PropertyInspector.GetInnerPropertiesFromType(type);
        }
         
        private object SetArgValuesInRequest()
        {
            foreach (var argument in _arguments)
            {
                SetSpecificProperty(GetMatchingProperty(argument.SoapNodeName), _request, argument.Value);
            }
            return _request;
        }

        private object SetArgumentValuesWithDescriptors()
        {
            foreach (var argument in _arguments)
            {
                SetSpecificProperty(GetMatchingPropertyDescriptor(argument.SoapNodeName), _request, argument.Value);
            }
            return _request;
        }

        private PropertyInfo GetMatchingProperty(string propName)
        {
            return _requestProperties.First(property => property.Name.Equals(propName));
        }

        private static void SetSpecificProperty(PropertyInfo prop, object obj, string value)
        {
            PropertyInspector.SetProp(prop, obj, ConvertStringToObjWithType(value, prop.PropertyType));
        }

        private static void SetSpecificProperty(PropertyDescriptor propDesc , object obj, string value)
        {
            PropertyInspector.SetProperyWith(propDesc, obj, value);
        }
        
        private static object ConvertStringToObjWithType(string value, Type type)
        {
            return CustomConverter.Convert(value, type);
        }

        private  PropertyDescriptorCollection GetCollectionOfPropDescriptions()
        {
            return  TypeDescriptor.GetProperties(_requestType);
        }

        private PropertyDescriptor GetMatchingPropertyDescriptor(string propName)
        {
            return _allProppertyDescriptors[propName];
        }
        
        public static T GetBaseRequest<T>( bool production, bool useStaffCreds = false) where T : new()
        {
            var credentials = CredentialsPackage.GetDefault(production);
            dynamic baseRequest = new T();

            ReflectiveSet(baseRequest, "SourceCredentials", credentials.SourceCredentials.ConvertToServiceCreds<T>());
            ReflectiveSet(baseRequest, "UserCredentials", credentials.UserCredentials.ConvertToServiceCreds<T>());
            ReflectiveSet(baseRequest, "XMLDetail", CredentialsPackage.GetXmlDetailLevel<T>());
            if (useStaffCreds) { ReflectiveSet(baseRequest, "StaffCredentials", credentials.StaffCredential.ConvertToServiceCreds<T>()); }

            return (T) baseRequest;
        }

        private static void ReflectiveSet(object obj, string propName, object toSet)
        {
            var propertyInf = PropertyInspector.GetPropertyInfo(obj, propName);
            PropertyInspector.SetProp(propertyInf, obj, toSet);
        }

    }
}

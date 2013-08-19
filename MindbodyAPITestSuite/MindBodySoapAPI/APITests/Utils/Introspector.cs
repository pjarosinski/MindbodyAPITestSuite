using System;
using System.Collections.Generic;
using System.Reflection;
using MindbodySoapAPI.APITests.Utils.DiffTools;

namespace MindbodySoapAPI.APITests.Utils
{
    public class Introspector
    {
        private readonly object _searchee;
        private readonly bool _array;

        public Introspector(object obj)
        {
            _searchee = obj;
            _array = IsArray(_searchee);
        }

        private Type ObjectType
        {
            get { return _array ? _searchee.GetType().GetElementType() : _searchee.GetType(); }
        }

        public List<string> Keywords
        {
            get { return new List<string> {"ID", "Name", "Value"}; }
        }

        private Array Searchees { get { return _searchee as Array; } }

        public void SearchAndDump()
        {
            if (_searchee == null) return;
            if (_array) { Introspect(Searchees); }
            else { Introspect(_searchee); }
        }

        private void Introspect(Array searchees)
        {
            foreach (var currentobj in searchees)
            {
                Introspect(currentobj);
            }
            Console.WriteLine();
        }

        private void Introspect(object toPrint)
        {
            if (!PropertyInspector.IsPropertyNestedType(ObjectType))
            {
                string extra = _array ? "" : Environment.NewLine;
                Console.WriteLine("Value: " + toPrint + extra);
            }
            else
            {
                var allProperties = GetProperties();
                foreach (var propertyInfo in allProperties)
                {
                    TryPrint(propertyInfo, toPrint);
                }
            }
        }

        private static bool IsArray(object obj)
        {
            return obj != null && obj.GetType().IsArray;
        }

        private bool IsStandardKey(string propName)
        {
            return Keywords.Contains(propName);
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            return PropertyInspector.GetInnerPropertiesFromType(ObjectType);
        }

        private void TryPrint(PropertyInfo property, object toPrint)
        {
            if (IsStandardKey(property.Name))
            {
                Console.WriteLine(FormatPropertString(property, toPrint));
            }
            else if (ContainsTypeNameAndId(property.Name, property.PropertyType))
            {
                Console.WriteLine(FormatPropertString(property, toPrint));
            }
        }

        private static string FormatPropertString(PropertyInfo property, object currentObj)
        {
            return property.Name + ": " + PropertyInspector.GetPropertyValue(currentObj, property.Name);
        }

        private static bool ContainsTypeNameAndId(string propName, Type propType)
        {
            return propName.Contains("ID") && propName.Contains(propType.Name);
        }

    }

}

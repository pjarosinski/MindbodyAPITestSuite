using System;

namespace MindbodySoapAPI.APITests.Utils
{
    public class CustomConverter
    {
        private string _value;
        private Type _valueType;
        static readonly Guid GuidNullable = new Guid("(9a9177c7-cf5f-31ab-8495-96f58ac5df3a)");

        public CustomConverter(string value, Type type)
        {
            _value = value;
            _valueType = type;
        }

        public static object Convert(string value, Type type)
        {
            return new CustomConverter(value, type).Convert();
        }
        //Todo
        public object Convert()
        {
            
            return new object();
        }
        public bool IsNullableType(Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static bool IsNullable(Type type)
        {
            return type.GUID == GuidNullable;
        }

        public static object ConvertToNullableType(Type type, string value)
        {
            if (type == typeof(int)) { return ConvertToIntNullable(value); }
            if (type == typeof(long)) { return ConvertToLongNullable(value); }
            if (type == typeof(bool)) { return ConvertToBoolNullable(value); }
            return null;
        }

        public static int? ConvertToIntNullable(string value, int? defaultVal = null)
        {
            if (String.IsNullOrEmpty(value))
            {
                return defaultVal;
            }
            return int.Parse(value);
        }


        public static long? ConvertToLongNullable(string value, long? defaultVal = null)
        {
            if (String.IsNullOrEmpty(value))
            {
                return defaultVal;
            }
            return long.Parse(value);
        }

        public static bool? ConvertToBoolNullable(string value, bool? defaultVal = null)
        {
            if (String.IsNullOrEmpty(value))
            {
                return defaultVal;
            }
            return bool.Parse(value);
        }

        public static string[] ConvertToStringArray(string value, string[] defaultVal = null)
        {
            if (value == null)
            {
                return defaultVal;
            }
            return value.Split(',');
        }


    }
}

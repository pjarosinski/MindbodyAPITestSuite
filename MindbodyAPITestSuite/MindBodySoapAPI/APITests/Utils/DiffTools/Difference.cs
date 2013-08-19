using System;
using System.Reflection;

namespace MindbodySoapAPI.APITests.Utils.DiffTools
{
    public class Difference : IDifference
    {
        
        public Difference(string resultOne, string resultTwo, PropertyInfo property)
        {
            ResultOne = resultOne;
            ResultTwo = resultTwo;
            PropertyInfo = property;
            IsComplex = true;
        }

        public Difference(string resultOne, string resultTwo)
        {
            ResultOne = resultOne;
            ResultTwo = resultTwo;
            IsComplex = false;

        }

        public void Write()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return IsComplex ? BuildComplexString() : BuildSimpleString();
        }

        private string BuildComplexString()
        {
            var outputOne = "    result1: " + PropertyInfo.ReflectedType.Name + "." + PropertyInfo.Name + " : " + ResultOne;
            var outputTwo = "    result2: " + PropertyInfo.ReflectedType.Name + "." + PropertyInfo.Name + " : " + ResultTwo;
            var message = "    " + ResultOne + " is not the same as : " + ResultTwo;
            return outputOne + Environment.NewLine + outputTwo + Environment.NewLine + message;
        }

        private string BuildSimpleString()
        {
            var outputOne = "    result1: " + " : " + ResultOne;
            var outputTwo = "    result2: " + " : " + ResultTwo;
            var message = "    " + ResultOne + " is not the same as : " + ResultTwo;
            return outputOne + Environment.NewLine + outputTwo + Environment.NewLine + message;
        }

        private bool IsComplex { get; set; }
        private string ResultOne { get; set; }
        private string ResultTwo { get; set; }
        private PropertyInfo PropertyInfo { get; set; }
    }
}

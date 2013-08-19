using System;
using System.Collections.Generic;
using System.Reflection;

namespace MindbodySoapAPI.APITests.Utils.DiffTools
{
    public class DiffModule : PropertyInspector
    {
        private bool IsSilent { get; set; }
        private List<IDifference> AllDifferences = new List<IDifference>();
        private readonly Dictionary<string,string> _specialCaseProperties = new Dictionary<string, string>();

        public DiffModule(bool isSilent = true) { IsSilent = isSilent; }

        public bool DiffNonObjectsResults<T>(T result, T result2)
        {
            return DiffNonObjectsAndStrings(result, result2);
        }

        public bool DiffListResults<T>(List<T> results, List<T> results2 ) 
        {
            ClearDifferences();
            DiffEnumerables(results, results2);
            return DumpDifferencesIfAny();
        }
        
        public bool DiffListResults<T>(IEnumerable<T> results, IEnumerable<T> results2)
        {
            ClearDifferences();
            DiffEnumerables(results, results2);
            return DumpDifferencesIfAny();
        }
         

        public bool DiffObjectResults<T>(T result, T result2) where T : class 
        {
            ClearDifferences();
            DiffObjects(result, result2);
            return DumpDifferencesIfAny();
        }

        public void Silence()
        {
            IsSilent = true;
        }

        public void MakeLoud()
        {
            IsSilent = false;
        }
        
        public void AddSpecialCaseProperties(KeyValuePair<string, string> specialCase )
        {
            AddSpecialCase(specialCase);
        }

        public void AddListOfSpecialCaseProperties(List<KeyValuePair<string, string>> specialCases)
        {
            AddMultipleSpecialCases(specialCases);
        }

        private void DiffNonGenericEnumerable(IEnumerable<object> results, IEnumerable<object> results2) 
        {
            var objType = results.GetType().GetElementType();
            var isGenericTypePrimitive = objType.IsPrimitive;

            var resultsEnumerator = results.GetEnumerator();
            var results2TwoEnumerator = results2.GetEnumerator();

            while (resultsEnumerator.MoveNext() && results2TwoEnumerator.MoveNext())
            {
                var currentItemResults = resultsEnumerator.Current;
                var currentItemResults2 = results2TwoEnumerator.Current;

                if (isGenericTypePrimitive)
                    DiffNonObjectsAndStrings(currentItemResults, currentItemResults2);
                else
                    DiffObjects(currentItemResults, currentItemResults2);
            }

            if (!(resultsEnumerator.MoveNext() == false && results2TwoEnumerator.MoveNext() == false))
                LogOneNullObjectFailure(objType);
        }
        
        private void DiffEnumerables<T>(IEnumerable<T> results, IEnumerable<T> results2 )
        {
            var isGenericTypePrimitive = typeof(T).IsPrimitive;
            var resultsEnumerator = results.GetEnumerator();
            var results2TwoEnumerator = results2.GetEnumerator();

            while (resultsEnumerator.MoveNext() && results2TwoEnumerator.MoveNext())
            {
                var currentItemResults = resultsEnumerator.Current;
                var currentItemResults2 = results2TwoEnumerator.Current;

                if (isGenericTypePrimitive)
                    DiffNonObjectsAndStrings(currentItemResults, currentItemResults2);

                else
                    DiffObjects(currentItemResults, currentItemResults2);
            }

            if (!(resultsEnumerator.MoveNext() == false && results2TwoEnumerator.MoveNext() == false))
                LogOneNullObjectFailure(typeof(T));
        }

        // Returns true if objects values are the same
        private bool DiffNonObjectsAndStrings<T>(T result, T result2)
        {
            if (!ArePropertyValuesSame(result, result2))
            {
                LogFailedDiffNonObjects(result, result2);
                return false;
            }

            PrintNonObjectOutput(result, result2);
            return true;
        }

        // Returns true if objects values are the same
        private void DiffObjects<T>(T result, T result2)
        {
            var currType = typeof (T);
            DiffObjectsPreOutput(currType);

            if (currType == typeof (string))
                DiffNonObjectsAndStrings(result, result2);

            else
            {
                var listofProperties = GetInnerPropertiesFromType(currType);
                foreach (var property in listofProperties)
                {
                    if (!IsPropertyNestedType(property))
                    {
                        var propertyValue = GetPropertyValue(result, property.Name);
                        var propertyValue2 = GetPropertyValue(result2, property.Name);

                        if (IsPropertySpecialCase(property.Name))
                            EvaluateSpecialCases(propertyValue, propertyValue2, property);
                        else
                            EvaluatePropertyValues(propertyValue, propertyValue2, property);
                    }
                    else if (property.PropertyType.IsArray)
                    {
                        Type elemType = property.PropertyType.GetElementType();
                        var arrTypeDummy = elemType == typeof (string) ? " " : Activator.CreateInstance(elemType);
                        var resultNestObj = ExtractArray(result, arrTypeDummy, property);
                        var result2NestObj = ExtractArray(result2, arrTypeDummy, property);
                        DiffNonGenericEnumerable(resultNestObj, result2NestObj);
                    }
                    else
                    {
                        var resultNestObj = GetPropertyValue(result, property.Name);
                        var result2NestObj = GetPropertyValue(result2, property.Name);
                        DiffObjects(resultNestObj, result2NestObj);
                    }
                }
            }
        }

        private void EvaluateSpecialCases<T>(T valOne, T valTwo, PropertyInfo property)
        {
            if (!AreSpecialCaseValuesSame(valOne, valTwo, property.Name))
                LogFailedDiff(valOne, valTwo, property);
            else
                WritePropertyValues(valOne, valTwo, property);    
        }

        private bool AreSpecialCaseValuesSame<T>(T propertyVal, T propertyVal2, string propName)
        {
            string ingnoreAfter = _specialCaseProperties[propName];
            string valOne = GetCutString(propertyVal, ingnoreAfter);
            string valTwo = GetCutString(propertyVal2, ingnoreAfter);
            return ArePropertyValuesSame(valOne, valTwo);
        }

        private static string GetCutString<T>(T tosplit, string ignore)
        {
            return tosplit == null ? "" : tosplit.ToString().Split(Convert.ToChar(ignore))[0];
        }

        private bool IsPropertySpecialCase(string name)
        {
            return _specialCaseProperties.ContainsKey(name);
        }

        private void AddSpecialCase(KeyValuePair<string, string> specialCase)
        {
            _specialCaseProperties.Add(specialCase.Key, specialCase.Value);
        }

        private void AddMultipleSpecialCases(IEnumerable<KeyValuePair<string, string>> listOfCases)
        {
            foreach (var keyValuePair in listOfCases)
            {
                AddSpecialCase(keyValuePair);
            }
        }

        private void ClearDifferences()
        {
            AllDifferences.Clear();
        }

        private bool DumpDifferencesIfAny()
        {
            if (AllDifferences.Count > 0)
            {
                var count = 0;
                foreach (var difference in AllDifferences)
                {
                    count++;
                    Console.WriteLine(Environment.NewLine + "Difference " + count + ":" );
                    difference.Write();
                }
                return false;
            }
            return true;
        }

        private void EvaluatePropertyValues<T>(T valOne, T valTwo, PropertyInfo property )
        {
            if (!ArePropertyValuesSame(valOne, valTwo))
                LogFailedDiff(valOne, valTwo, property);
            else
                WritePropertyValues(valOne, valTwo, property);       
        }

        private void LogOneNullObjectFailure(Type type)
        {
            AllDifferences.Add(new EnumDifference(type));
        }

        private void LogFailedDiff<T>(T resultNestObj, T result2NestObj, PropertyInfo property)
        {
            AllDifferences.Add(new Difference(resultNestObj.ToString(), result2NestObj.ToString(), property));
        }

        private void LogFailedDiffNonObjects<T>(T valOne, T valTwo)
        {
            AllDifferences.Add(new Difference(valOne.ToString(), valTwo.ToString()));
        }

        /************************************* Methods for Ouptut ***********************************************/

        private void DiffObjectsPreOutput(Type type)
        {
            if (IsSilent) return;
            Console.WriteLine("Checking: " + type.Name + " && " + type.Name);
        }

        private void PrintNonObjectOutput<T>(T result, T result2)
        {
            if (IsSilent) return;
            Console.WriteLine("DiffingNonObjects: " + typeof(T).Name + " && " + typeof(T).Name);
            Console.WriteLine("   " + result + " || " + result2);
        }

        private void WritePropertyValues<T>(T resultNestObj, T result2NestObj, PropertyInfo property)
        {
            if (IsSilent) return;
            Console.Write("result1: " + property.Name + " : " + resultNestObj);
            Console.Write("  result2: " + property.Name + " : " + result2NestObj);
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InternalParallelReflectiveTestRunner.DataFactoryAttribute;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.Reflector.Implementations
{
    //To make reflector more dynamic make a type qualifier for class instantiation.

    public class Reflector : IReflector
    {
        private readonly string _path =
            @"\MindBodyAPITests.dll";

        private readonly Assembly _testAssembly;

        public Reflector(string path = @"C:\Users\chris.essley\Documents\GitHub\MindbodyAPITestSuite\MindbodyAPITestSuite\MindBodyAPITests\bin\Release\MindBodyAPITests.dll")
        {
            _path = path;
            _testAssembly = Assembly.LoadFrom(_path);
        }

        //if someone wanted to get all the types and choose which ones to instantiate
        public IEnumerable<Type> GetAllTypesInAssembly()
        {
            return _testAssembly.GetTypes();
        }

        public IEnumerable<MethodInfo> GetAllMethodsInObject(object instance)
        {
            return GetAllMethodInfosFromObject(instance);
        }

        public MethodInfo GetMethodInfo(string method, object instance)
        {
            return GetMethodInfoFromObject(instance, method);
        }

        public object PropertyCopy(object fromInstance, object toInstance)
        {
            toInstance = CopyProperties(fromInstance, toInstance);
            return CopyFields(fromInstance, toInstance);
        }

        public bool CheckForFactoryMethod(string method, object instance)
        {
            try
            {
                return instance.GetType().GetMethod(method).GetCustomAttributes(typeof (DataFactory)).Any();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataFactory GetDataFactoryMethod(string method, object instance)
        {
            MethodInfo methodInfo = instance.GetType().GetMethod(method);
            return (DataFactory)methodInfo.GetCustomAttribute(typeof(DataFactory));
        }

        public object InvokeDataFactoryMethod(object instance, MethodInfo method, object[] args)
        {
            return method.Invoke(instance, args);
        }

        //returns new instance of classname
        public object Instantiate(string className)
        {
            return InstantiateClass(className);
        }

        public object Instantiate(Type typeOfClass)
        {
            return InstantiateClass(typeOfClass);
        }

        public IEnumerable<object> InstantiateAllClassesInAssembly()
        {
            return GetAllTypesInAssembly().Select(InstantiateClass);
        } 

        //if you have the object and methodinfo already
        public IMethodResult InvokeMethod(object instance, MethodInfo method)
        {
            return new MethodResult { ClassName = instance.GetType().Name, MethodName = method.Name,
                Exception = RunMethod(instance, method) };
        }

        public IMethodResult InvokeMethod(object instance, MethodInfo method, object[] args)
        {
            return new MethodResult { ClassName = instance.GetType().Name, MethodName = method.Name,
                Exception = RunMethod(instance, method, args) };
        }

        //end public api
        private object CopyProperties(object fromInstance, object toInstance)
        {
            IEnumerable<PropertyInfo> propertyInfos = fromInstance.GetType().GetProperties();

            foreach (PropertyInfo prop in propertyInfos)
            {
                if (prop.GetValue(toInstance) == null)
                {
                    PropertyInfo info =
                        fromInstance.GetType().GetProperties().First(propName => propName.Name == prop.Name);
                    prop.SetValue(toInstance, info.GetValue(fromInstance));
                }
            }

            return toInstance;
        }

        private object CopyFields(object fromInstance, object toInstance)
        {
            IEnumerable<FieldInfo> fieldInfos = fromInstance.GetType().GetFields();

            foreach (FieldInfo field in fieldInfos)
            {
                if (field.GetValue(toInstance) == null)
                {
                    FieldInfo info =
                        fromInstance.GetType().GetFields().First(fieldName => fieldName.Name == field.Name);
                    field.SetValue(toInstance, info.GetValue(fromInstance));
                }
            }

            return toInstance;
        }

        private IEnumerable<MethodInfo> GetAllMethodInfosFromObject(object obj)
        {
            return obj.GetType().GetMethods();
        } 

        private MethodInfo GetMethodInfoFromObject(object obj, string method)
        {
            MethodInfo[] methods = obj.GetType().GetMethods();

            return methods.FirstOrDefault(info => info.Name.Contains(method));
        }

        private object InstantiateClass(Type typeOfClass)
        {
            return Activator.CreateInstance(typeOfClass);
        }

        private object InstantiateClass(string className)
        {
            string fullyQualifiedName = "";

            foreach (var types in _testAssembly.GetTypes().Where(types => types.FullName.Contains(className)))
            {
                fullyQualifiedName = types.FullName;
            }

            return _testAssembly.CreateInstance(fullyQualifiedName);
        }

        private Exception RunMethod(object instance, MethodInfo method, object[] args = null)
        {
            try
            {
                method.Invoke(instance, args);
            }
            catch (Exception exception)
            {
                return exception.InnerException;
            }

            return null;
        }
    }
}

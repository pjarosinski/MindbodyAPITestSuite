using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InternalParallelReflectiveTestRunner.DataFactoryAttribute;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
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
            return instance.GetType().GetMethod(method).GetCustomAttributes(typeof(DataFactory)).Any();
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

        public IEnumerable<object> Instantiate(IEnumerable<string> classNames)
        {
            return classNames.Select(InstantiateClass);
        } 

        public IEnumerable<object> InstantiateAllClassesInAssembly()
        {
            return GetAllTypesInAssembly().Where(type => type.Name.Contains("Tests")).Select(InstantiateClass);
        } 

        //if you only have the string names of the class and method
        public IMethodResult InvokeMethod(string className, string method)
        {
            object instance = InstantiateClass(className);
            return new MethodResult { ClassName = instance.GetType().Name, MethodName = method,
                Exception = RunMethod(instance, method) };
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

        public IEnumerable<IMethodResult> InvokeAllMethodsInObjects(IList<object> objects)
        {
            List<IMethodResult> results = new List<IMethodResult>();

            foreach (object obj in objects)
            {
                results.AddRange(RunAllMethodsInClass(obj).ToList());
            }

            return results;
        } 

        //if you only have the string name of the class and need to invoke all methods
        public IEnumerable<IMethodResult> InvokeAllMethodsInClass(string className)
        {
            object instantiatedClass = InstantiateClass(className);
            IEnumerable<IMethodResult> results = RunAllMethodsInClass(instantiatedClass);
            return results;
        }

        public IEnumerable<IEnumerable<IMethodResult>> InvokeAllMethodsInAssembly()
        {
            return RunAllMethodsInAssembly();
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

        private IEnumerable<IEnumerable<IMethodResult>> RunAllMethodsInAssembly()
        {
            IList<Type> types = _testAssembly.GetTypes().Where(type => type.Name.Contains("Tests")).ToList();
            IList<object> instantiatedClasses = types.Select(instance => InstantiateClass(instance.Name)).ToList();
            IEnumerable<IEnumerable<IMethodResult>> methodResults = instantiatedClasses.Select(RunAllMethodsInClass);
            return methodResults;
        }

        private IEnumerable<IMethodResult> RunAllMethodsInClass(object instance)
        {
            IEnumerable<string> methods = instance.GetType().GetMethods().Where(method => method.Name.Contains("Test")).Select(name => name.Name);
            return methods.Select(methodName => new MethodResult { ClassName = instance.GetType().Name, MethodName = methodName, 
                Exception = RunMethod(instance, methodName) }).Cast<IMethodResult>().ToList();
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

        private Exception RunMethod(object instance, string methodName, object[] args = null)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName);
            return RunMethod(instance, method, args);
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

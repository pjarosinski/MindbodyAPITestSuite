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

        public IEnumerable<MethodInfo> GetAllMethodsInObject(object instantiatedObject)
        {
            return GetAllMethodInfosFromObject(instantiatedObject);
        }

        public MethodInfo GetMethodInfo(string method, object instantiatedObject)
        {
            return GetMethodInfoFromObject(instantiatedObject, method);
        }

        public object PropertyCopy(object fromInstance, object toInstance)
        {
            foreach (PropertyInfo prop in toInstance.GetType().GetProperties())
            {
                if (prop.GetValue(toInstance) == null)
                {
                    prop.SetValue(toInstance, fromInstance.GetType().GetProperties().First(propName => propName.Name == prop.Name));
                }
            }

            return toInstance;
        }

        public bool CheckForFactoryMethod(string method, object instance)
        {
            throw new NotImplementedException();
        }

        public DataFactory GetDataFactoryMethod(string method, object instance)
        {
            throw new NotImplementedException();
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
        public IMethodResult InvokeMethod(IClassMethodInfo info)
        {
            object instantiatedClass = InstantiateClass(info.Class);
            return new MethodResult { ClassName = instantiatedClass.GetType().Name, MethodName = info.Method,
                Exception = RunMethod(instantiatedClass, info.Method) };
        }

        //if you have the object and methodinfo already
        public IMethodResult InvokeMethod(object instantiatedClass, MethodInfo method)
        {
            return new MethodResult { ClassName = instantiatedClass.GetType().Name, MethodName = method.Name,
                Exception = RunMethod(instantiatedClass, method) };
        }

        public IMethodResult InvokeMethod(object instantiatedClass, MethodInfo method, object[] args)
        {
            return new MethodResult { ClassName = instantiatedClass.GetType().Name, MethodName = method.Name,
                Exception = RunMethod(instantiatedClass, method, args) };
        }

        public IEnumerable<IMethodResult> InvokeAllMethodsInObjects(IList<object> objects)
        {
            List<IMethodResult> results = new List<IMethodResult>();

            foreach (object instantiatedObject in objects)
            {
                results.AddRange(RunAllMethodsInClass(instantiatedObject).ToList());
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

        private IEnumerable<IMethodResult> RunAllMethodsInClass(object instantiatedClass)
        {
            IEnumerable<string> methods = instantiatedClass.GetType().GetMethods().Where(method => method.Name.Contains("Test")).Select(name => name.Name);
            return methods.Select(methodName => new MethodResult { ClassName = instantiatedClass.GetType().Name, MethodName = methodName, 
                Exception = RunMethod(instantiatedClass, methodName) }).Cast<IMethodResult>().ToList();
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

        private Exception RunMethod(object instantiatedClass, string methodName, object[] args = null)
        {
            MethodInfo method = instantiatedClass.GetType().GetMethod(methodName);
            return RunMethod(instantiatedClass, method, args);
        }

        private Exception RunMethod(object instantiatedClass, MethodInfo method, object[] args = null)
        {
            try
            {
                method.Invoke(instantiatedClass, args);
            }
            catch (Exception exception)
            {
                return exception.InnerException;
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.Reflector.Implementations
{
    public class Reflector : IReflector
    {
        private const string Path =
            @"C:\Users\chris.essley\Documents\GitHub\MindbodyAPITestSuite\MindbodyAPITestSuite\MindBodyAPITests\bin\Release\MindBodyAPITests.dll";

        private readonly Assembly _testAssembly;

        public Reflector()
        {
            _testAssembly = Assembly.LoadFrom(Path);
        }

        //if someone wanted to get all the types and choose which ones to instantiate
        public IEnumerable<Type> GetAllTypesInAssembly()
        {
            return _testAssembly.GetTypes();
        }

        //returns new instance of classname
        public object Instantiate(string className)
        {
            return InstantiateClass(className);
        }

        //if you only have the string names of the class and method
        public IMethodResult InvokeMethod(IClassMethodInfo info)
        {
            object instantiatedTestClass = InstantiateClass(info.Class);
            return new MethodResult { Exception = RunMethod(instantiatedTestClass, info.Method) };
        }

        //if you have the object and methodinfo already
        public IMethodResult InvokeMethod(object instantiatedClass, MethodInfo method)
        {
            return new MethodResult { Exception = RunMethod(instantiatedClass, method) };
        }

        //if you only have the string name of the class and need to invoke all methods
        public IEnumerable<IMethodResult> InvokeAllMethodsInClass(string className)
        {
            object instantiatedClass = InstantiateClass(className);
            IEnumerable<IMethodResult> results = RunAllMethodsInClass(instantiatedClass);
            return results;
        }

        //for running all tests in an assembly
        public IEnumerable<IEnumerable<IMethodResult>> InvokeAllMethodsInAssembly()
        {
            return RunAllMethodsInAssembly();
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
            return methods.Select(methodName => new MethodResult { Exception = RunMethod(instantiatedClass, methodName) }).Cast<IMethodResult>().ToList();
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

        private Exception RunMethod(object instantiatedClass, string methodName)
        {
            MethodInfo method = instantiatedClass.GetType().GetMethod(methodName);
            return RunMethod(instantiatedClass, method);
        }

        private Exception RunMethod(object instantiatedClass, MethodInfo method)
        {
            try
            {
                method.Invoke(instantiatedClass, null);
            }
            catch (Exception exception)
            {
                return exception;
            }

            return null;
        }
    }
}

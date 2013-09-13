using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.Reflector.Implementations
{
    //To make reflector more dynamic make a type qualifier for class instantiation.

    public class Reflector : IReflector
    {
        private readonly string _path =
            @"\MindBodyAPITests.dll";

        private readonly Assembly _testAssembly;

        public Reflector(string path = @"\MindBodyAPITests.dll")
        {
            _path = path;
            _testAssembly = Assembly.LoadFrom(_path);
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
            object instantiatedTestClass = InstantiateClass(info.Class);
            return new MethodResult { Exception = RunMethod(instantiatedTestClass, info.Method) };
        }

        //if you have the object and methodinfo already
        public IMethodResult InvokeMethod(object instantiatedClass, MethodInfo method)
        {
            return new MethodResult { Exception = RunMethod(instantiatedClass, method) };
        }

        public IMethodResult InvokeMethod(object instantiatedClass, MethodInfo method, object[] args)
        {
            return new MethodResult { Exception = RunMethod(instantiatedClass, method, args) };
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
                return exception;
            }

            return null;
        }

        //private RunTestSetup
        //private RuNTestTeardown
    }
}

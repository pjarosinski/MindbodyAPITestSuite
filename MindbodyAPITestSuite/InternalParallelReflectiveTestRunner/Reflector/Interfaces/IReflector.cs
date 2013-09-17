using System;
using System.Collections.Generic;
using System.Reflection;
using InternalParallelReflectiveTestRunner.DataFactoryAttribute;

namespace InternalParallelReflectiveTestRunner.Reflector.Interfaces
{
    public interface IReflector
    {
        bool CheckForFactoryMethod(string method, object instance);
        IEnumerable<Type> GetAllTypesInAssembly();
        IEnumerable<MethodInfo> GetAllMethodsInObject(object instance);
        DataFactory GetDataFactoryMethod(string method, object instance);
        MethodInfo GetMethodInfo(string method, object instance);
        object InvokeDataFactoryMethod(object instance, MethodInfo method, object[] args);
        IMethodResult InvokeMethod(object instance, MethodInfo method);
        IMethodResult InvokeMethod(object instance, MethodInfo method, object[] args);
        object Instantiate(string className); 
        object Instantiate(Type typeOfClass);
        IEnumerable<object> InstantiateAllClassesInAssembly();
        object PropertyCopy(object fromInstance, object toInstance);       
    }
}


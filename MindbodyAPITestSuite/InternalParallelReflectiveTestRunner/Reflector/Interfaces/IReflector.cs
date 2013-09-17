using System;
using System.Collections.Generic;
using System.Reflection;
using InternalParallelReflectiveTestRunner.DataFactoryAttribute;

namespace InternalParallelReflectiveTestRunner.Reflector.Interfaces
{
    public interface IReflector
    {
        IMethodResult InvokeMethod(IClassMethodInfo info);
        IMethodResult InvokeMethod(object instance, MethodInfo method);
        IMethodResult InvokeMethod(object instance, MethodInfo method, object[] args);
        IEnumerable<IMethodResult> InvokeAllMethodsInClass(string className);
        IEnumerable<IEnumerable<IMethodResult>> InvokeAllMethodsInAssembly();
        IEnumerable<IMethodResult> InvokeAllMethodsInObjects(IList<object> objects);
        object Instantiate(string className); 
        object Instantiate(Type typeOfClass);
        IEnumerable<object> Instantiate(IEnumerable<string> classNames);
        IEnumerable<object> InstantiateAllClassesInAssembly();
        IEnumerable<Type> GetAllTypesInAssembly();
        IEnumerable<MethodInfo> GetAllMethodsInObject(object instance);
        MethodInfo GetMethodInfo(string method, object instance);
        object PropertyCopy(object fromInstance, object toInstance);
        bool CheckForFactoryMethod(string method, object instance);
        DataFactory GetDataFactoryMethod(string method, object instance);
        object InvokeFactoryMethod(object instance, MethodInfo method, object[] args);
        //analyze if method has attribute attached for data factory
    }
}


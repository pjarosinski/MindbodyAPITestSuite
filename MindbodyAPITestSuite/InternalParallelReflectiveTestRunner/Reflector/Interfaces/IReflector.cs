using System;
using System.Collections.Generic;
using System.Reflection;

namespace InternalParallelReflectiveTestRunner.Reflector.Interfaces
{
    public interface IReflector
    {
        IMethodResult InvokeMethod(IClassMethodInfo info);
        IMethodResult InvokeMethod(object instantiatedClass, MethodInfo method);
        IMethodResult InvokeMethod(object instantiadetClass, MethodInfo method, object[] args);
        IEnumerable<IMethodResult> InvokeAllMethodsInClass(string className);
        IEnumerable<IEnumerable<IMethodResult>> InvokeAllMethodsInAssembly();
        IEnumerable<IMethodResult> InvokeAllMethodsInObjects(IList<object> objects);
        object Instantiate(string className);
        IEnumerable<object> Instantiate(IEnumerable<string> classNames);
        IEnumerable<object> InstantiateAllClassesInAssembly();
        IEnumerable<Type> GetAllTypesInAssembly();
        IEnumerable<MethodInfo> GetAllMethodsInObject(object instantiatedObject);
        MethodInfo GetMethodInfo(string method, object instantiatedObject);
    }
}


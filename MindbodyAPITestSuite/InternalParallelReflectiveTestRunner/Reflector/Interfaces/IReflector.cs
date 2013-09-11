using System;
using System.Collections.Generic;
using System.Reflection;

namespace InternalParallelReflectiveTestRunner.Reflector.Interfaces
{
    public interface IReflector
    {
        IMethodResult InvokeMethod(IClassMethodInfo info);
        IMethodResult InvokeMethod(object instantiatedClass, MethodInfo method);
        IEnumerable<IMethodResult> InvokeAllMethodsInClass(string className);
        IEnumerable<IEnumerable<IMethodResult>> InvokeAllMethodsInAssembly();
        object Instantiate(string className);
        IEnumerable<Type> GetAllTypesInAssembly();
    }
}


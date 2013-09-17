using System;

namespace InternalParallelReflectiveTestRunner.Reflector.Interfaces
{
    public interface IMethodResult
    {
        string ClassName { get; set; }
        Exception Exception { get; set; }
        string MethodName { get; set; }
    }
}

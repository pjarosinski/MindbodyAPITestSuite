using System;

namespace InternalParallelReflectiveTestRunner.Reflector.Interfaces
{
    public interface IMethodResult
    {
        string MethodName { get; set; }
        string ClassName { get; set; }
        Exception Exception { get; set; }
    }
}

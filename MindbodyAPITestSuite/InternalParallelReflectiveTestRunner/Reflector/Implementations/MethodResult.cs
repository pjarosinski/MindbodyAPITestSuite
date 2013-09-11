using System;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.Reflector.Implementations
{
    public class MethodResult : IMethodResult
    {
        public Exception Exception { get; set; }
    }
}

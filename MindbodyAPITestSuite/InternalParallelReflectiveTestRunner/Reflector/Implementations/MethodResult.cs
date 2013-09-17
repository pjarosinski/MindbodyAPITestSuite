using System;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.Reflector.Implementations
{
    public class MethodResult : IMethodResult
    {
        public string ClassName { get; set; }
        public Exception Exception { get; set; }
        public string MethodName { get; set; }
    }
}

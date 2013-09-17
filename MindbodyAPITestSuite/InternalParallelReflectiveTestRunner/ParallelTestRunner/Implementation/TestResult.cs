using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestResult : ITestResult 
    {
        public IMethodResult MethodResult { get; set; }
        public string TestDuration { get; set; }
    }
}

using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestResult
    {
        IMethodResult MethodResult { get; set; }
        string TestDuration { get; set; }
    }
}

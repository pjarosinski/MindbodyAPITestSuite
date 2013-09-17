using System.Collections.Generic;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestEnvironment
    {
        IList<ITestResult> RunTestsInParallel();
        IList<ITestResult> RunTestInParallel(ITestInfo info);
    }
}

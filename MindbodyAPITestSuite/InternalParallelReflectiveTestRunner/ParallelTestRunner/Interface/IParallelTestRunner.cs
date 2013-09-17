using System.Collections.Generic;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface IParallelTestRunner
    {
        IList<ITestResult> RunTestParallel(IClassMethodInfo tests);
        IList<ITestResult> RunTestsInClassParallel(string className);
        IList<ITestResult> RunAllTestsInAssemblyParallel();
    }
}

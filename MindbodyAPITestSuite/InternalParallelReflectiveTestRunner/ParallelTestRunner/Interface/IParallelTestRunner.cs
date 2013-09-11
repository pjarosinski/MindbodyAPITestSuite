using System.Collections.Generic;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface IParallelTestRunner
    {
        IList<IMethodResult> RunTestsParallel(IEnumerable<IClassMethodInfo> tests);
        IList<IMethodResult> RunTestsInClassParallel(string className);
        IList<IMethodResult> RunAllTestsInAssemblyParallel();
    }
}

using System.Collections.Generic;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class ParallelTestRunner : IParallelTestRunner
    {
        //if you want to run a certain subset of tests parallelizable
        public IList<ITestResult> RunTestParallel(ITestInfo test)
        {
            return RunParallel(test);
        }

        //run all tests in class given the string name of the class in parallel
        public IList<ITestResult> RunTestsInClassParallel(string className)
        {
            return RunParallel(className);
        }

        //run all tests in an assembly parallel
        public IList<ITestResult> RunAllTestsInAssemblyParallel()
        {
            return RunParallel();
        }

        private IList<ITestResult> RunParallel(ITestInfo test)
        {
            ITestEnvironment environment = new TestEnvironment(test);
            IList<ITestResult> results = environment.RunTestsInParallel();
            return results;
        }

        private IList<ITestResult> RunParallel(string testClass)
        {
            ITestEnvironment environment = new TestEnvironment(testClass);
            IList<ITestResult> results = environment.RunTestsInParallel();
            return results;
        }

        private IList<ITestResult> RunParallel()
        {
            ITestEnvironment environment = new TestEnvironment();
            IList<ITestResult> results = environment.RunTestsInParallel();
            return results;
        }
    }
}

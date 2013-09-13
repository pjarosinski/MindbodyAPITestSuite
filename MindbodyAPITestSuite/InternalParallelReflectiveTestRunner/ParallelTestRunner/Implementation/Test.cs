using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class Test : ITest 
    {
        private IReflector Reflector { get; set; }
        private object InstantiatedTestFixture { get; set; }
        private MethodInfo TestMethod { get; set; }
        private Stopwatch StopWatch { get; set; }

        public Test(object testFixture, string testMethod)
        {
            Reflector = new Reflector.Implementations.Reflector();
            InstantiatedTestFixture = testFixture;
            TestMethod = Reflector.GetMethodInfo(testMethod, InstantiatedTestFixture);
            StopWatch = new Stopwatch();
        }

        public ITestResult Run()
        {
            ITestResult testResult = new TestResult();

            StopWatch.Start();

            testResult.MethodResult = Reflector.InvokeMethod(InstantiatedTestFixture, TestMethod);
            
            StopWatch.Stop();

            testResult.TestDuration = StopWatch.Elapsed.ToString();

            return testResult;
        }
    }
}

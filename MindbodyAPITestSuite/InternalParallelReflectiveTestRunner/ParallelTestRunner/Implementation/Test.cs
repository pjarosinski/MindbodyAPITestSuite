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
        private ITestFixture InstantiatedTestFixture { get; set; }
        private ITestFixture InstantiatedBaseTestFixture { get; set; }
        private MethodInfo TestMethod { get; set; }
        private Stopwatch StopWatch { get; set; }

        public object[] TestArguments { get; set; }

        public Test(ITestFixture baseFixture, ITestFixture testFixture, string testMethod)
        {
            Reflector = new Reflector.Implementations.Reflector();
            InstantiatedTestFixture = testFixture;
            InstantiatedBaseTestFixture = baseFixture;
            TestMethod = Reflector.GetMethodInfo(testMethod, InstantiatedTestFixture.Instance);
            StopWatch = new Stopwatch();
        }

        public ITestResult Run()
        {
            ITestResult testResult = new TestResult();

            InstantiatedTestFixture.TestSetup();

            //copy properties from one fixture into the other

            //do logic for data factory
            //if tests has attribute of type datafactory,
            //invoke method using stringname from attribute in base test fixture
            //if its an enum hopefully it behaves good parallized
            //then pass value to method to run
           // InstantiatedTestFixture.Instance = SetInstanceProperties(InstantiatedBaseTestFixture.Instance,
             //                                                        InstantiatedTestFixture.Instance);

            StopWatch.Start();

            testResult.MethodResult = Reflector.InvokeMethod(InstantiatedTestFixture.Instance, TestMethod);
            
            StopWatch.Stop();

            InstantiatedTestFixture.TestTeardown();

            testResult.TestDuration = StopWatch.Elapsed.ToString();

            return testResult;
        }

        private object SetInstanceProperties(object baseTestFixture, object testFixture)
        {
            return Reflector.PropertyCopy(baseTestFixture, testFixture);
        }
    }
}

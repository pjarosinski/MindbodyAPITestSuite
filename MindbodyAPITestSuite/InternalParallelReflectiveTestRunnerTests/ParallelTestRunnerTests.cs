using System;
using System.Collections.Generic;
using System.Diagnostics;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Implementations;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalParallelReflectiveTestRunnerTests
{
    [TestClass]
    public class ParallelTestRunnerTests
    {
        [TestMethod]
        public void RunTestsParallelTest()
        {
            IParallelTestRunner parallelRunner = new ParallelTestRunner();

            ITestInfo testInfo = new TestInfo{ Class = "UserTests", Method = "GetUserTest" };
       
            IList<ITestResult> results = parallelRunner.RunTestParallel(testInfo);

            foreach (ITestResult result in results)
            {
                if (result.MethodResult.Exception != null)
                    Console.WriteLine(result.MethodResult.Exception.StackTrace);

                Console.WriteLine(result.MethodResult.ClassName);
                Console.WriteLine(result.MethodResult.MethodName);
                Console.WriteLine(result.TestDuration);
            }
        }

        [TestMethod]
        public void RunTestsInClassParallelTest()
        {
            IParallelTestRunner parallelRunner = new ParallelTestRunner();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            

            IList<ITestResult> results = parallelRunner.RunTestsInClassParallel("UserTests");

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.Elapsed);

            foreach (ITestResult result in results)
            {
                if (result.MethodResult.Exception != null)
                    Console.WriteLine(result.MethodResult.Exception);

                Assert.IsTrue(result.MethodResult.Exception == null);
            }
        }

        [TestMethod]
        public void RunTestsInAssemblyParallelTest()
        {
            IParallelTestRunner parallelRunner = new ParallelTestRunner();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IList<ITestResult> results = parallelRunner.RunAllTestsInAssemblyParallel();

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.Elapsed);

            foreach (ITestResult result in results)
            {
                if (result.MethodResult.Exception != null)
                    Console.WriteLine(result.MethodResult.Exception);

                Assert.IsTrue(result.MethodResult.Exception == null);
            }
        }
    }
}



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

            IList<IClassMethodInfo> testInfo = new List<IClassMethodInfo>();

            testInfo.Add(new ClassMethodInfo { Class = "UserTests", Method = "GetUserTest" });
            testInfo.Add(new ClassMethodInfo { Class = "UserTests", Method = "GetUserTest" });
            testInfo.Add(new ClassMethodInfo { Class = "UserTests", Method = "GetUserTest" });

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IList<IMethodResult> results = parallelRunner.RunTestsParallel(testInfo);

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.Elapsed);

            foreach (IMethodResult result in results)
            {
                if (result.Exception != null)
                    Console.WriteLine(result.Exception);

                Assert.IsTrue(result.Exception == null);
            }
        }

        [TestMethod]
        public void RunTestsInClassParallelTest()
        {
            IParallelTestRunner parallelRunner = new ParallelTestRunner();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IList<IMethodResult> results = parallelRunner.RunTestsInClassParallel("UserTests");

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.Elapsed);

            foreach (IMethodResult result in results)
            {
                if (result.Exception != null)
                    Console.WriteLine(result.Exception);

                Assert.IsTrue(result.Exception == null);
            }
        }

        [TestMethod]
        public void RunTestsInAssemblyParallelTest()
        {
            IParallelTestRunner parallelRunner = new ParallelTestRunner();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IList<IMethodResult> results = parallelRunner.RunAllTestsInAssemblyParallel();

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.Elapsed);

            foreach (IMethodResult result in results)
            {
                if (result.Exception != null)
                    Console.WriteLine(result.Exception);

                Assert.IsTrue(result.Exception == null);
            }
        }
    }
}



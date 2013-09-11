using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.Reflector.Implementations;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalParallelReflectiveTestRunnerTests
{
    [TestClass]
    public class ReflectorTests
    {
        [TestMethod]
        public void InvokeMethodTest()
        {
            IReflector reflector = new Reflector();
            string className = "UserTests";
            string methodName = "GetUserTest";

            IClassMethodInfo classMethodInfo = new ClassMethodInfo {Class = className, Method = methodName};

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IMethodResult result = reflector.InvokeMethod(classMethodInfo);

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.Elapsed);

            if (result.Exception != null)
                Console.WriteLine(result.Exception);

            Assert.IsTrue(result.Exception == null);
        }

        [TestMethod]
        public void InvokeAllMethodsOfClassTest()
        {
            IReflector reflector = new Reflector();
            string className = "UserTests";

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IEnumerable<IMethodResult> results = reflector.InvokeAllMethodsInClass(className);

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
        public void InvokeAllMethodsInAssemblyTest()
        {
            IReflector reflector = new Reflector();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IEnumerable<IEnumerable<IMethodResult>> results = reflector.InvokeAllMethodsInAssembly();

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.Elapsed);

            foreach (IMethodResult result in results.SelectMany(resultBatch => resultBatch))
            {
                if (result.Exception != null)
                    Console.WriteLine(result.Exception);

                Assert.IsTrue(result.Exception == null);
            }
        }

        [TestMethod]
        public void InstantiateTest()
        {
            IReflector reflector = new Reflector();
            string className = "UserTests";

            object instantiatedObj = reflector.Instantiate(className);

            Assert.IsTrue(instantiatedObj != null);
        }

        [TestMethod]
        public void GetAllTypesInAssemblyTest()
        {
            IReflector reflector = new Reflector();
            IEnumerable<Type> types = reflector.GetAllTypesInAssembly();

            Assert.IsTrue(types.Count() > 7);
        }
    }
}


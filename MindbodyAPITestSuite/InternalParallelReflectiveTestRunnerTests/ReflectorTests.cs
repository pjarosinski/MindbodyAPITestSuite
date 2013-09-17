using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
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
            object instance = reflector.Instantiate(className);
            MethodInfo method = instance.GetType().GetMethod(methodName);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IMethodResult result = reflector.InvokeMethod(className, method);

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.Elapsed);

            if (result.Exception != null)
               Console.WriteLine(result.Exception);

            Assert.IsTrue(result.Exception == null);
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


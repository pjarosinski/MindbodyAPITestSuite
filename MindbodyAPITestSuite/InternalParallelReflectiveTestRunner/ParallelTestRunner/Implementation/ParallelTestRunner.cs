using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class ParallelTestRunner : IParallelTestRunner
    {
        //if you want to run a certain subset of tests parallelizable
        public IList<IMethodResult> RunTestsParallel(IList<IClassMethodInfo> tests)
        {
            return RunParallel(tests);
        }

        //run all tests in class given the string name of the class in parallel
        public IList<IMethodResult> RunTestsInClassParallel(string className)
        {
            return RunParallel(className);
        }


        //run all tests in an assembly parallel
        public IList<IMethodResult> RunAllTestsInAssemblyParallel()
        {
            return RunParallel();
        }

        private IList<IMethodResult> RunParallel(IList<IClassMethodInfo> tests)
        {
            // now abstracted in test environment
            //IList<IMethodResult> results = new List<IMethodResult>();

            //IReflector reflector = new Reflector.Implementations.Reflector();

            //fixture setup called once for parallel tests
            ITestEnvironment environment = new TestEnvironment(tests);

            IList<ITestResult> results = environment.RunTestsInParallel();

            //now abstracted in test environment
            //tests.AsParallel().Select(test => test).ForAll(test => results.Add(reflector.InvokeMethod(test)));

            //fixture teardown should be called once for parallel tests

            return results;
        }

        private IList<IMethodResult> RunParallel(string testClass)
        {
            ITestEnvironment environment = new TestEnvironment(testClass);

            IList<ITestResult> results = environment.RunTestsInParallel();

            return results


                ////

            IList<IMethodResult> results = new List<IMethodResult>();
            IReflector reflector = new Reflector.Implementations.Reflector();
            object instantiatedClass = reflector.Instantiate(testClass);

            //fixture setup called once for parallel tests

            Parallel.ForEach(instantiatedClass.GetType().GetMethods().Where(meth => meth.Name.Contains("Test")),
                             method => results.Add(reflector.InvokeMethod(instantiatedClass, method)));

            //fixture teardown should be called once for parallel tests

            return results;
        }

        private IList<IMethodResult> RunParallel()
        {
            ITestEnvironment environment = new TestEnvironment();

            IList<ITestResult> results = environment.RunTestsInParallel();

            return results;












            /////

            IList<IMethodResult> results = new List<IMethodResult>();
            IReflector reflector = new Reflector.Implementations.Reflector();

            IList<Type> types =
                reflector.GetAllTypesInAssembly().Where(type => type.Name.Contains("Tests")).ToList();

            //fixture setup called once for parallel tests

            Parallel.ForEach(types.Select(type => reflector.Instantiate(type.Name)), instantiatedClass =>
                Parallel.ForEach(instantiatedClass.GetType().GetMethods().Where(meth => meth.Name.Contains("Test")),
                    method => results.Add(reflector.InvokeMethod(instantiatedClass, method))));

            //fixture teardown should be called once for parallel tests

            return results;
        }
    }
}

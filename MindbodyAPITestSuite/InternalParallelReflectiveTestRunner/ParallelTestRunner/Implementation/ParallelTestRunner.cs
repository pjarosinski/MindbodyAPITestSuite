using System;
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
        public IList<IMethodResult> RunTestsParallel(IEnumerable<IClassMethodInfo> tests)
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

        private IList<IMethodResult> RunParallel(IEnumerable<IClassMethodInfo> tests)
        {
            IList<IMethodResult> results = new List<IMethodResult>();

            IReflector reflector = new Reflector.Implementations.Reflector();

            tests.AsParallel().Select(test => test).ForAll(test => results.Add(reflector.InvokeMethod(test)));

            return results;
        }

        private IList<IMethodResult> RunParallel(string testClass)
        {
            IList<IMethodResult> results = new List<IMethodResult>();
            IReflector reflector = new Reflector.Implementations.Reflector();
            object instantiatedClass = reflector.Instantiate(testClass);

            Parallel.ForEach(instantiatedClass.GetType().GetMethods().Where(meth => meth.Name.Contains("Test")),
                             method => results.Add(reflector.InvokeMethod(instantiatedClass, method)));

            return results;
        }

        private IList<IMethodResult> RunParallel()
        {
            IList<IMethodResult> results = new List<IMethodResult>();
            IReflector reflector = new Reflector.Implementations.Reflector();

            IList<Type> types =
                reflector.GetAllTypesInAssembly().Where(type => type.Name.Contains("Tests")).ToList();

            Parallel.ForEach(types.Select(type => reflector.Instantiate(type.Name)), instantiatedClass =>
                Parallel.ForEach(instantiatedClass.GetType().GetMethods().Where(meth => meth.Name.Contains("Test")),
                    method => results.Add(reflector.InvokeMethod(instantiatedClass, method))));

            return results;
        }
    }
}

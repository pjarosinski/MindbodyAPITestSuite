using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class Test : ITest 
    {
        private IReflector Reflector { get; set; }
        public object InstantiatedTestFixture { get; set; }

        public ITestResult Run()
        {
           
        }
    }
}

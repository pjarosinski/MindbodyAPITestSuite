using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestFixture : ITestFixture
    {
        public object Instance { get; set; }

        public void TestSetup()
        {
            throw new NotImplementedException();
        }

        public void TestTeardown()
        {
            throw new NotImplementedException();
        }

        public void FixtureSetup()
        {
            throw new NotImplementedException();
        }

        public void FixtureTeardown()
        {
            throw new NotImplementedException();
        }
    }
}

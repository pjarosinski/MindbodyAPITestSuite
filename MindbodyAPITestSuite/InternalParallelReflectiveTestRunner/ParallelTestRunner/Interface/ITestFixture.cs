using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixture
    {
        object Instance { get; set; }
        void TestSetup();
        void TestTeardown();
        void FixtureSetup();
        void FixtureTeardown();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixture
    {
        object Instance { get; }
        string Name { get; set; }
        void TestSetup();
        void TestTeardown();
        void FixtureSetup();
        void FixtureTeardown();
        bool CheckForDataFactory(string method);
        IEnumerable<object> RunDataFactoryForMethod(string testMethod);
    }
}

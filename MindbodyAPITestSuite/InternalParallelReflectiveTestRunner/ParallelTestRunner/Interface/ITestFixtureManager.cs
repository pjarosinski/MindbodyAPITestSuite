using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixtureManager
    {
        ITestFixture GetFixture(string fixtureName);
        void Setup();
        void Teardown();
        IEnumerable<string> GetAllTestsInFixture(string fixtureName);
    }
}

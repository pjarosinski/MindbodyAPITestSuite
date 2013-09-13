using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixtureManager
    {
        void CreateFixture(string fixture);
        void CreateFixtures(IList<string> fixtures);
        void CreateAllFixtures();
        void Setup(string fixtureName);
        void Teardown(string fixtureName);
    }
}

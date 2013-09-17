using System.Collections.Generic;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixtureManager
    {
        ITestFixture GetFixture(string fixtureName);
        IEnumerable<string> GetAllTestsInFixture(string fixtureName);
        ITestFixture GetBaseFixture();
        IList<ITestFixture> GetAllFixtures();
    }
}

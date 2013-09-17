using System.Collections.Generic;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixtureManager
    {
        ITestFixture GetFixture(string fixtureName);
        IList<ITestFixture> GetAllFixtures();
        ITestFixture GetBaseFixture();
        IEnumerable<string> GetAllTestsInFixture(string fixtureName); 
    }
}

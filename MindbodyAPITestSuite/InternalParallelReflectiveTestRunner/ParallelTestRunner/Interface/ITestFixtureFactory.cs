using System.Collections.Generic;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixtureFactory
    {
        ITestFixture Create(string name);
        IList<ITestFixture> Create(IList<string> fixtures);
        IList<ITestFixture> Create();
        ITestFixture CreateBaseFixture();
    }
}

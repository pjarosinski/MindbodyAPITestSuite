using System.Collections.Generic;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixture
    {
        object Instance { get; set; }
        string Name { get; set; }
        void TestSetup();
        void TestTeardown();
        void FixtureSetup();
        void FixtureTeardown();
        bool CheckForDataFactory(string method);
        IEnumerable<object> RunDataFactoryForMethod(string testMethod);
    }
}

using System.Collections.Generic;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixture
    {
        object Instance { get; set; }
        string Name { get; set; }
        bool CheckForDataFactory(string method);
        void FixtureSetup();
        void FixtureTeardown();
        void TestSetup();
        void TestTeardown();
        IEnumerable<object> RunDataFactoryForMethod(string testMethod);
    }
}

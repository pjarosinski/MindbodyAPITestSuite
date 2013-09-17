using System.Collections.Generic;
using System.Linq;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestEnvironment : ITestEnvironment 
    {
        private ITestFixtureManager TestFixtureManager { get; set; }
        private ITestInfo TestInfo { get; set; }
        private string FixtureName { get; set; }
        private IList<Test> PreparedTests { get; set; }

        public TestEnvironment(ITestInfo testInfo)
        {
            TestInfo = testInfo;
            TestFixtureManager = PrepareTestFixture(TestInfo.Class);
            PreparedTests = PrepareTest(TestInfo.Class, TestInfo.Method);
        }

        public TestEnvironment(string fixtureName)
        {
            FixtureName = fixtureName;
            TestFixtureManager = PrepareTestFixture(FixtureName);
            PreparedTests = PrepareTests(FixtureName);
        }

        public TestEnvironment()
        {
            TestFixtureManager = PrepareAllTestFixtures();
            PreparedTests = PrepareTests();
        }

        public IList<ITestResult> RunTestsInParallel()
        {
            return RunAllTestsInParallel();
        }

        public IList<ITestResult> RunTestInParallel(ITestInfo testInfo)
        {
            return RunAllTestsInParallel();
        }

        private IList<ITestResult> RunAllTestsInParallel()
        {
            IList<ITestResult> results = new List<ITestResult>();

            ITestFixture baseFixture = TestFixtureManager.GetBaseFixture();

            baseFixture.FixtureSetup();

            PreparedTests.AsParallel().ForAll(test => results.Add(test.Run()));

            baseFixture.FixtureTeardown();

            return results;
        } 

        private TestFixtureManager PrepareTestFixture(string fixture)
        {
            return new TestFixtureManager(fixture);
        }

        private TestFixtureManager PrepareAllTestFixtures()
        {
            return new TestFixtureManager();
        }

        private IList<Test> PrepareTests(string fixtureName)
        {
            List<Test> preparedTests = new List<Test>();
            IEnumerable<string> testNames = TestFixtureManager.GetAllTestsInFixture(fixtureName);

            foreach (string test in testNames)
            {
                preparedTests.AddRange(PrepareTest(fixtureName, test));
            }

            return preparedTests;
        } 

        private IList<Test> PrepareTest(string className, string method)
        {
            ITestFixture baseFixture = TestFixtureManager.GetBaseFixture();
            ITestFixture testFixture = TestFixtureManager.GetFixture(className);

            if (testFixture.CheckForDataFactory(method))
            {
                IEnumerable<object> testData = testFixture.RunDataFactoryForMethod(method);
                return testData.Select(argument => new Test(baseFixture, testFixture, method) {TestArguments = new[] {argument}}).ToList();
            }

            return new List<Test>{new Test(baseFixture, testFixture, method)};
        }

        private IList<Test> PrepareTests()
        {
            IList<ITestFixture> fixtures = TestFixtureManager.GetAllFixtures();
            ITestFixture baseFixture = TestFixtureManager.GetBaseFixture();

            return (from fixture in fixtures from testName in TestFixtureManager.GetAllTestsInFixture(fixture.Name) 
                    select new Test(baseFixture, fixture, testName)).ToList();
        } 
    }
}

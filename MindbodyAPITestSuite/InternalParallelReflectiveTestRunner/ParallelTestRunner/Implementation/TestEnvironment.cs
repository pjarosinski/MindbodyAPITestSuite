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
            PreparedTests = PrepareTest(testInfo);
        }

        public TestEnvironment(string fixtureName)
        {
            FixtureName = fixtureName;
            TestFixtureManager = PrepareTestFixture(FixtureName);
            PreparedTests = PrepareTests(fixtureName);
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

        private IList<ITestResult> RunFactoryTestInParallel()
        {
            return null;
        } 

        private TestFixtureManager PrepareTestFixtures(IList<string> fixtures)
        {
            return new TestFixtureManager(fixtures);
        } 

        private TestFixtureManager PrepareTestFixture(string fixture)
        {
            return new TestFixtureManager(fixture);
        }

        private TestFixtureManager PrepareAllTestFixtures()
        {
            return new TestFixtureManager();
        }

        private IList<Test> PrepareTests(IList<ITestInfo> testInfos)
        {
            ITestFixture baseFixture = TestFixtureManager.GetBaseFixture();

            

            IList<Test> tests = testInfos.Select(testInfo => new Test(baseFixture, 
                TestFixtureManager.GetFixture(testInfo.Class), testInfo.Method)).ToList();

            return tests;
        }

        private IList<Test> PrepareTest(ITestInfo testInfo)
        {
            ITestFixture baseFixture = TestFixtureManager.GetBaseFixture();
            ITestFixture testFixture = TestFixtureManager.GetFixture(testInfo.Class);

            if (testFixture.CheckForDataFactory(testInfo.Method))
            {
                IEnumerable<object> testData = testFixture.RunDataFactoryForMethod(testInfo.Method);
                return testData.Select(argument => new Test(baseFixture, testFixture, testInfo.Method) {TestArguments = new[] {argument}}).ToList();
            }

            return new List<Test>{new Test(baseFixture, testFixture, testInfo.Method)};
        }

        private IList<Test> PrepareTests(string fixtureName)
        {
            IEnumerable<string> testNames = TestFixtureManager.GetAllTestsInFixture(fixtureName);
            ITestFixture testFixture = TestFixtureManager.GetFixture(fixtureName);
            ITestFixture baseFixture = TestFixtureManager.GetBaseFixture();

            return testNames.Select(testName => new Test(baseFixture, testFixture, testName)).ToList();
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

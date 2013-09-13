using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Implementations;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestEnvironment : ITestEnvironment 
    {
        private ITestFixtureManager TestFixtureManager { get; set; }
        private IList<IClassMethodInfo> TestInfos { get; set; }
        private string FixtureName { get; set; }
        private IList<Test> PreparedTests { get; set; }

        public TestEnvironment(IList<IClassMethodInfo> testInfos)
        {
            TestInfos = testInfos;
            TestFixtureManager = PrepareTestFixtures(TestInfos.Select(info => info.Class).ToList());
            PreparedTests = PrepareTests(testInfos);
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
            IList<ITestResult> results = new List<ITestResult>();
            PreparedTests.AsParallel().ForAll(test => results.Add(test.Run()));
            return results;
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

        private IList<Test> PrepareTests(IList<IClassMethodInfo> testInfos)
        {
            List<string> fixtures = testInfos.Select(fixture => fixture.Class).ToList();
            fixtures.ForEach(TestFixtureManager.Setup);

            IList<Test> tests = testInfos.Select(testInfo => new Test(TestFixtureManager.GetFixture(testInfo.Class), testInfo.Method)).ToList();
            return tests;
        }

        private IList<Test> PrepareTests(string fixtureName)
        {
            TestFixtureManager.Setup();
            IEnumerable<string> testNames = TestFixtureManager.GetAllTestsInFixture(fixtureName);
            ITestFixture testFixture = TestFixtureManager.GetFixture(fixtureName);

            return testNames.Select(testName => new Test(testFixture.Instance, testName)).ToList();
        } 

        private IList<Test> PrepareTests()
        {
            TestFixtureManager.Setup();
        } 
    }
}

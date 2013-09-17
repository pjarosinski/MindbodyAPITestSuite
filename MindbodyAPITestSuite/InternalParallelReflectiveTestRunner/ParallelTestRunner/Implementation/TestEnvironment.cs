using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.DataFactoryAttribute;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Implementations;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestEnvironment : ITestEnvironment 
    {
        private ITestFixtureManager TestFixtureManager { get; set; }
        private IClassMethodInfo TestInfo { get; set; }
        private string FixtureName { get; set; }
        private IList<Test> PreparedTests { get; set; }

        public TestEnvironment(IClassMethodInfo testInfo)
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

        public IList<ITestResult> RunTestInParallel()
        {
            return null;
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

        private IList<Test> PrepareTests(IList<IClassMethodInfo> testInfos)
        {
            ITestFixture baseFixture = TestFixtureManager.GetBaseFixture();

            

            IList<Test> tests = testInfos.Select(testInfo => new Test(baseFixture, 
                TestFixtureManager.GetFixture(testInfo.Class), testInfo.Method)).ToList();
            return tests;
        }

        private IList<Test> PrepareTest(IClassMethodInfo testInfo)
        {
            ITestFixture baseFixture = TestFixtureManager.GetBaseFixture();
            ITestFixture testFixture = TestFixtureManager.GetFixture(testInfo.Class);

            if (testFixture.CheckForDataFactory(testInfo.Method))
            {
                IEnumerable<object> testData = testFixture.RunDataFactoryForMethod(testInfo.Method);
                return testData.Select(argument => new Test(baseFixture, testFixture, testInfo.Method) {TestArguments = new[] {argument}}).ToList();
            }
            else
            {
                return new List<Test>{new Test(baseFixture, testFixture, testInfo.Method)};    
            }
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

        //if test has annotation data factory, create data and pass to tests
        //public User getUsers() {
        //   yeild return Users }


        //DataFactory[("UserFactory")]
        //public void GetUser(User user)
        

    }
}

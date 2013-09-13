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
        private IList<ITest> Tests { get; set; }
        private IList<ITest> PreparedTests { get; set; }

        public TestEnvironment(IList<IClassMethodInfo> testInfos)
        {
            TestInfos = testInfos;
            PrepareTestFixtures(TestInfos.Select(info => info.Class).ToList());
        }

        public TestEnvironment(string fixtureName)
        {
            FixtureName = fixtureName;
            PrepareTestFixture(FixtureName);
        }

        public TestEnvironment()
        {
            PrepareAllTestFixtures();
        }

        public IList<ITestResult> RunTestsInParallel()
        {
            IList<ITestResult> results = new List<ITestResult>();
            PreparedTests.AsParallel().ForAll(test => results.Add(test.Run()));
            return results;
        }

        private void PrepareTestFixtures(IList<string> fixtures)
        {
            TestFixtureManager.CreateFixtures(fixtures);
        } 

        private void PrepareTestFixture(string fixture)
        {
            TestFixtureManager.CreateFixture(fixture);
        }

        private void PrepareAllTestFixtures()
        {
            TestFixtureManager.CreateAllFixtures();
        }

        private IList<ITest> PrepareTests(IEnumerable<IClassMethodInfo> testInfos)
        {
            IList<string> fixtures = testInfos.Select(fixture => fixture.Class).ToList();
            fixtures.Select(fixture => TestFixtureManager.Setup(fixture));
        }
    }
}

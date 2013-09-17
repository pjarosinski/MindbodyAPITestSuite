using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestFixtureManager : ITestFixtureManager
    {
        private ITestFixtureFactory Factory { get; set; }

        private IList<ITestFixture> Fixtures { get; set; }

        private ITestFixture BaseFixture { get; set; }

        public TestFixtureManager(string fixtureName)
        {
            Factory = new TestFixtureFactory();
            Fixtures = new List<ITestFixture>();
            Fixtures.Add(Factory.Create(fixtureName));
            BaseFixture = CreateBaseFixture();
        }

        public TestFixtureManager(IList<string> fixtures)
        {
            Factory = new TestFixtureFactory();
            Fixtures = Factory.Create(fixtures);
            BaseFixture = CreateBaseFixture();
        }

        public TestFixtureManager()
        {
            Factory = new TestFixtureFactory();
            Fixtures = Factory.Create();
            BaseFixture = CreateBaseFixture();
        }

        public ITestFixture GetFixture(string fixtureName)
        {
            return Fixtures.First(fixture => fixture.Name.Contains(fixtureName));
        }

        public IEnumerable<string> GetAllTestsInFixture(string fixtureName)
        {
            ITestFixture testFixture = Fixtures.First(fixture => fixture.Name.Contains(fixtureName));
            return testFixture.GetType().GetMethods().Select(method => method.Name);
        }

        public ITestFixture GetBaseFixture()
        {
            return BaseFixture;
        }

        public IList<ITestFixture> GetAllFixtures()
        {
            return Fixtures;
        }

        private ITestFixture CreateBaseFixture()
        {
            return Factory.CreateBaseFixture();
        }
    }
}

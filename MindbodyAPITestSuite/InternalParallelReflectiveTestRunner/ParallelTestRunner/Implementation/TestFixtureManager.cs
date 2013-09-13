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
        }

        public TestFixtureManager(IList<string> fixtures)
        {
            Factory = new TestFixtureFactory();
            Fixtures = Factory.Create(fixtures);
        }

        public TestFixtureManager()
        {
            Factory = new TestFixtureFactory();
            Fixtures = Factory.Create();
        }

        public ITestFixture GetFixture(string fixtureName)
        {
            return Fixtures.First(fixture => fixture.Instance.GetType().Name.Contains(fixtureName));
        }

        public void Setup()
        {
            throw new NotImplementedException();
        }

        public void Teardown()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllTestsInFixture(string fixtureName)
        {
            ITestFixture testFixture = Fixtures.First(fixture => fixture.Instance.GetType().Name.Contains(fixtureName));
            return testFixture.GetType().GetMethods().Select(method => method.Name);
        } 

        private ITestFixture CreateBaseFixture()
        {
            return null;
        }
    }
}

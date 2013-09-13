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

        public TestFixtureManager()
        {
            Factory = new TestFixtureFactory();
            Fixtures = new List<ITestFixture>();
        }

        public void CreateFixture(string fixture)
        {
            Fixtures.Add(Factory.Create(fixture));
        }

        public void CreateFixtures(IList<string> fixtures)
        {
            Fixtures= Factory.Create(fixtures);
        }

        public void CreateAllFixtures()
        {
            Fixtures = Factory.Create();
        }

        public void Setup(string fixtureName)
        {
            throw new NotImplementedException();
        }

        public void Teardown(string fixtureName)
        {
            throw new NotImplementedException();
        }

        private ITestFixture CreateBaseFixture()
        {
            return null;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestFixtureManager : ITestFixtureManager
    {
        private ITestFixtureFactory Factory { get; set; }
        private IList<ITestFixture> Fixtures { get; set; }
        private ITestFixture BaseFixture { get; set; }
        private IReflector Reflector { get; set; }

        public TestFixtureManager(string fixtureName)
        {
            Reflector = new Reflector.Implementations.Reflector();
            Factory = new TestFixtureFactory();
            Fixtures = new List<ITestFixture>();
            Fixtures.Add(Factory.Create(fixtureName));
            BaseFixture = CreateBaseFixture();
        }

        public TestFixtureManager(IList<string> fixtures)
        {
            Reflector = new Reflector.Implementations.Reflector();
            Factory = new TestFixtureFactory();
            Fixtures = Factory.Create(fixtures);
            BaseFixture = CreateBaseFixture();
        }

        public TestFixtureManager()
        {
            Reflector = new Reflector.Implementations.Reflector();
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
            return Reflector.GetAllMethodsInObject(testFixture.Instance).Where(method => method.Name.Contains("Test")).Select(method => method.Name);
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

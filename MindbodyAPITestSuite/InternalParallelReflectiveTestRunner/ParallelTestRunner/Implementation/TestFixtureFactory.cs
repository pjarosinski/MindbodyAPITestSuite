using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestFixtureFactory : ITestFixtureFactory 
    {
        private IReflector Reflector { get; set; }

        public TestFixtureFactory()
        {
            Reflector = new Reflector.Implementations.Reflector();
        }

        public ITestFixture Create(string name)
        {
            object instance = Reflector.Instantiate(name);
            ITestFixture newFixture = new TestFixture(instance);
            return newFixture;
        }

        public IList<ITestFixture> Create(IList<string> fixtures)
        {
            return fixtures.Select(fixture => new TestFixture(Reflector.Instantiate(fixture))).Cast<ITestFixture>().ToList();
        }

        public IList<ITestFixture> Create()
        {
            IList<object> objects = Reflector.InstantiateAllClassesInAssembly().ToList();
            IList<ITestFixture> fixtures = objects.Select(obj => new TestFixture(obj)).Cast<ITestFixture>().ToList();
            return fixtures;
        } 

        public ITestFixture CreateBaseFixture()
        {
            Type baseFixtureType = Reflector.GetAllTypesInAssembly().First(type => type.Name.Contains("BaseTestSuite"));
            return new TestFixture (Reflector.Instantiate(baseFixtureType));
        }
    }
}

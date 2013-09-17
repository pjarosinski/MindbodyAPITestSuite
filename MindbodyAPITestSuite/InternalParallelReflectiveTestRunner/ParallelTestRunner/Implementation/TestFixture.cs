using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.DataFactoryAttribute;
using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestFixture : ITestFixture
    {
        public object Instance { get; private set; }

        public string Name { get; set; }

        private IReflector Reflector { get; set; }

        public TestFixture(object instance)
        {
            Reflector = new Reflector.Implementations.Reflector();
            Instance = instance;
            Name = instance.GetType().Name;
        }

        public void TestSetup()
        {
            MethodInfo fixtureSetup = Reflector.GetAllMethodsInObject(Instance).First(method => method.Name.Contains("Teardown"));
            Reflector.InvokeMethod(Instance, fixtureSetup);
        }

        public void TestTeardown()
        {
            MethodInfo fixtureSetup = Reflector.GetAllMethodsInObject(Instance).First(method => method.Name.Contains("Setup"));
            Reflector.InvokeMethod(Instance, fixtureSetup);
        }

        public void FixtureSetup()
        {
            MethodInfo fixtureSetup = Reflector.GetAllMethodsInObject(Instance).First(method => method.Name.Contains("FixtureSetup"));
            Reflector.InvokeMethod(Instance, fixtureSetup);
        }

        public void FixtureTeardown()
        {
            MethodInfo fixtureTeardown = Reflector.GetAllMethodsInObject(Instance).First(method => method.Name.Contains("FixtureTeardown"));
            Reflector.InvokeMethod(Instance, fixtureTeardown);
        }

        public bool CheckForDataFactory(string method)
        {
            return Reflector.CheckForFactoryMethod(method, Instance);
        }

        public IEnumerable<object> RunDataFactoryForMethod(string testMethod)
        {
            DataFactory attr = Reflector.GetDataFactoryMethod(testMethod, Instance);
            string factoryMethod = attr.MethodToRun;
            object[] factoryMethodArgs = attr.MethodArgs;
            return InvokeFactoryMethod(factoryMethod, factoryMethodArgs);
        }

        private IEnumerable<object> InvokeFactoryMethod(string factoryMethod, object[] factoryMethodArgs)
        {
            MethodInfo factoryMethodInfo = Reflector.GetMethodInfo(factoryMethod, Instance);
            return (IEnumerable<object>) Reflector.InvokeDataFactoryMethod(Instance, factoryMethodInfo, factoryMethodArgs);
        } 
    }
}

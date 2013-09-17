using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITestFixtureFactory
    {
        ITestFixture Create(string name);
        IList<ITestFixture> Create(IList<string> fixtures);
        IList<ITestFixture> Create();
        ITestFixture CreateBaseFixture();
    }
}

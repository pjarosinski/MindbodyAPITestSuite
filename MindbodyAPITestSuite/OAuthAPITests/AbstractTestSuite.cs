using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;

namespace OAuthAPITests
{
    public class AbstractTestSuite
    {
        private readonly Stopwatch _runTime = new Stopwatch();

        [SetUp]
        public virtual void SetUp()
        {
            _runTime.Start();
        }

        [TearDown]
        public virtual void TearDown()
        {
            _runTime.Stop();
            Console.WriteLine("Runtime: " + _runTime.Elapsed);
            Console.WriteLine("Test");
        }
    }
}

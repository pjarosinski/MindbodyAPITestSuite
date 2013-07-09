using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using MbUnitExperiments.RestObjects;

namespace MbUnitExperimentsTests
{
    [TestFixture, Parallelizable, ThreadedRepeat(1)]
    public abstract class AbstractRestCallTestSuite
    {
        public RestUser User = new RestUser { Username = "chris3.essley@mindbodyonline.com", Password = "owner1234", Firstname = "chris", Lastname = "essley" };

        public RestUserProfile UserProfile = new RestUserProfile { FirstName = "chris", LastName = "essley", Address = "123 fake st", City = "SLO", State = "CA", Zip = "93405" };

        public readonly int UserId = 230; 

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
            Console.WriteLine("Runtime: " +  _runTime.Elapsed);
        }
    }
}

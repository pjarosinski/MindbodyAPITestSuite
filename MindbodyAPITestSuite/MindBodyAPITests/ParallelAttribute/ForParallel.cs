using System;
using System.Threading;
using PostSharp.Aspects;

namespace MindBodyAPITests.ParallelAttribute
{
    [Serializable]
    public class ForParallel : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
            try
            {
                InvokeFixtureSetupIfExists(args.Instance);
                InvokeSetup(args.Instance);
            }
            catch (Exception)
            {
                InvokeTeardown(args.Instance);
                throw;
            }
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
            Thread.Sleep(1000);
            InvokeTeardown(args.Instance);
            InvokeFixtureTeardownIfExists(args.Instance);
        }

        private void InvokeFixtureSetupIfExists(object instance)
        {
            try
            {
                instance.GetType().GetMethod("FixtureSetUp").Invoke(instance, new object[] { });
            }
            catch (Exception)
            {
               
            }
        }

        private void InvokeFixtureTeardownIfExists(object instance)
        {
            try
            {
                instance.GetType().GetMethod("FixtureSetUp").Invoke(instance, new object[] { });
            }
            catch (Exception)
            {

            }
        }

        private void InvokeSetup(object instance)
        {
            instance.GetType().GetMethod("SetUp").Invoke(instance, new object[] { });
        }

        private void InvokeTeardown(object instance)
        {
            try
            {
                instance.GetType().GetMethod("TearDown").Invoke(instance, new object[] { });
            }
            catch (NullReferenceException) { }
        }
    }
}

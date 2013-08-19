using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace mb.Web.Tests.Automation.APITests.Models
{
   /* public class BatchRepository
    {
        private static readonly List<ApiTestBatch> Batches = new List<ApiTestBatch>();

        private static int _EnterCount = 0;

        public static void Enter()
        {
            _EnterCount++;
        }

        public static void Exit(ApiTestBatch batch)
        {
            var context = new ApiTestContext();
            lock (Batches)
            {
                Batches.Add(batch);
            }

            if (Batches.Count != _EnterCount)
            {
                return;
            }

            var resultBatch = new ApiTestBatch() {RunDateTime = batch.RunDateTime, TestRuns = new Collection<ApiTestRun>()};

            foreach(var apiBatch in Batches)
            {
                foreach(var run in apiBatch.TestRuns)
                {
                    //run.Batch = resultBatch;
                    resultBatch.TestRuns.Add(run);
                    context.TestRuns.Add(run);
                }
            }

            context.TestBatches.Add(resultBatch);
            context.SaveChanges();
        }
    }*/
}

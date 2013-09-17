using InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface;

namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Implementation
{
    public class TestInfo : ITestInfo
    {
        public string Class { get; set; }
        public string Method { get; set; }
    }
}

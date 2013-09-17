namespace InternalParallelReflectiveTestRunner.ParallelTestRunner.Interface
{
    public interface ITest
    {
        object[] TestArguments { get; set; }
        ITestResult Run();
    }
}

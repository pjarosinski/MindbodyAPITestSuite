using System;

namespace InternalParallelReflectiveTestRunner.DataFactoryAttribute
{
    public class DataFactory : Attribute
    {
        public string MethodToRun { get; set; }
        public object[] MethodArgs { get; set; }

        public DataFactory(string methodToRun, object[] methodArgs = null)
        {
            MethodToRun = methodToRun;
            MethodArgs = methodArgs;
        }
    }
}

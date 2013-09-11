using InternalParallelReflectiveTestRunner.Reflector.Interfaces;

namespace InternalParallelReflectiveTestRunner.Reflector.Implementations
{
    public class ClassMethodInfo : IClassMethodInfo
    {
        public string Class { get; set; }
        public string Method { get; set; }
    }
}

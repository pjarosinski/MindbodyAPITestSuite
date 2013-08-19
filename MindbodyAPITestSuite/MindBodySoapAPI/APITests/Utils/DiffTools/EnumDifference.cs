using System;

namespace MindbodySoapAPI.APITests.Utils.DiffTools
{
    public class EnumDifference : IDifference
    {
        public EnumDifference(Type type)
        {
            Type = type;
        }

        public void Write()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return "Only one " + Type.Name + " to compapre in the Collection";
        }
        private Type Type { get; set; }
    }
}

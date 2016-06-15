using System;

namespace MyPhotoshop
{
    public class EmptyParameters : IParameters
    {
        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[0];
        }

        public void Parse(double[] parameters)
        {
            
        }
    }
}
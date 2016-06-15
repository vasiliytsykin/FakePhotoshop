using System;

namespace MyPhotoshop
{
    public class GrayscaleParameters : IParameters
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
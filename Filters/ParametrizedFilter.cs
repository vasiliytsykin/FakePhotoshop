namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<TParam> : IFilter
        where TParam : IParameters, new ()
    {
        //private readonly TParam parameters = new TParam();       

        public ParameterInfo[] GetParameters()
        {
            return new TParam().GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = new TParam();
            parameters.Parse(values);
            return Process(original, parameters);
        }

        protected abstract Photo Process(Photo original, TParam parameters);
    }
}
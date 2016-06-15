using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class PixelFilter<TParam>: ParametrizedFilter<TParam>
        where TParam : IParameters, new()
    {
        private readonly string filterName;
        private readonly Func<Pixel, TParam, Pixel> ProcessPixel;

        public PixelFilter(string filterName, Func<Pixel, TParam, Pixel> processPixel)
        {
            this.filterName = filterName;
            ProcessPixel = processPixel;
        }

        protected override Photo Process(Photo original, TParam parameters)
        {
            var result = new Photo
                (
                original.Width,
                original.Height
                );

            for (var x = 0; x < result.Width; x++)
                for (var y = 0; y < result.Height; y++)
                {
                    result[x, y] = ProcessPixel(original[x, y], parameters);
                }

            return result;
        }

        public override string ToString()
        {
            return filterName;
        }
    }
}

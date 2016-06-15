using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class PixelFilter<TParam>: ParametrizedFilter<TParam>
        where TParam : IParameters, new()
    {       
        protected abstract Pixel ProcessPixel(Pixel original, TParam parameters);

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    class GrayscaleFilter: PixelFilter<GrayscaleParameters>
    {        

        protected sealed override Pixel ProcessPixel(Pixel original, GrayscaleParameters parameters)
        {
            var brightness = original.R*0.299 + original.G*0.587 + original.B*0.114;
            return new Pixel
            {
                R = brightness,
                G = brightness,
                B = brightness
            };        
        }

        public override string ToString()
        {
            return "черно/белый";
        }             
    }
}

using System;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double b;
        private double g;
        private double r;

        public double R
        {
            get { return r; }
            set { r = CheckValue(value); }
        }

        public double G
        {
            get { return g; }
            set { g = CheckValue(value); }
        }

        public double B
        {
            get { return b; }
            set { b = CheckValue(value); }
        }

        public static Pixel operator *(Pixel pixel, double val)
        {
            return new Pixel {R = Trim(pixel.R*val), G = Trim(pixel.G*val), B = Trim(pixel.B*val)};
        }

        public static Pixel operator *(double val, Pixel pixel)
        {
            return pixel*val;
        }

        private double CheckValue(double val)
        {
            if (val > 1) throw new ArgumentException("value should be from 0 to 1");
            return val;
        }

        private static double Trim(double val)
        {
            return val < 0 ? 0 : val > 1 ? 1 : val;
        }
    }
}
using System;

namespace MyPhotoshop
{
    public class Photo
    {
        public Photo(int width, int height)
        {
            Height = height;
            Width = width;
            data = new Pixel[width, height];
        }

        public int Width { get; }
        public int Height { get; }
        private readonly Pixel[,] data;

        public Pixel this[int x, int y]
        {
            get
            {
                if (IsInBounds(x, y)) return data[x, y];
                throw new ArgumentException();
            }
            set
            {
                if (IsInBounds(x, y)) data[x, y] = value;
            }
        }

        private bool IsInBounds(int x, int y)
        {
            return x >= 0 && x <= Width && y >= 0 && y <= Height;
        }      
    }
}
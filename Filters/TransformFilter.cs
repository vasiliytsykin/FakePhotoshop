using System;
using System.Drawing;

namespace MyPhotoshop
{
    public class TransformFilter<TParam> : ParametrizedFilter<TParam>
        where TParam : IParameters, new()
    {
        private readonly string filterName;
        private readonly Func<Point, Size, Point> pointTransform;
        private readonly Func<Size, Size> transformSize;

        public TransformFilter(string filterName, Func<Size, Size> transformSize,
            Func<Point, Size, Point> pointTransform)
        {
            this.filterName = filterName;
            this.transformSize = transformSize;
            this.pointTransform = pointTransform;
        }

        protected override Photo Process(Photo original, TParam parameters)
        {

            var newSize = transformSize(new Size(original.Width, original.Height));
            var result = new Photo(newSize.Width, newSize.Height);

            for (var x = 0; x < result.Width; x++)
                for (var y = 0; y < result.Height; y++)
                {
                    var newPoint = new Point(x,y);
                    var oldPoint = pointTransform(newPoint, newSize);           
                    result[x, y] = original[oldPoint.X, oldPoint.Y];
                }

            return result;
        }

        public override string ToString()
        {
            return filterName;
        }
    }
}
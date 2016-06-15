using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new PixelFilter<LighteningParameters>("Осветление/затемнение", (original, parametrs) => original*parametrs.Coefficient));
            window.AddFilter(new PixelFilter<EmptyParameters>("черно/белый", (o,p) => {
                var brightness = o.R * 0.299 + o.G * 0.587 + o.B * 0.114;
                return new Pixel
                {
                    R = brightness,
                    G = brightness,
                    B = brightness
                };
            }));
            window.AddFilter(new TransformFilter<EmptyParameters>("отражение", s => s,
                (newP, size) => new Point(newP.X, size.Height - newP.Y - 1)));
            window.AddFilter(new TransformFilter<EmptyParameters>("поворот на 90", s => new Size(s.Height, s.Width), 
                (newP, size) => new Point(newP.Y, size.Width - newP.X - 1)));
            Application.Run (window);
		}
	}
}

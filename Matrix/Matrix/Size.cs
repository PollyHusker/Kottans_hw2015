using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Size
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsSquare { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
            IsSquare = (Width == Height) ? true : false;

        }

        public static bool operator ==(Size a, Size b)
        {
            return ((a.Height == b.Height) && (a.Width == b.Width)) ? true : false;
        }

        public static bool operator !=(Size a, Size b)
        {
            return ((a.Height == b.Height) && (a.Width == b.Width)) ? false : true;

        }

        public override bool Equals(object obj)
        {
            return (this==(Size)obj);
        }
    }
}

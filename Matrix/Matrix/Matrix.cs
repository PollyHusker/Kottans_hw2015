using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class CoolMatrix
    {
        public Size Size { get; set; }
        private int[,] _array;

        public CoolMatrix(int[,] array)
        {
            Array.Copy(array, _array, array.Length);
        }
    }
}

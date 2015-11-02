using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class CoolMatrix : IEquatable<CoolMatrix>
    {
        public Size Size { get; set; }
        public bool IsSquare { get; }

        private int[,] _array;



        public CoolMatrix(int[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            Size = new Size(array.Rank, array.GetLength(0));
            _array = new int[Size.Height, Size.Width];
            Array.Copy(array, _array, array.Length);
            IsSquare = Size.IsSquare;

        }

        public static implicit operator CoolMatrix(int[,] array)
        {
            return new CoolMatrix(array);
        }

        public bool Equals(CoolMatrix other)
        {
            return this == other;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Size.Height - 1; i++)
            {
                sb.Append("[");
                for (int j = 0; j < Size.Width - 1; j++)
                {
                    sb.Append(_array[i, j]);
                    sb.Append(", ");

                }
                sb.Append(_array[i, Size.Width - 1]);
                sb.Append("]");
                sb.Append(Environment.NewLine);
            }

            //last row
            sb.Append("[");
            for (int j = 0; j < Size.Width - 1; j++)
            {
                sb.Append(_array[Size.Height - 1, j]);
                sb.Append(", ");

            }
            sb.Append(_array[Size.Height - 1, Size.Width - 1]);
            sb.Append("]");

            return sb.ToString();
        }


        public int this[int indexI, int indexJ]
        {
            get { return _array[indexI, indexJ]; /* return the specified index here */ }
            set { _array[indexI, indexJ] = value; /* set the specified index to value here */ }
        }

        public static bool operator ==(CoolMatrix a, CoolMatrix b)
        {
            if (ReferenceEquals(a, null)) return false;
            if (ReferenceEquals(b, null)) return false;
            if (ReferenceEquals(a, b)) return true;
            if (a.Size != b.Size) return false;
            for (int i = 0; i < a.Size.Height; i++)
                for (int j = 0; j < a.Size.Width; j++)
                    if (a[i, j] != b[i, j]) return false;
            return true;
        }


        public static bool operator !=(CoolMatrix a, CoolMatrix b)
        {
            return !(a == b);
        }

        public static CoolMatrix operator *(CoolMatrix a, int alpfa)
        {
            for(int i=0; i< a.Size.Height;i++)
                for (int j = 0; j < a.Size.Width; j++)
                    a[i, j] *= alpfa;
            return a;
        }

        public static CoolMatrix operator +(CoolMatrix a, CoolMatrix b)
        {
            if (a.Size != b.Size) throw new ArgumentException();    
            var c = new CoolMatrix(a._array);
            for (int i = 0; i < a.Size.Height; i++)
                for (int j = 0; j < a.Size.Width; j++)
                    c[i, j] += b[i, j];
            return c;
        }

        public CoolMatrix Transpose()
        {
            var temp = new int[Size.Width, Size.Height];
            for (int i=0; i< Size.Width; i++)
                for (int j = 0; j < Size.Height; j++)
                    temp[i, j] = this[j, i];
            return new CoolMatrix(temp); 

        }


    }
}

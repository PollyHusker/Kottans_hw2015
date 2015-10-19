using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Ceasar.Lib
{
    public class CeasarCipher
    {
        private int Offset;

        public CeasarCipher(int offset)
        {
            Offset = offset;
        }

        public string Encrypt(string data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (data.Equals(String.Empty))
                return string.Empty;
            CheckStringForNonSymbolic(data);

            var rez = new char[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == ' ')
                    rez[i] = ' ';
                else
                    rez[i] = (char) ((((((int) data[i] - 33) + Offset)%94) + 94)%94 + 33);
            }
            return new string(rez);
        }

        public string Decrypt(string data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (data.Equals(String.Empty))
                return string.Empty;
            CheckStringForNonSymbolic(data);

            var rez = new char[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == ' ')
                    rez[i] = ' ';
                else
                    rez[i] = (char) ((((((int) data[i] - 33) - Offset)%94) + 94)%94 + 33);
            }
            return new string(rez);
        }

        private void CheckStringForNonSymbolic(string data)
        {
            foreach (char ch in data)
            {
                if ((((int) ch >= 0) && ((int) ch <= 31)) || ((int) ch == 127))
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

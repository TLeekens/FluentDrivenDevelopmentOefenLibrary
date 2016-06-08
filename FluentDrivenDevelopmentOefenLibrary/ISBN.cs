using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentDrivenDevelopmentOefenLibrary
{
    public class ISBN
    {
        private long iSBNNummer;

        public ISBN(long nummer)
        {
            if (nummer <= 0)
                throw new ArgumentException();
            if (nummer.ToString().Length != 13)
                throw new ArgumentException();
            long even = 0, oneven = 0;
            for (int x = 0; x < nummer.ToString().Length - 1; ++x)
            {
                if (x % 2 == 0)
                    oneven += long.Parse(nummer.ToString()[x].ToString());
                else
                    even += long.Parse(nummer.ToString()[x].ToString());
            }
            long som = oneven + 3 * even;
            int controle = 0;
            for (int x = (int)som; (x) % 10 != 0; ++x)
            {
                controle = x - (int)som + 1;
            }
            if (controle != int.Parse(nummer.ToString()[12].ToString()))
            {
                throw new ArgumentException();
            }
            else
                iSBNNummer = nummer;
        }

        public override string ToString()
        {
            return iSBNNummer.ToString();
        }
    }
}

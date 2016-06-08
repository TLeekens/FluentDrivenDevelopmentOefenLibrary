using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentDrivenDevelopmentOefenLibrary
{
    public class Veiling
    {
        private decimal hoogsteBod;
        public decimal HoogsteBod
        {
            get
            {
                return hoogsteBod;
            }
        }

        public void DoeBod(decimal bedrag)
        {
            if (bedrag < 0)
            throw new ArgumentException();
            if (bedrag > hoogsteBod)
                hoogsteBod = bedrag;
        }
    }
}

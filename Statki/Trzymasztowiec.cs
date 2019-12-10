using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Trzymasztowiec : Statek
    {
        public Trzymasztowiec()
        {
            Czesc = new CzescStatku[3];
            Maszty = 3;
            Rodzaj = 't';
            for (int i = 0; i < Maszty; i++)
            {
                Czesc[i] = new CzescStatku(Rodzaj);
                Czesc[i].Statek = this;
            }
        }
    }
}

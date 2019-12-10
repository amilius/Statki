using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Czteromasztowiec : Statek
    {
        public Czteromasztowiec()
        {
            Czesc = new CzescStatku[4];
            Maszty = 4;
            Rodzaj = 'c';
            for (int i = 0; i < Maszty; i++)
            {
                Czesc[i] = new CzescStatku(Rodzaj);
                Czesc[i].Statek = this;
            }
        }
    }
}

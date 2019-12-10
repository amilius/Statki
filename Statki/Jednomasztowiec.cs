using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Jednomasztowiec : Statek
    {
        public Jednomasztowiec()
        {
            Czesc = new CzescStatku[1];
            Maszty = 1;
            Rodzaj = 'j';
            for (int i = 0; i < Maszty; i++)
            {
                Czesc[i] = new CzescStatku(Rodzaj);
                Czesc[i].Statek = this;
            }
        }
    }
}

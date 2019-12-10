using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Dwumasztowiec : Statek
    {
        public Dwumasztowiec()
        {
            Czesc = new CzescStatku[2];
            Maszty = 2;
            Rodzaj = 'd';
            for (int i = 0; i < Maszty; i++)
            {
                Czesc[i] = new CzescStatku(Rodzaj);
                Czesc[i].Statek = this;
            }
        }
    }
}

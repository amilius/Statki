using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class CzescStatku
    {
        public char Rodzaj { get; set; }
        public bool Trafiony { get; set; }

        public Pole Pole;
        public Statek Statek;

        public CzescStatku(char rodzaj)
        {
            Rodzaj = rodzaj;
            Trafiony = false;
        }
        public CzescStatku(int x, int y,char rodzaj, Plansza poleNaPlanszy)
        {
            Pole = poleNaPlanszy.Plan[x, y];
            Rodzaj = rodzaj;
            Trafiony = false;
        }

        public override string ToString()
        {
            return $"Czesc x={Pole.X}, y={Pole.Y}, Rodzaj Statku={Rodzaj}, Trafiony={Trafiony}";
        }



    }
}

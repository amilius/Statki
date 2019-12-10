using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Pole
    {

        public char Status { get; set; }
        public int X { get; }
        public int Y { get; }
        public Granica GranicaPola { get; }

        public CzescStatku Czesc;

        public Pole(int x, int y, Granica granicaPola = Granica.Brak, char status = '~')
        {
            X = x;
            Y = y;
            Status = status;
            GranicaPola = granicaPola;
        }

        public override string ToString()
        {
            return $"Pole status={Status}, X={X}, Y={Y}";
        }
    }
}

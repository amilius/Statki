using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Flota
    {
        public int UstawioneC = 0, UstawioneT = 0, UstawioneD = 0, UstawioneJ = 0;
        public Statek[] czteromasztowiec = new Czteromasztowiec[1];
        public Statek[] trzymasztowiec = new Trzymasztowiec[2];
        public Statek[] dwumasztowiec = new Dwumasztowiec[3];
        public Statek[] jednomasztowiec = new Jednomasztowiec[4];

        public int Trafienia => ObliczStatystyke()[0];
        public int Zatopienia => ObliczStatystyke()[1];

        public int[] ObliczStatystyke()
        {
            int t = 0, z = 0;
            foreach (var statek in czteromasztowiec)
            {
                t += statek.IleRazyTrafiony;
                if (statek.Zatopiony)
                    z++;
            }
            foreach (var statek in trzymasztowiec)
            {
                t += statek.IleRazyTrafiony;
                if (statek.Zatopiony)
                    z++;
            }
            foreach (var statek in dwumasztowiec)
            {
                t += statek.IleRazyTrafiony;
                if (statek.Zatopiony)
                    z++;
            }
            foreach (var statek in jednomasztowiec)
            {
                t += statek.IleRazyTrafiony;
                if (statek.Zatopiony)
                    z++;
            }
            int[] arr = { t, z};
            return arr;
        }
        public string Statystyka(string czyja)
        {
            return $"{czyja} trafiono: {ObliczStatystyke()[0]} zatopiono statków: {ObliczStatystyke()[1]}";
        }
    }


}

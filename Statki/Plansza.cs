using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Plansza
    {
        public Pole[,] Plan = new Pole[10, 10];

        public Plansza()
        {
            

            for(int j = 0; j < Plan.GetLength(1); j++)
            {
                for(int i = 0; i < Plan.GetLength(0); i++)
                {
                    if(i == 0 && j == 0)
                        Plan[i, j] = new Pole(i, j, Granica.GornyLewy);
                    if(i != 0 && i < Plan.GetLength(0)-1 && j == 0)
                        Plan[i, j] = new Pole(i, j, Granica.Gorny);
                    if(i == Plan.GetLength(0)-1 && j == 0)
                        Plan[i, j] = new Pole(i, j, Granica.GornyPrawy);
                    if (i == 0 && j != 0 && j < Plan.GetLength(1)-1)
                        Plan[i, j] = new Pole(i, j, Granica.Lewy);
                    if (i == 0 && j == Plan.GetLength(1)-1)
                        Plan[i, j] = new Pole(i, j, Granica.DolnyLewy);
                    if (i == Plan.GetLength(0)-1 && j < Plan.GetLength(1)-1 && j != 0)
                        Plan[i, j] = new Pole(i, j, Granica.Prawy);
                    if (i == Plan.GetLength(0)-1 && j == Plan.GetLength(1)-1)
                        Plan[i, j] = new Pole(i, j, Granica.DolnyPrawy);
                    if (i != 0 && i < Plan.GetLength(0)-1 && j == Plan.GetLength(1)-1)
                        Plan[i, j] = new Pole(i, j, Granica.Dolny);
                    if (i != 0 && i < Plan.GetLength(0)-1 && j < Plan.GetLength(1)-1 && j != 0)
                        Plan[i, j] = new Pole(i, j);
                }
            }
            //Console.Write("Plansza Stworzona");

        }

        public void Wyswietl() // z ramka
        {
            Console.WriteLine();
            Console.Write("//");
            for (int r = 0; r < Plan.GetLength(0); r++)
            {
                Console.Write($"/{r}");
            }
            Console.Write("//");
            Console.WriteLine();
            for (int j = 0; j < Plan.GetLength(1); j++)
            {
                Console.Write($"/{j}");
                for (int i = 0; i < Plan.GetLength(0); i++)
                {
                    Console.Write(" " + Plan[i, j].Status);
                    //Console.Write(" " + Plan[i, j].GranicaPola);
                }
                Console.Write($"/{j}");
                Console.WriteLine();

            }
            Console.Write("//");
            for (int r = 0; r < Plan.GetLength(0); r++)
            {
                Console.Write($"/{r}");
            }
            Console.Write("//");
        }

        public char SprawdzPole(Pole pole)
        {
            return pole.Status;
        }

        public char SprawdzPole(int x, int y)
        {
            return Plan[x, y].Status;
        }

        public bool SprawdzSasiedniePola(int x, int y)
        {
            if(Plan[x,y].GranicaPola == Granica.GornyLewy)
            {
                if(Plan[x+1,y].Status == '~' && Plan[x + 1, y+1].Status == '~' && Plan[x, y +1].Status == '~')
                {
                    return true;
                }
            }
            else if(Plan[x, y].GranicaPola == Granica.Gorny)
            {
                if (Plan[x + 1, y].Status == '~' && Plan[x + 1, y + 1].Status == '~' && Plan[x, y + 1].Status == '~'
                    && Plan[x-1,y+1].Status == '~' && Plan[x - 1, y].Status == '~')
                {
                    return true;
                }
            }
            else if (Plan[x, y].GranicaPola == Granica.GornyPrawy)
            {
                if (Plan[x, y+1].Status == '~' && Plan[x - 1, y + 1].Status == '~' && Plan[x-1 , y].Status == '~')
                {
                    return true;
                }
            }
            else if (Plan[x, y].GranicaPola == Granica.Lewy)
            {
                if (Plan[x, y-1].Status == '~' && Plan[x + 1, y - 1].Status == '~' && Plan[x + 1 , y].Status == '~'
                    && Plan[x + 1, y + 1].Status == '~' && Plan[x, y +1].Status == '~')
                {
                    return true;
                }
            }
            else if (Plan[x, y].GranicaPola == Granica.Brak)
            {
                if (Plan[x + 1, y].Status == '~' && Plan[x + 1, y + 1].Status == '~' && Plan[x, y + 1].Status == '~'
                    && Plan[x - 1, y + 1].Status == '~' && Plan[x - 1, y].Status == '~' && Plan[x - 1, y - 1].Status == '~'
                    && Plan[x, y - 1].Status == '~' && Plan[x +1, y -1].Status == '~')
                {
                    return true;
                }
            }
            else if (Plan[x, y].GranicaPola == Granica.Prawy)
            {
                if (Plan[x, y + 1].Status == '~' && Plan[x - 1, y + 1].Status == '~' && Plan[x - 1, y].Status == '~'
                    && Plan[x - 1, y - 1].Status == '~' && Plan[x, y - 1].Status == '~')
                {
                    return true;
                }
            }
            else if (Plan[x, y].GranicaPola == Granica.DolnyLewy)
            {
                if (Plan[x, y - 1].Status == '~' && Plan[x + 1, y - 1].Status == '~' && Plan[x + 1, y].Status == '~')
                {
                    return true;
                }
            }
            else if (Plan[x, y].GranicaPola == Granica.Dolny)
            {
                if (Plan[x, y - 1].Status == '~' && Plan[x + 1, y - 1].Status == '~' && Plan[x + 1, y].Status == '~'
                    && Plan[x - 1, y - 1].Status == '~' && Plan[x - 1, y].Status == '~')
                {
                    return true;
                }
            }
            else if (Plan[x, y].GranicaPola == Granica.DolnyPrawy)
            {
                if (Plan[x, y - 1].Status == '~' && Plan[x - 1, y - 1].Status == '~' && Plan[x - 1, y].Status == '~')
                {
                    return true;
                }
            }
            return false;
        } // przy budowaniu planszy

        public void ZmienStatusPola(int x, int y, char status)
        {
            Plan[x, y].Status = status;
        }

        public void ZmienStatusSasiednichPol(int x, int y)   // dla zestrzelonych statków zaznacza pola w koło
        {
            int[] sasiedziX = {x - 1, x, x + 1};
            int[] sasiedziY = {y - 1, y, y + 1};

            foreach (int sx in sasiedziX)
            {
                foreach(int sy in sasiedziY)
                {
                    try
                    {
                        if(Plan[sx,sy].Status == '~')
                          ZmienStatusPola(sx,sy, '/');
                    }
                    catch
                    {

                    }
                }
            }

        }


    }
}

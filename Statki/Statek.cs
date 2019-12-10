using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    abstract class Statek
    {
        public int Maszty { get; set; }
        public char Rodzaj { get; set; }
        public bool Zatopiony {
            get
            {
                foreach (var cz in Czesc)
                {
                    if (IleRazyTrafiony == Maszty)
                    {
                        return true;
                    }

                    return false;
                }
                return false;
            }
            set{} }
        public int IleRazyTrafiony
        {
            get
            {
                int t = 0;
                foreach (var cz in Czesc)
                {
                    if (cz.Trafiony)
                    {
                        t++;
                    }
                }

                return t;
            }
            set {}
        }
        public char Kierunek = 'u';
        public CzescStatku[] Czesc;

        public bool CzyMoznaUmiescic(Pole pocz, Pole kon, Plansza plan)
        {
            int dlugosc = 0;
            
            //czy poczatek i koniec na planszy
            if(pocz.X < 10 && pocz.X >= 0 &&
                pocz.Y < 10 && pocz.Y >= 0 &&
                kon.X < 10 && kon.X >= 0 &&
                kon.Y < 10 && kon.Y >= 0)
            {
                //czy w pionie
                if(pocz.X - kon.X == 0)
                {
                    
                    dlugosc = Math.Abs(pocz.Y - kon.Y) + 1;
                    if(pocz.Y - kon.Y < 0)
                    {
                        Kierunek = 's';
                    }
                    else
                    {
                        Kierunek = 'n';
                    }

                }
                //czy w poziomie
                else if(pocz.Y - kon.Y == 0)
                {
                    dlugosc = Math.Abs(pocz.X - kon.X) + 1;
                    if (pocz.X - kon.X < 0)
                    {
                        Kierunek = 'e';
                    }
                    else
                    {
                        Kierunek = 'w';
                    }
                }
                else if(pocz.Y - kon.Y != 0 && pocz.X - kon.X != 0)
                {
                    throw new Exception("Statek nie jest w Pionie lub Poziomie! Lub jest poza Planszą");
                }

                if(dlugosc == Maszty)
                {
                    

                    if(Kierunek == 'n')
                    {
                        for(int i = 0; i < Maszty; i++)
                        {
                            
                            if(plan.SprawdzPole(pocz.X, pocz.Y - i) != '~' || plan.SprawdzSasiedniePola(pocz.X, pocz.Y - i) != true)
                            {
                                throw new Exception("Statek na tych bądź sąsiednich polach już został ustawiony!");
                            }


                        }
                        return true;
                    }

                    if (Kierunek == 's')
                    {
                        for (int i = 0; i < Maszty; i++)
                        {

                            if (plan.SprawdzPole(pocz.X, pocz.Y + i) != '~' || plan.SprawdzSasiedniePola(pocz.X, pocz.Y + i) != true)
                            {
                                throw new Exception("Statek na tych bądź sąsiednich polach już został ustawiony!");
                            }
       
                            

                        }
                        return true;
                    }

                    if (Kierunek == 'e')
                    {
                        for (int i = 0; i < Maszty; i++)
                        {

                            if (plan.SprawdzPole(pocz.X + i, pocz.Y) != '~' || plan.SprawdzSasiedniePola(pocz.X + i, pocz.Y) != true)
                            {
                                throw new Exception("Statek na tych bądź sąsiednich polach już został ustawiony!");
                            }


                        }
                        return true;
                    }

                    if (Kierunek == 'w')
                    {
                        for (int i = 0; i < Maszty; i++)
                        {

                            if (plan.SprawdzPole(pocz.X - i, pocz.Y) != '~' || plan.SprawdzSasiedniePola(pocz.X - i, pocz.Y) != true)
                            {
                                throw new Exception("Statek na tych bądź sąsiednich polach już został ustawiony!");
                            }


                        }
                        return true;
                    }

                }
                else
                {
                    throw new Exception("Statek niewymiarowy!");
                }


            }
            else
            {
                throw new Exception("Wyszedłeś poza Plansze");
            }
            return false;
        }



        public void UstawStatek(Pole pocz, Pole kon, Plansza plan)
        {
            if (CzyMoznaUmiescic(pocz, kon, plan))
            {
                for (int i = 0; i < Maszty; i++)
                {

                    if (Kierunek == 'n')
                    {
                        plan.ZmienStatusPola(pocz.X, pocz.Y-i, Rodzaj);
                        Czesc[i].Pole = plan.Plan[pocz.X, pocz.Y - i]; //przypisanie pola do cz statku
                        plan.Plan[pocz.X, pocz.Y - i].Czesc = Czesc[i];//przypisanie cz statku do pola

                    }
                    if (Kierunek == 's')
                    {
                        plan.ZmienStatusPola(pocz.X, pocz.Y + i, Rodzaj);
                        Czesc[i].Pole = plan.Plan[pocz.X, pocz.Y + i];//przypisanie pola do cz statku
                        plan.Plan[pocz.X, pocz.Y + i].Czesc = Czesc[i];//przypisanie cz statku do pola
                    }
                    if (Kierunek == 'e')
                    {
                        plan.ZmienStatusPola(pocz.X + i, pocz.Y, Rodzaj);
                        Czesc[i].Pole = plan.Plan[pocz.X + i, pocz.Y];//przypisanie pola do cz statku
                        plan.Plan[pocz.X + i, pocz.Y].Czesc = Czesc[i];//przypisanie cz statku do pola
                    }
                    if (Kierunek == 'w')
                    {
                        plan.ZmienStatusPola(pocz.X - i, pocz.Y, Rodzaj);
                        Czesc[i].Pole = plan.Plan[pocz.X - i, pocz.Y];//przypisanie pola do cz statku
                        plan.Plan[pocz.X - i, pocz.Y].Czesc = Czesc[i];//przypisanie cz statku do pola
                    }
                }
            }
            else
            {
                throw new Exception("Nie można umieścić statku!");
            }
        }


    }
}

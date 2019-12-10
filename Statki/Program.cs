using System;
using System.Collections.Generic;
using System.Linq;

namespace Statki
{
    public class Program
    {
        static void Main(string[] args)
        {
            //test 2
            Plansza gracz = new Plansza();
            Plansza komputer = new Plansza();
            Plansza ukrytaGracz = new Plansza();
            Plansza ukrytaKomputer = new Plansza();
            gracz.Wyswietl();

            Flota gracza = new Flota();
            Flota komputera = new Flota();

            //logika komputer
            List<Pole> potencjalneStrzalyKomputera = new List<Pole>();


            while (true)
            {
                Console.WriteLine("\nWybierz:\n" +
                    $"1. Ustaw statki, pozostało: Jednomasztowiec * {4 - gracza.UstawioneJ}, Dwumasztowiec * {3 - gracza.UstawioneD}, Trzymasztowiec * {2 - gracza.UstawioneT}, Czteromasztowiec *{1 - gracza.UstawioneC}\n" +
                    "2. Rozstaw statki automatycznie\n" +
                    "3. Wyswietl Swoją Planszę\n" +
                    "4. Rozpocznij grę\n" +
                    "0. Wyjscie\n"
                    );

                int wybor;
                while (!int.TryParse(Console.ReadLine(), out wybor))
                {
                    Console.WriteLine("\nPodałeś zły znak! wpisz jeszcze raz!");
                    Console.WriteLine("\nWybierz:\n" +
                                      $"1. Ustaw statki, pozostało: Jednomasztowiec * {4 - gracza.UstawioneJ}, Dwumasztowiec * {3 - gracza.UstawioneD}, Trzymasztowiec * {2 - gracza.UstawioneT}, Czteromasztowiec *{1 - gracza.UstawioneC}\n" +
                                      "2. Rozstaw statki automatycznie\n" +
                                      "3. Wyswietl Swoją Planszę\n" +
                                      "4. Rozpocznij grę\n" +
                                      "0. Wyjscie\n"
                    );
                }

                switch (wybor)
                {

                    case 1:
                        int[] pole = PodajWspolrzednePol();

                        if (PoliczOdlegloscMiedzyPolami(pole) == 4)
                        {
                            if (gracza.UstawioneC < 1)
                            {
                                try
                                {
                                    gracza.czteromasztowiec[gracza.UstawioneC] = new Czteromasztowiec();
                                    gracza.czteromasztowiec[gracza.UstawioneC].UstawStatek(gracz.Plan[pole[0], pole[1]], gracz.Plan[pole[2], pole[3]], gracz);
                                    gracza.UstawioneC++;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Cos poszlo nietak " + e);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ustawiłeś już maksymalną liczbę tego rodzaju statku");
                            }
                        }
                        if (PoliczOdlegloscMiedzyPolami(pole) == 3)
                        {
                            if (gracza.UstawioneT < 2)
                            {
                                try
                                {
                                    gracza.trzymasztowiec[gracza.UstawioneT] = new Trzymasztowiec();
                                    gracza.trzymasztowiec[gracza.UstawioneT].UstawStatek(gracz.Plan[pole[0], pole[1]], gracz.Plan[pole[2], pole[3]], gracz);
                                    gracza.UstawioneT++;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Cos poszlo nietak " + e);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ustawiłeś już maksymalną liczbę tego rodzaju statku");
                            }
                        }
                        if (PoliczOdlegloscMiedzyPolami(pole) == 2)
                        {
                            if (gracza.UstawioneD < 3)
                            {
                                try
                                {
                                    gracza.dwumasztowiec[gracza.UstawioneD] = new Dwumasztowiec();
                                    gracza.dwumasztowiec[gracza.UstawioneD].UstawStatek(gracz.Plan[pole[0], pole[1]], gracz.Plan[pole[2], pole[3]], gracz);
                                    gracza.UstawioneD++;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Cos poszlo nietak " + e);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ustawiłeś już maksymalną liczbę tego rodzaju statku");
                            }
                        }
                        if (PoliczOdlegloscMiedzyPolami(pole) == 1)
                        {
                            if (gracza.UstawioneJ < 4)
                            {
                                try
                                {
                                    gracza.jednomasztowiec[gracza.UstawioneJ] = new Jednomasztowiec();
                                    gracza.jednomasztowiec[gracza.UstawioneJ].UstawStatek(gracz.Plan[pole[0], pole[1]], gracz.Plan[pole[2], pole[3]], gracz);
                                    gracza.UstawioneJ++;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Cos poszlo nietak " + e);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ustawiłeś już maksymalną liczbę tego rodzaju statku");
                            }
                        }
                        if (PoliczOdlegloscMiedzyPolami(pole) <= 0)
                        {
                            Console.WriteLine("Statek nie jest w Pionie lub Poziomie!");
                        }
                        gracz.Wyswietl();
                        break;
                    case 2:
                        UstawStatkiAutomatycznie(gracz, gracza);
                        gracz.Wyswietl();
                        break;
                    case 3:
                        gracz.Wyswietl();
                        break;
                    case 4:
                        if (10 - gracza.UstawioneJ - gracza.UstawioneD - gracza.UstawioneT - gracza.UstawioneC == 0) // jeśli rozstawiłeś już statki
                        {
                            UstawStatkiAutomatycznie(komputer, komputera);

                            while (true)
                            {
                                Console.WriteLine("\nWybierz:\n" +
                                                  $"1. Strzelaj\n" +
                                                  "2. Statystyka\n" +
                                                  "3. Wyswietl Swoją Planszę\n" +
                                                  "4. Wyswietl Plansze Cel\n" +
                                                  "0. Wyjscie\n"
                                );

                                int wybor2;
                                while (!int.TryParse(Console.ReadLine(), out wybor2))
                                {
                                    Console.WriteLine("\nPodałeś zły znak! wpisz jeszcze raz!");
                                    Console.WriteLine("\nWybierz:\n" +
                                                      $"1. Strzelaj\n" +
                                                      "2. Statystyka\n" +
                                                      "3. Wyswietl Swoją Planszę\n" +
                                                      "4. Wyswietl Plansze Cel\n" +
                                                      "0. Wyjscie\n"
                                    );
                                }



                                switch (wybor2)
                                {

                                    case 1:
                                        int s = 3; // sprawdza czystrzał się udał
                                        s = Strzelaj(komputer, ukrytaGracz, PodajWspolrzedneJednegoPola("do strzału"));
                                        if (komputera.Zatopienia == 10)
                                        {
                                            Console.WriteLine("!!!!!WYGRAŁEŚ!!!!!");
                                            Console.WriteLine(gracza.Statystyka("Gracz "));
                                            Console.WriteLine(komputera.Statystyka("Komputer "));
                                            Console.ReadKey();
                                            return;
                                        }

                                        if (s != 3)
                                        {
                                            Console.WriteLine("Strzał Komputera");
                                            potencjalneStrzalyKomputera = KomputerStrzela(gracz, ukrytaKomputer, potencjalneStrzalyKomputera);
                                            if (gracza.Zatopienia == 10)
                                            {
                                                Console.WriteLine("!!!!! =((((( PRZEGRAŁEŚ =((((( !!!!!");
                                                Console.WriteLine(gracza.Statystyka("Gracz "));
                                                Console.WriteLine(komputera.Statystyka("Komputer "));
                                                Console.ReadKey();
                                                return;
                                            }
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine(gracza.Statystyka("Gracz "));
                                        Console.WriteLine(komputera.Statystyka("Komputer "));
                                        break;
                                    case 3:
                                        gracz.Wyswietl();
                                        break;
                                    case 4:
                                        ukrytaGracz.Wyswietl();
                                        break;
                                    case 0:
                                        return;
                                    default:
                                        Console.WriteLine("Nie ma takiej opcji w Menu");
                                        break;
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("Nie rozstawiłeś wszystkich statków");
                        }

                        break;

                    case 0:
                        return;
                    default:
                        Console.WriteLine("Nie ma takiej opcji w Menu");
                        break;
                }
            }
        }

        static int[] PodajWspolrzedneJednegoPola(string opis)
        {
            int x, y;
            Console.Write($"Podaj współrzędne pola {opis}\n" +
            "X = ");
            while (!int.TryParse(Console.ReadLine(), out x)) Console.WriteLine("wpisałeś coś dziwnego, wpisz jeszcze raz!");
                
            Console.Write("Y = ");
            while (!int.TryParse(Console.ReadLine(), out y)) Console.WriteLine("wpisałeś coś dziwnego, wpisz jeszcze raz!");

            int[] pola = { x, y };
            return pola;
        } // Pyta użytkownika o namiary na pole

        static int[] PodajWspolrzednePol()
        {

            int[] pocz = PodajWspolrzedneJednegoPola("poczatkowego");
            int[] kon = PodajWspolrzedneJednegoPola("koncowego");
            int[] pola = { pocz[0], pocz[1], kon[0], kon[1] };
            return pola;
        }  // Pyta o dwa pola (do rozstawiania statków)

        static int PoliczOdlegloscMiedzyPolami(int[] pola)
        {
            int dlugosc;
            if (pola[0] - pola[2] == 0)
            {

                dlugosc = Math.Abs(pola[1] - pola[3]) + 1;

            }
            else if (pola[1] - pola[3] == 0)
            {
                dlugosc = Math.Abs(pola[0] - pola[2]) + 1;
            }
            else
            {
                dlugosc = 0;
            }
            return dlugosc;
        }

        static int[] WspolrzedneStatkuZAutomatu(int dlugosc) // od randomowego począrku - wybiera jeden z 4 kierunków i oblicza pole koncowe(długość jest podana)
        {
            Random rnd = new Random();
            int poczX, poczY, konX = 0, konY = 0;
            poczX = rnd.Next(10);
            poczY = rnd.Next(10);
            int kierunek = rnd.Next(4); // 0 pn y-n // 1 pd y+n // 2 wsch x+n // 3 zach x-n
            dlugosc = dlugosc - 1;
            if (kierunek == 0) // pn
            {
                konX = poczX;
                konY = poczY - dlugosc;
            }
            else if (kierunek == 1) //pd
            {
                konX = poczX;
                konY = poczY + dlugosc;
            }
            else if (kierunek == 2) //wsch
            {
                konX = poczX + dlugosc;
                konY = poczY;
            }
            else if (kierunek == 3) //zach
            {
                konX = poczX - dlugosc;
                konY = poczY;
            }


            int[] pola = { poczX, poczY, konX, konY };
            return pola;
        }

        static void UstawStatkiAutomatycznie(Plansza plan, Flota flota)
        {
            while (flota.UstawioneC < 1)
            {
                try
                {
                    int[] pola = WspolrzedneStatkuZAutomatu(4);
                    flota.czteromasztowiec[flota.UstawioneC] = new Czteromasztowiec();
                    flota.czteromasztowiec[flota.UstawioneC].UstawStatek(plan.Plan[pola[0], pola[1]], plan.Plan[pola[2], pola[3]], plan);
                    flota.UstawioneC++;
                }
                catch
                {

                }
            }
            while (flota.UstawioneT < 2)
            {
                try
                {
                    int[] pola = WspolrzedneStatkuZAutomatu(3);
                    flota.trzymasztowiec[flota.UstawioneT] = new Trzymasztowiec();
                    flota.trzymasztowiec[flota.UstawioneT].UstawStatek(plan.Plan[pola[0], pola[1]], plan.Plan[pola[2], pola[3]], plan);
                    flota.UstawioneT++;
                }
                catch
                {

                }
            }
            while (flota.UstawioneD < 3)
            {
                try
                {
                    int[] pola = WspolrzedneStatkuZAutomatu(2);
                    flota.dwumasztowiec[flota.UstawioneD] = new Dwumasztowiec();
                    flota.dwumasztowiec[flota.UstawioneD].UstawStatek(plan.Plan[pola[0], pola[1]], plan.Plan[pola[2], pola[3]], plan);
                    flota.UstawioneD++;
                }
                catch
                {

                }
            }
            while (flota.UstawioneJ < 4)
            {
                try
                {
                    int[] pola = WspolrzedneStatkuZAutomatu(1);
                    flota.jednomasztowiec[flota.UstawioneJ] = new Jednomasztowiec();
                    flota.jednomasztowiec[flota.UstawioneJ].UstawStatek(plan.Plan[pola[0], pola[1]], plan.Plan[pola[2], pola[3]], plan);
                    flota.UstawioneJ++;
                }
                catch
                {

                }
            }
        }

        static int Strzelaj(Plansza planszaCel, Plansza planszaUkryta, int[] wspolrzednePola) // 0 pudło. 1 Trafiony, 2 Zatopiony, 3 już strzelono w to miejsce
        {
            if ((wspolrzednePola[0] < 0 || wspolrzednePola[0] > 9) && (wspolrzednePola[1] < 0 || wspolrzednePola[1] > 9))
            {
                Console.WriteLine("Strzał poza Planszę");
                return 3;
            }

            if (planszaUkryta.SprawdzPole(wspolrzednePola[0], wspolrzednePola[1]) == '~') // jeśli nie strzelano jeszcze w to miejsce
            {
                if (planszaCel.SprawdzPole(wspolrzednePola[0], wspolrzednePola[1]) == '~') // pudło
                {
                    planszaCel.Plan[wspolrzednePola[0], wspolrzednePola[1]].Status = 'o';
                    planszaUkryta.Plan[wspolrzednePola[0], wspolrzednePola[1]].Status = 'o';
                    Console.WriteLine($"Pudło! X: {wspolrzednePola[0]}, Y: {wspolrzednePola[1]}");
                    return 0;

                }
                else // trafienie
                {
                    planszaCel.Plan[wspolrzednePola[0], wspolrzednePola[1]].Status = 'x';
                    planszaUkryta.Plan[wspolrzednePola[0], wspolrzednePola[1]].Status = 'x';
                    planszaCel.Plan[wspolrzednePola[0], wspolrzednePola[1]].Czesc.Trafiony = true;
                    Console.WriteLine($"Trafiony! X: {wspolrzednePola[0]}, Y: {wspolrzednePola[1]}");
                    if (planszaCel.Plan[wspolrzednePola[0], wspolrzednePola[1]].Czesc.Statek.Zatopiony)
                    {
                        Console.WriteLine($"Zatopiony!!!  X: {wspolrzednePola[0]}, Y: {wspolrzednePola[1]}");
                        foreach (var czesc in planszaCel.Plan[wspolrzednePola[0], wspolrzednePola[1]].Czesc.Statek.Czesc)
                        {
                            planszaCel.ZmienStatusSasiednichPol(czesc.Pole.X, czesc.Pole.Y);
                            planszaUkryta.ZmienStatusSasiednichPol(czesc.Pole.X, czesc.Pole.Y);
                        }
                        return 2;
                    }

                    return 1;
                }
            }
            else
            {
                Console.WriteLine("Oddałeś już strzał w to pole lub zestrzeliłeś statek na sąsiednim polu. spróbuj jeszcze raz!");
                return 3;
            }


        }

        static List<Pole> KomputerStrzela(Plansza planszaCel, Plansza planszaUkryta, List<Pole> potencjalneStrzaly)
        {
            List<Pole> wszystkiePola = new List<Pole>();
            foreach (var pole in planszaUkryta.Plan) // zgarnia wszystkie możliwe do strzału pola
            {
                if (pole.Status == '~')
                {
                    wszystkiePola.Add(pole);
                }
            }


            int[] wspolrzedne = new int[3]; // {x,y, wynik strzalu}
            if (!potencjalneStrzaly.Any()) // jeśli nie ma podejrzanych pol
            {

                wspolrzedne = KomputerPierwszyStrzal(planszaCel, planszaUkryta, wszystkiePola); // tu strzela
                int[] strzal = new[] { wspolrzedne[0], wspolrzedne[1] };

                if (wspolrzedne[2] == 1) // trafiony
                {
                    potencjalneStrzaly.AddRange(GetPotencjalneStrzalyKomputera(strzal, planszaUkryta));
                }

            }
            else // jeśli są potencjalne strzały
            {
                Random rnd = new Random();

                int strzal = 3;
                while (strzal == 3)
                {

                    int index = rnd.Next(potencjalneStrzaly.Count);
                    wspolrzedne[0] = potencjalneStrzaly[index].X;
                    wspolrzedne[1] = potencjalneStrzaly[index].Y;
                    strzal = Strzelaj(planszaCel, planszaUkryta, wspolrzedne);
                    if (strzal == 0) //pudlo - wykreśl pole z listy potencjalnych strzałów
                    {
                        potencjalneStrzaly.RemoveAt(index);
                    }
                    else if (strzal == 1) // kolejny trafiony
                    {
                        int[] namiary = new[] { wspolrzedne[0], wspolrzedne[1] };

                        potencjalneStrzaly.AddRange(GetPotencjalneStrzalyKomputera(namiary, planszaUkryta));
                        //kasuje obecny z listy
                        potencjalneStrzaly.RemoveAt(index);

                        if (StatekWPionie(namiary, planszaUkryta))
                        {
                            Console.WriteLine("Pion");
                            potencjalneStrzaly = potencjalneStrzaly.Where(x => x.X == wspolrzedne[0]).ToList();
                        }
                        else
                        {
                            Console.WriteLine("Poziom");
                            potencjalneStrzaly = potencjalneStrzaly.Where(x => x.Y == wspolrzedne[1]).ToList();
                        }
                    }
                    else if (strzal == 2) // zatopiony
                    {
                        potencjalneStrzaly.Clear();
                    }

                }
            }

            /*    // Na potrzeby testów komputera
            Console.WriteLine("Obecny");
            Console.WriteLine($"X: {wspolrzedne[0]}, Y: {wspolrzedne[1]}");

            Console.WriteLine("Potencjalne ////////////////");
            foreach (var ps in potencjalneStrzaly)
            {
                Console.WriteLine(ps.ToString());
            }
            */
            return potencjalneStrzaly;
        }

        static int[] KomputerPierwszyStrzal(Plansza planszaCel, Plansza planszaUkryta, List<Pole> wszystkiePola)
        {
            Random rnd = new Random();
            int[] wspolrzedne = new int[3];
            int strzal = 3;

            while (strzal == 3)
            {
                int index = rnd.Next(wszystkiePola.Count);
                wspolrzedne[0] = wszystkiePola[index].X;
                wspolrzedne[1] = wszystkiePola[index].Y;
                strzal = Strzelaj(planszaCel, planszaUkryta, wspolrzedne);
            }

            wspolrzedne[2] = strzal;
            return wspolrzedne;

        }

        static List<Pole> GetPotencjalneStrzalyKomputera(int[] wspolrzedne, Plansza planszaUkryta)
        {
            List<Pole> lista = new List<Pole>();
            if (wspolrzedne[0] < 9 && planszaUkryta.Plan[wspolrzedne[0] + 1, wspolrzedne[1]].Status == '~')
            {
                lista.Add(planszaUkryta.Plan[wspolrzedne[0] + 1, wspolrzedne[1]]);
            }
            if (wspolrzedne[0] > 0 && planszaUkryta.Plan[wspolrzedne[0] - 1, wspolrzedne[1]].Status == '~')
            {
                lista.Add(planszaUkryta.Plan[wspolrzedne[0] - 1, wspolrzedne[1]]);
            }
            if (wspolrzedne[1] < 9 && planszaUkryta.Plan[wspolrzedne[0], wspolrzedne[1] + 1].Status == '~')
            {
                lista.Add(planszaUkryta.Plan[wspolrzedne[0], wspolrzedne[1] + 1]);
            }
            if (wspolrzedne[1] > 0 && planszaUkryta.Plan[wspolrzedne[0], wspolrzedne[1] - 1].Status == '~')
            {
                lista.Add(planszaUkryta.Plan[wspolrzedne[0], wspolrzedne[1] - 1]);
            }

            return lista;
        }

        static bool StatekWPionie(int[] wspolrzedne, Plansza planszaUkryta) // szukaj sasiedniego pola do wsp. oznaczonego x
        {
            if (wspolrzedne[0] < 9 && planszaUkryta.Plan[wspolrzedne[0] + 1, wspolrzedne[1]].Status == 'x')
            {
                return false; //poziom
            }
            if (wspolrzedne[0] > 0 && planszaUkryta.Plan[wspolrzedne[0] - 1, wspolrzedne[1]].Status == 'x')
            {
                return false;
            }
            if (wspolrzedne[1] < 9 && planszaUkryta.Plan[wspolrzedne[0], wspolrzedne[1] + 1].Status == 'x')
            {
                return true; // pion
            }
            if (wspolrzedne[1] > 0 && planszaUkryta.Plan[wspolrzedne[0], wspolrzedne[1] - 1].Status == 'x')
            {
                return true;
            }

            return true; // nigdy nie powinno zostać zwrócone 
        }


    }
}

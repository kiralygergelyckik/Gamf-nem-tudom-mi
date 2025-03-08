using System;
using System.Collections.Generic;
using System.IO;

namespace _2.forduló___1.feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.
            List<double> ora = new List<double>();
            List<double> perc = new List<double>();
            string beolvasando = "idopontok.txt";
            Beolvas(ora, perc, beolvasando);

            //a)
            List<double> fokok = new List<double>();
            HanyFok(ora, perc, fokok);
            FokMax(ora, perc, fokok);

            //b)
            LegKisSzogValt(fokok);


            //c)
            //List<string> szogek = new List<string>();
            //string beolvasando2 = "szogek.txt";
            //Beolvas(szogek, beolvasando2);
            //Vizsgal(szogek);

            //Console.WriteLine(Szog(60,11));
            Console.ReadKey();
        }

        static void Vizsgal(List<string> szogek)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {
                    if (Convert.ToString(Szog(i, j)) == szogek[5])
                    {
                        x = i;
                        y = j;
                    }
                }
            }
        }

        static void LegKisSzogValt(List<double> fokok)
        {
            List<double> valtozasok = new List<double>();
            for (int i = 0; i < fokok.Count -1; i++)
            {
                if (fokok[i] - fokok[i+1] >= 0)
                {
                    valtozasok.Add(fokok[i] - fokok[i + 1]);
                }
                else
                {
                    valtozasok.Add((fokok[i] - fokok[i + 1]) * -1);
                }
            }
            double legkisebb = valtozasok[0];
            for (int i = 1; i < valtozasok.Count; i++)
            {
                if (valtozasok[i] < legkisebb)
                {
                    legkisebb = valtozasok[i];
                }
            }
            Console.WriteLine(legkisebb);
        }
        private static double Szog(double ora, double perc)
        {
            double szog = perc * 6 - ora * 30 - ((perc / 5) * 2.5);
            return szog;
        }


        static void FokMax(List<double> ora, List<double> perc, List<double> fokok)
        {
            int maxi = 0;
            for (int i = 0; i < fokok.Count; i++)
            {
                if (fokok[i] > fokok[maxi])
                {
                    maxi = i;
                }
            }
            Console.WriteLine($"{ora[maxi]}:{perc[maxi]}");
            Console.WriteLine(fokok[maxi]);

        }

        static void HanyFok(List<double> ora, List<double> perc, List<double> fokok)
        {
            int orafok = 30;
            int percfok = 6;
            for (int i = 0; i < ora.Count; i++)
            {
                if (ora[i] <= 12 && (perc[i] * percfok - ora[i] * orafok) <= 180)
                {
                    fokok.Add(Szog(ora[i], perc[i]));
                }
                else if (ora[i] <= 12 && (perc[i] * percfok - ora[i] * orafok) > 180)
                {
                    fokok.Add(360 - (Szog(ora[i], perc[i])));
                }
                else
                {
                    fokok.Add(Szog(ora[i] -12, perc[i]));
                }
            }

            for (int i = 0; i < fokok.Count; i++)
            {
                if (fokok[i] < 0 && (fokok[i] * -1) <= 180)
                {
                    fokok[i] = fokok[i] * -1;
                }
                else if (fokok[i] < 0 && (fokok[i] * -1) > 180)
                {
                    fokok[i] = fokok[i] + 360;
                }
                else if (fokok[i] > 180)
                {
                    fokok[i] = 360 - fokok[i];
                }
                else
                {
                    fokok[i] = fokok[i];
                }
                //Console.WriteLine(fokok[i]);
            }
        }

        static void Beolvas(List<double> ora, List<double> perc, string beolvasando)
        {
            StreamReader sr = new StreamReader(beolvasando);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');
                ora.Add(double.Parse(sor[0]));
                perc.Add(double.Parse(sor[1]));
            }
            sr.Close();
        }
        static void Beolvas(List<string> szogek, string beolvasando)
        {
            StreamReader sr = new StreamReader(beolvasando);
            string[] sor = sr.ReadLine().Split(' ');
            
            for (int i = 0; i < sor.Length; i++)
            {

                szogek.Add(sor[i]);
                szogek[0] = "0";
            }
            sr.Close();
        }
    }
}

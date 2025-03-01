using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace szavak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> szavak = new List<string>();
            Beolvas(szavak);

            HashSet<string> palindromok = new HashSet<string>();

            foreach (string szo in szavak)
            {
                if (szo.Length >= 2 && PalindromE(szo))
                {
                    palindromok.Add(szo);
                }
            }

            Console.WriteLine(palindromok.Count);
            NeveloTav(szavak);
            Console.ReadKey();
        }

        private static bool PalindromE(string szo)
        {
            int bal = 0;
            int jobb = szo.Length - 1;

            while (bal < jobb)
            {
                if (szo[bal] != szo[jobb])
                {
                    return false;
                }
                bal++;
                jobb--;
            }

            return true;
        }

        private static void Beolvas(List<string> szavak)
        {
            StreamReader reader = new StreamReader("szoveg.txt");
            while (!reader.EndOfStream)
            {
                string sor = reader.ReadLine();
                string[] szavakLista = sor.Split(' ');
                foreach (string szo in szavakLista)
                {
                    szavak.Add(szo);
                }
            }
        }

        static void NeveloTav(List<string> szavak)
        {
            List<int> hosszak = new List<int>(1000);

            int db = 0;
            int i = 0;
            int k = 0;

            for (i = 0; i < szavak.Count; i++)
            {
                if (szavak[i] == "A" || szavak[i] =="AZ")
                {
                    db = i + 1;
                }
                while (szavak[db] != "A" || szavak[db] != "AZ")
                {
                    hosszak[k] += szavak[db].Length + 1;
                    db++;
                }
                db = 0;
            }

            int max = hosszak[i];
            for (int m = 0; m < hosszak.Count; m++)
            {
                if (hosszak[i] > max)
                {
                    max = hosszak[i];
                }
            }
            Console.WriteLine(max);
        }
    }
}
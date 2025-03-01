using System;
using System.Collections.Generic;
using System.IO;

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
    }
}
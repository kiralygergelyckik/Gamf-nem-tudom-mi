using System;

namespace Terkep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] terkep = new int[30, 30];
            beolvas(terkep);
            Keresesviz(terkep);
        }

        private static void beolvas(int[,] terkep)
        {
            for (int i = 0; i < 30; i++)
            {
                string[] sor = Console.ReadLine().Split();
                for (int j = 0; j < 30; j++)
                {
                    terkep[i, j] = Convert.ToInt32(sor[j]);
                }
            }
        }

        private static void Keresesviz(int[,] terkep)
        {
            int db = 0;
            int vizdb = 0;
            int[,] vizesTerulet = new int[30, 30];
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (terkep[i, j] == 21)
                    {
                        db++;
                        vizdb = Vizfokyik(i, j, terkep, vizesTerulet, vizdb);
                    }
                }
            }
            Console.WriteLine(db); 
            Console.WriteLine(vizdb); 
        }

        private static int Vizfokyik(int i, int j, int[,] terkep, int[,] vizesTerulet, int vizdb)
        {
            if (i < 0 || i >= 30 || j < 0 || j >= 30 || vizesTerulet[i, j] == 21)
                return vizdb;

            vizesTerulet[i, j] = 21;
            vizdb++;

            if (i - 1 >= 0 && terkep[i - 1, j] <= terkep[i, j]) 
            {
                vizdb = Vizfokyik(i - 1, j, terkep, vizesTerulet, vizdb);
            }
            if (i + 1 < 30 && terkep[i + 1, j] <= terkep[i, j]) 
            {
                vizdb = Vizfokyik(i + 1, j, terkep, vizesTerulet, vizdb);
            }
            if (j + 1 < 30 && terkep[i, j + 1] <= terkep[i, j]) 
            {
                vizdb = Vizfokyik(i, j + 1, terkep, vizesTerulet, vizdb);
            }
            if (j - 1 >= 0 && terkep[i, j - 1] <= terkep[i, j]) 
            {
                vizdb = Vizfokyik(i, j - 1, terkep, vizesTerulet, vizdb);
            }

            return vizdb;
        }
    }
}

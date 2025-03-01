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
                        //Vizfokyik(i, j, terkep, vizesTerulet);
                    }
                }
            }
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    vizdb++;
                }
            }
            Console.WriteLine(db);
            Console.WriteLine(vizdb);
        }
    }
}

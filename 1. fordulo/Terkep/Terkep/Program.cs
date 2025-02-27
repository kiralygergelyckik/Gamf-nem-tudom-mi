using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terkep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] terkep = new int[30, 30];
            beolvas(terkep);
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
            int db = Kereses(terkep);
            Console.WriteLine(db);
        }

        private static int Kereses(int[,] terkep)
        {
            int db = 0;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (terkep[i, j] == 21)
                    {
                        db += 1;
                    }
                }
            }
            return db;
        }
    }
}

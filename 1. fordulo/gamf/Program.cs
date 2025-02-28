using System;
using System.Collections.Generic;
using System.IO;

namespace gamf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string szoveg = Beolvas();
            //1. c)

            double hossz = Math.Round(Irany(szoveg));
            Console.WriteLine(hossz);

            Console.ReadKey();
        }

        static double Irany(string szoveg)
        {
            StreamWriter writer = new StreamWriter("kimenet.txt");
            int x = 0;
            int y = 0;
            for (int i = 0; i < szoveg.Length; i++)
            {
                if (szoveg[i] == 'a')
                {
                    y++;
                    writer.WriteLine($"P({x};{y})");
                }
                else if (szoveg[i] == 'b')
                {
                    x++;
                    writer.WriteLine($"P({x};{y})");
                }
                else if (szoveg[i] == 'c')
                {
                    y--;
                    writer.WriteLine($"P({x};{y})");
                }
                else
                {
                    x--;
                    writer.WriteLine($"P({x};{y})");
                }

            }
            writer.Close();
            return Math.Sqrt((x * x) + (y * y));
        }

        static string Beolvas()
        {
            StreamReader reader = new StreamReader("karsor.txt");
            string szoveg = reader.ReadLine();
            reader.Close();
            return szoveg;
        }
    }
}

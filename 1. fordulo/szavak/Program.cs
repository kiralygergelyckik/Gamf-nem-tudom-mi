using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace szavak
{
    internal class Program
    {
        static void Main(string[] args)
        {



            List<string> txt = new List<string>(1000);
            Beolvas(txt);




            int maxi = 0;
            int max = 0;

            for (int i = 0; i < txt.Count; i++)
            {
           

                if (Kulonbozoe(txt[i]))
                {
                    if (max < txt[i].Length)
                    {
                        max = txt[i].Length;
                        maxi = i;
                    }

                }
            }

            Console.WriteLine(max);

            StreamWriter writer = new StreamWriter("../../kiir.txt");
            writer.WriteLine(txt[maxi]);
            writer.Close();
        }


        private static bool Kulonbozoe(string szo)
        {
            for (int i = 0; i < szo.Length; i++)
            {
                for (int j = i + 1; j < szo.Length; j++)
                {
                    if (szo[i] == szo[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void Beolvas(List<string> txt)
        {
            StreamReader reader = new StreamReader("szoveg.txt");
            while (!reader.EndOfStream)
            {
                string[] sor = reader.ReadLine().Split(' ');
                foreach (var item in sor)
                {
                    txt.Add(item);
                }
            }
        }
    }
}

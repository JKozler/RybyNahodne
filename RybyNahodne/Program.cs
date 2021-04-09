using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RybyNahodne
{
    class Program
    {
        public static int[,] pole;
        static void Main(string[] args)
        {
            pole = NastavPole(1000, 100000);
            Console.WriteLine("Chytili jste celkem " + ChytRybuNaSit(10) + " rybu/ryb.");
            Console.ReadKey();
        }

        public static int[,] NastavPole(int velikost, int pocetRyb) 
        {
            Random random = new Random();
            int[,] po = new int[velikost, velikost];
            for (int i = 0; i < velikost; i++)
            {
                for (int y = 0; y < velikost; y++)
                {
                    if (pocetRyb == 0)
                    {
                        po[i, y] = 0;
                    }
                    else if (pocetRyb < 10)
                    {
                        po[i, y] = pocetRyb;
                        pocetRyb = 0;
                    }
                    else 
                    {
                        po[i, y] = random.Next(0, 2);
                        pocetRyb -= po[i, y];
                    }
                }
            }
            return po;
        }

        public static int ChytRybuNaSit(int velikostSite)
        {
            int celek = 0;
            Console.Write("Zvolte bod, kam chcete hodit sit na poli od 0 do 1000: ");
            int p1 = Convert.ToInt32(Console.ReadLine());
            for (int i = p1; i < p1 + velikostSite; i++)
            {
                for (int y = p1; y < p1 + velikostSite; y++)
                {
                    celek += pole[i, y];
                }
            }
            return celek;
        }
    }
}

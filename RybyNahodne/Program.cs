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
            Console.WriteLine("Probíhá výpočet nejlepšího umístění....");
            Console.WriteLine("---------------------");
            Console.WriteLine(ZjistitNejlepsiPozici());
            Console.WriteLine();
            Console.WriteLine("Chcete vyzkoušet? parametr x zadejte první a paremetr y jako druhý.");
            Console.WriteLine("Chytili jste celkem " + ChytRybuNaSit(30) + " rybu/ryb.");
            Console.ReadKey();
        }

        public static int[,] NastavPole(int velikostVMetrech, int pocetRyb) 
        {
            Random random = new Random();
            int[,] po = new int[velikostVMetrech, velikostVMetrech];
            for (int i = 0; i < velikostVMetrech; i++)
            {
                int pocetRybNaRadek = pocetRyb / velikostVMetrech;
                for (int y = 0; y < velikostVMetrech; y++)
                {
                    if (pocetRybNaRadek == 0)
                    {
                        po[i, y] = 0;
                    }
                    else if (pocetRybNaRadek == 1)
                    {
                        po[i, y] = pocetRybNaRadek;
                        pocetRybNaRadek = 0;
                    }
                    else 
                    {
                        po[i, y] = random.Next(2);
                        pocetRybNaRadek -= po[i, y];
                    }
                }
            }
            return po;
        }

        public static int ChytRybuNaSit(int velikostSite)
        {
            int celek = 0;
            Console.Write("Zvolte sloupec, kam chcete hodit sit na poli od 0 do 990: ");
            int p1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zvolte radek, kam chcete hodit sit na poli od 0 do 990: ");
            int p2 = Convert.ToInt32(Console.ReadLine());
            if (p1 >= 1001 - velikostSite)
                throw new ArgumentException("Mimo dosah");
            if (p2 >= 1001 - velikostSite)
                throw new ArgumentException("Mimo dosah");
            else 
            {
                for (int i = p1; i < p1 + velikostSite; i++)
                {
                    for (int y = p2; y < p2 + velikostSite; y++)
                    {
                        celek += pole[i, y];
                        Console.WriteLine("Chytil jste " + pole[i, y] + " ryb, pozice: x = " + i + " a y = " + y);
                    }
                }
            }
            return celek;
        }

        public static string ZjistitNejlepsiPozici()
        {
            int[] values = new int[940900];
            int p1 = 0; int p2 = 0;
            int help = 0;
            while (help != 940900)
            {
                int celek = 0;
                for (int i = p1; i < p1 + 30; i++)
                {
                    for (int y = p2; y < p2 + 30; y++)
                    {
                        celek += pole[i, y];
                    }
                }
                values[help] = celek;
                help++;
                if (p1 == 969)
                {
                    p1 = 0;
                    p2++;
                }
                else
                    p1++;
            }
            return "Nejlepsi pozice je na y = " + (Convert.ToString(Array.IndexOf(values, values.Max()) / 970)) + ", x = " + Array.IndexOf(values, values.Max()) % 970 + ".";
        }
    }
}

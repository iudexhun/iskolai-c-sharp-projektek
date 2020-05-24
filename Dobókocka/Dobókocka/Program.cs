using System;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;

namespace Dobókocka
{
    class Program
    {
        static void Main(string[] args)
        {
            start:;
            Console.Clear();
            Console.WriteLine("Dobókocka (Mészöly Marcell - 2020 [CC BY-NC-SA 4.0])");
            Console.WriteLine();
            Console.Write("Adja meg a generálni kívánt dobások számát: ");
            var inp = Console.ReadLine();
            int dobasok;
            while (!int.TryParse(inp, out dobasok) || dobasok <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Figyelem! A dobások száma egy pozitív egész szám kell legyen!");
                Console.Write("Adja meg a generálni kívánt dobások számát: ");
                inp = Console.ReadLine();
            }
            if (dobasok > 1000000)
            {
                Console.WriteLine();
                Console.WriteLine("A generálás eltarthat akár fél percig is. Kérem, várjon türelemmel!\nAz újrakezdéséhez zárja be, majd nyissa meg újra a programot.");
            }

            var timer = Stopwatch.StartNew();
            int[] dErtek = new int[dobasok];

            int hatosok = 0;
            int otosok = 0;
            int negyesek = 0;
            int harmasok = 0;
            int kettesek = 0;
            int egyesek = 0;

            for (int i=0; i<dobasok; i++)
            {
                var r = new Random();
                dErtek[i] = r.Next(1, 7);
                switch (dErtek[i])
                {
                    case (6):
                        hatosok++;
                        break;
                    case (5):
                        otosok++;
                        break;
                    case (4):
                        negyesek++;
                        break;
                    case (3):
                        harmasok++;
                        break;
                    case (2):
                        kettesek++;
                        break;
                    case (1):
                        egyesek++;
                        break;
                }
            }
            timer.Stop();
            Console.WriteLine($"Generálási idő: {(double) timer.ElapsedMilliseconds/1000} másodperc");
            Console.WriteLine();
            Console.WriteLine("A dobott értékek gyakorisága:");
            Console.WriteLine("(Alkalom: ahányszor az adott érték megjelent az összes dobott érték között)");
            Console.WriteLine($"Egyesek: {egyesek} alkalom");
            Console.WriteLine($"Kettesek: {kettesek} alkalom");
            Console.WriteLine($"Hármasok: {harmasok} alkalom");
            Console.WriteLine($"Négyesek: {negyesek} alkalom");
            Console.WriteLine($"Ötösök: {otosok} alkalom");
            Console.WriteLine($"Hotosok: {hatosok} alkalom");

            var rgy1 = (double)egyesek / dobasok;
            var rgy2 = (double)kettesek / dobasok;
            var rgy3 = (double)harmasok / dobasok;
            var rgy4 = (double)negyesek / dobasok;
            var rgy5 = (double)otosok / dobasok;
            var rgy6 = (double)hatosok / dobasok;


            Console.WriteLine();
            Console.WriteLine("A dobott értékek relatív gyakorisága:");
            Console.WriteLine("(Az adott érték alkalmai osztva összes dobási alkalommal)");
            Console.WriteLine($"Egyesek: {rgy1}");
            Console.WriteLine($"Kettesek: {rgy2}");
            Console.WriteLine($"Hármasok: {rgy3}");
            Console.WriteLine($"Négyesek: {rgy4}");
            Console.WriteLine($"Ötösök: {rgy5}");
            Console.WriteLine($"Hotosok: {rgy6}");

            Console.WriteLine();
            Console.WriteLine("A gyakoriságok összege egyenlő a dobások darabszámával.");
            Console.WriteLine("Bizonyítás");
            Console.WriteLine($"A generált dobások száma (a szám, amit megadtunk): {dobasok}");
            Console.WriteLine($"A gyakoriságok összege: {egyesek} + {kettesek} + {harmasok} + {negyesek} + {otosok} + {hatosok} = {egyesek + kettesek + harmasok + negyesek + otosok + hatosok}");
            Console.WriteLine();
            Console.WriteLine("A relatív gyakoriságok összege egyenlő eggyel.");
            Console.WriteLine($"A relatív gyakoriságok összege: {rgy1} + {rgy2} + {rgy3} + {rgy4} + {rgy5} + {rgy6} = {Math.Round(rgy1 + rgy2 + rgy3 + rgy4 + rgy5 +rgy6)}");

            Console.WriteLine();
            Console.WriteLine("A generálás újrakezdéséhez nyomja meg akármelyik gombot");
            Console.ReadKey();
            goto start;
        }
    }
}

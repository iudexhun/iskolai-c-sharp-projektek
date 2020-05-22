using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace cegesauto
{
    class Auto
    {

        public int nap;
        public string ora;
        public string perc;
        public string rsz;
        public int sza;
        public int km;
        public bool kibe;

        public Auto(string s)
        {
            string[] data = s.Split(' ');

            nap = int.Parse(data[0]);
            rsz = data[2];
            sza = int.Parse(data[3]);
            km = int.Parse(data[4]);

            if (data[5] == "0")
            {
                kibe = false;
            }
            else
            {
                kibe = true;
            }

            string[] data2 = data[1].Split(':');

            ora = data2[0];
            perc = data2[1];
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            #region 1 - tár

            StreamReader sr = new StreamReader("autok.txt");

            List<Auto> car = new List<Auto>();

            int db = 0;
            while (!sr.EndOfStream)
            {

                car.Add(new Auto(sr.ReadLine()));
                db++;
            }
            sr.Close();

            #endregion

            #region 2
            // le kell kérni azt, hogy 30-án mely rsz volt az utólsó 0 értékű hajtó
            Console.WriteLine("2. feladat");
            {
                int i = db - 1;
                while (car[i].kibe != false)
                {
                    i--;
                }


                Console.WriteLine("{0}. nap rendszám: {1}", car[i].nap, car[i].rsz);
                Console.WriteLine("");
            }

            #endregion

            #region 3
            { 
            Console.WriteLine("3. feladat");
            Console.Write("Adja meg a keresett napot: ");
            int nap = int.Parse(Console.ReadLine());

            Console.WriteLine("Forgalom a(z) " + nap + " napon:");

            {
                string m;

                for (int i = 0; i < db; i++)
                {
                    if (car[i].nap == nap)
                    {
                        if (car[i].kibe == true)
                        {
                            m = "be";
                        }
                        else
                        {
                            m = "ki";
                        }
                        Console.WriteLine("{0}:{1} {2} {3} {4}", car[i].ora, car[i].perc, car[i].rsz, car[i].sza, m);
                    }
                }
            }
            }
            #endregion

            #region 4
            // hóvégi hiányzó autók száma
            Console.WriteLine("");
            Console.WriteLine("4. feladat");

            {
                int kint = 0;
                for (int i = 0; i < db; i++)
                {
                    if (car[i].kibe == false)
                    {
                        kint++;
                    }
                    else
                    {
                        kint--;
                    }
                }

                Console.WriteLine("A hónap végén {0} autót nem hoztak vissza.", kint);
            }

            #endregion

            #region 5
            // a hónapban megtett kilóméterek/autó. Ha nincs bejöveti lezáró km a hó végén, akkor a hó végi kimeneti nyitó km-el kell számolni.

            Console.WriteLine("");
            Console.WriteLine("5. feladat");
            { 

            int[] kmk = new int[10];
            {
            /*
             * 0 -> 300
             * 1 -> 301
             * 2 -> 302
             * 3 -> 303
             * 4 -> 304
             * 5 -> 305
             * 6 -> 306
             * 7 -> 307
             * 8 -> 308
             * 9 -> 309
             */
            }
            
            /* kezdők  */ for (int i = 0; i<db; i++) 
            {
                for (int j=0; j<10; j++)
                {
                    if (car[i].rsz=="CEG30"+j && kmk[j] == 0)
                    {
                        kmk[j] = car[i].km;
                    }
                }
            }

            int[] kmv = new int[10];


            /* zárók */ for (int i = db-1; i > 0; i--) 
            {
                for (int j = 0; j < 10; j++)
                {
                    if (car[i].rsz == "CEG30" + j && kmv[j] == 0)
                    {
                        kmv[j] = car[i].km;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("CEG30{0} {1} km", i, kmv[i]-kmk[i]) ;
            }

            }

            #endregion

            #region 6
            // a záró km - a nyitó km = a megtett út km-ben / utazás. Ebből kell a legnagyobb, majd pedig a vezető személy azonosítóját kell vele kiírni.

            Console.WriteLine("");
            Console.WriteLine("6. feladat");

            int[] megtett = new int[db];
            int[] szem = new int[db];

            //ezzel a módszerrel a "megtett" tömb tartalmaz egy rakat 0-t.

            for (int i=0; i<db; i++)
            {
                if (car[i].kibe == false)
                {
                    for (int j=i; j<db; j++)
                    {
                        if (megtett[i] == 0) // ha ez nem lenne itt, akkor azt számolná, hogy az utolsóbó km-ből kivonva az első, majd a második, majd stb-dik km...
                        { 
                            if (car[j].rsz==car[i].rsz && car[j].kibe==true) // ha a eleje az lett vna, hogy car[j].sza == car[i].sza && ... akkor tele lenne egy csomó negatív értékkel a tömb.
                            {
                            megtett[i] = car[j].km - car[i].km;
                            szem[i] = car[i].sza;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Leghosszabb út: {0} km, személy: {1}", megtett.Max(), szem[megtett.ToList().IndexOf(megtett.Max())]);


            #endregion

            #region 7

            { 
            Console.WriteLine("");
            Console.WriteLine("7. feladat");
            Console.Write("Adjon meg egy rendszámot a menetlevél elkészítéséhez: ");
            string rendsz = Console.ReadLine();
            StreamWriter sw = new StreamWriter(rendsz + "_menetlevel.txt");

            for (int i=0; i<db; i++)
            {
                if (car[i].rsz == rendsz && car[i].kibe==false)
                {
                    sw.Write("{0}\t{1}. {2}:{3}\t{4} km\t", car[i].sza, car[i].nap , car[i].ora , car[i].perc, car[i].km);
                }
                else
                { 
                    if (car[i].rsz == rendsz && car[i].kibe == true)
                    {
                        sw.WriteLine("{0}. {1}:{2}\t{3} km" , car[i].nap, car[i].ora, car[i].perc, car[i].km);
                    }
                }
            }
            sw.Close();
            Console.WriteLine("Menetlevél kész.");
            }

            #endregion

        }
    }
}

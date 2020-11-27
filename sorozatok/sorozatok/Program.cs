using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace sorozatok
{
    class Data
    {
        public string fulldate;
        public int year;
        public int month;
        public int date;
        public string title;
        public string sxe;
        public int lenght;
        public bool seen;

        public Data (string s, string ss, string sss, string ssss, string sssss)
        {
            fulldate = s;
            if (fulldate != "NI")
            {
                year = int.Parse(s.Split('.')[0]);
                month = int.Parse(s.Split('.')[1]);
                date = int.Parse(s.Split('.')[2]);
            }
            title = ss;
            sxe = sss;
            lenght = int.Parse(ssss);
            if (sssss == "0")
            {
                seen = false;
            }
            else
            {
                seen = true;
            }
        }

    }

    class DataKi
    {
        public string cím;
        public int hossz;
        public int db;

        public DataKi(string s)
        {
            cím = s;
            hossz = 0;
            db = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 1f
            List<Data> lista = new List<Data>();

            StreamReader sr = new StreamReader("lista.txt");

            while(!sr.EndOfStream)
            {
                lista.Add(new Data(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()));
            }

            sr.Close();

            #endregion

            #region 2f

            int tudomadatumot = 0;

            foreach(Data d in lista)
            {
                if (d.fulldate != "NI")
                {
                    tudomadatumot++;
                }
            }
            Console.WriteLine("2. feladat");
            Console.WriteLine("A listában {0} db vetítési dátummal rendelkező epizód van.", tudomadatumot);

            #endregion

            #region 3f

            double latott = 0;

            for (int i = 0; i<lista.Count(); i++)
            {
                if (lista[i].seen)
                {
                    latott++;
                }
            }

            double szazalek = Math.Round((latott / double.Parse(lista.Count().ToString()) * 100), 2);
            Console.WriteLine("3. feladat");
            Console.WriteLine("A listában lévő epizódok {0}%-át látta. " , szazalek);

            #endregion

            #region 4f

            int percek = 0;

            for (int i= 0; i<lista.Count(); i++)
            {
                if (lista[i].seen)
                {
                    percek += lista[i].lenght;
                }
            }

            int napok = percek / (24 * 60);
            percek -= napok * 24 * 60;
            int orak = percek / 60;
            percek -= orak * 60;

            Console.WriteLine("4. feladat");
            Console.WriteLine("Sorozatnézéssel {0} napot {1} órát és {2} percet töltött.", napok, orak, percek);

            #endregion

            #region 5f

            Console.WriteLine("5. feladat");
            Console.Write("Adjon meg egy dátumot! Dátum= ");
            string s = Console.ReadLine();
            int beev = int.Parse(s.Split('.')[0]);
            int beho = int.Parse(s.Split('.')[1]);
            int benap = int.Parse(s.Split('.')[2]);
            for(int i=0; i<lista.Count(); i++)
            {
                if(lista[i].fulldate != "NI" && lista[i].year <= beev && lista[i].month <= beho && lista[i].date <= benap && !lista[i].seen)
                {
                    Console.WriteLine("{0}\t{1}", lista[i].sxe, lista[i].title);
                }
            }

            #endregion

            #region 7f

            Console.WriteLine("7. feladat");

            Console.Write("Adja meg a hét egy napját (például cs)! Nap= ");
            string bed = Console.ReadLine();

            List<string> cimek = new List<string>();

            for (int i = 0; i<lista.Count(); i++)
            {
                if(lista[i].fulldate != "NI" && bed == Hetnapja(lista[i].year, lista[i].month, lista[i].date) && !cimek.Contains(lista[i].title))
                {
                    cimek.Add(lista[i].title);
                    Console.WriteLine(lista[i].title);
                }
            }
            if (cimek.Count == 0)
            {
                Console.WriteLine("Az adott napon nem került adásba sorozat.");
            }


            #endregion

            #region 8f

            StreamWriter sw = new StreamWriter("summa.txt");

            List<string> cimek2 = new List<string>();

            for (int i = 0; i<lista.Count(); i++)
            {
                if (!cimek2.Contains(lista[i].title))
                {
                    cimek2.Add(lista[i].title);
                }
            }

            DataKi[] T = new DataKi[cimek2.Count()];

            for (int i = 0; i<cimek2.Count; i++)
            {
                T[i] = new DataKi(cimek2[i]);
            }

            for (int i = 0; i<lista.Count(); i++)
            {
                for (int j = 0; j<T.Length; j++)
                {
                    if(lista[i].title == T[j].cím)
                    {
                        T[j].db++;
                        T[j].hossz += lista[i].lenght;
                    }
                }
            }

            for (int i=0; i<cimek2.Count(); i++)
            {
                sw.WriteLine("{0} {1} {2}", T[i].cím, T[i].hossz, T[i].db);
            }

            sw.Close();

            #endregion
        }

        #region 6. feladat

        static string Hetnapja(int y, int m, int d)
        {
            string[] napok = new string[7]
            {   
                "v",
                "h",
                "k",
                "sze",
                "cs",
                "p",
                "szo"
            };
            int[] honapok = new int[12]
            {
                0,
                3,
                2,
                5,
                0,
                3,
                5,
                1,
                4,
                6,
                2,
                4
            };
            if (m < 3)
            {
                y--;
            }

            return napok[(y + y/4 - y/100 + y/400+honapok[m-1]+d) % 7];
        }
        #endregion
    }
}

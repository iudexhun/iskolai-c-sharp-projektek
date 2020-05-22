using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/* namespace hianyzasok //!!! A MÁSODIK MEGOLDÁS HATÉKONYABB !!! -> a konstruktornak meg lehet adni több bemenetet.
{
    class Data
    {
        public int ho = 0;
        public int nap = 0;
        public string nev;
        public char[] jelen = new char[7];

        public Data()
        { }

        public Data(string s)
        {
            string[] hianyzas = s.Split(' ');
            nev = hianyzas[0] + " " + hianyzas[1];
            jelen[0] = hianyzas[2][0];
            jelen[1] = hianyzas[2][1];
            jelen[2] = hianyzas[2][2];
            jelen[3] = hianyzas[2][3];
            jelen[4] = hianyzas[2][4];
            jelen[5] = hianyzas[2][5];
            jelen[6] = hianyzas[2][6];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("naplo.txt");
            List<Data> naplo = new List<Data>();
            int hoidg = 0;
            int napidg = 0;

            int db = 0;

            while (!sr.EndOfStream)
            {
                string be = sr.ReadLine();
                if (be.StartsWith('#'))
                {
                    string[] datum = be.Split(' ');
                    hoidg=int.Parse(datum[1]);
                    napidg=int.Parse(datum[2]);
                }
                else
                {
                    naplo.Add(new Data(be));
                    naplo[db].ho = hoidg;
                    naplo[db].nap = napidg;
                    db++;
                }
            }

            sr.Close();
        }
    }
}
*/

namespace hianyzasok
{
    class Data
    {
        public int ho;
        public int nap;
        public string nev;
        public string jelen;

        public Data()
        { }

        public Data(string s, int honapocska, int napocska)
        {
            string[] hianyzas = s.Split(' ');
            nev = hianyzas[0] + " " + hianyzas[1];
            jelen = hianyzas[2];
            ho = honapocska;
            nap = napocska;
        }
    }

    class Program
    {
        static void Main(string[] args) // főfüggvény, ettől egy másikat fogunk csinálni
        {

            #region 1f 
            StreamReader sr = new StreamReader("naplo.txt");
            List<Data> naplo = new List<Data>();
            int hoidg = 0;
            int napidg = 0;

            while (!sr.EndOfStream)
            {
                string be = sr.ReadLine();
                if (be.StartsWith('#'))
                {
                    string[] datum = be.Split(' ');
                    hoidg = int.Parse(datum[1]);
                    napidg = int.Parse(datum[2]);
                }
                else
                {
                    naplo.Add(new Data(be, hoidg, napidg));
                }
            }

            sr.Close();
            #endregion

            #region 2f
            Console.WriteLine("2. feladat");
            Console.WriteLine("A naplóban {0} bejegyzés van.", naplo.Count);
            #endregion

            #region 3f

            int igt=0;
            int igatlan=0;

            for (int i=0; i<naplo.Count; i++)
            {
                for (int j=0; j<7; j++)
                {
                    if (naplo[i].jelen[j] == 'X')
                    {
                        igt++;
                    }
                    if (naplo[i].jelen[j] == 'I')
                    {
                        igatlan++;
                    }
                }
            }

            Console.WriteLine("3. feladat");
            Console.WriteLine("Az igazolt hiányzások száma {0}, az igazolatlanoké {1} óra.", igt, igatlan);
            #endregion

            #region 5f
            Console.WriteLine("5. feladat");
            Console.Write("A hónap sorszáma = ");
            int honap = int.Parse(Console.ReadLine());
            Console.Write("A nap sorszáma = ");
            int nap = int.Parse(Console.ReadLine());
            Console.WriteLine("Aznap " + Hetnapja(honap, nap) + " volt.");
            #endregion

            #region 6f
            Console.WriteLine("6. feladat");
            Console.Write("A nap neve = ");
            string napnev = Console.ReadLine();
            Console.Write("Az óra sorszáma = ");
            int ora = int.Parse(Console.ReadLine());

            Console.WriteLine("Ekkor összesen " + Osszhianyzas(naplo, napnev, ora) + " óra hiányzás történt.");

            #endregion

            #region 7f

            Console.WriteLine("7. feladat");
            Sok(naplo);

            #endregion

        }


        #region 4f
        static string Hetnapja(int honap, int nap) // ezt is megadja a feladatlap
        {
            string[] napnev = new string[7] // nem kell ; mert {} jön, akár egy sorba is mehetne
            {"vasárnap", "hetfő", "kedd", "szerda", "csütörtök", "péntek", "szombat"}; // az elemek

            int[] napszam = new int[12] 
            {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335};

            int napsorszam = (napszam[honap - 1] + nap) % 7;
            return napnev[napsorszam]; // ezt adja vissza a program, ez a feladatban onnan tudható, hogy az a neve ennek, mint a nagy függvénynek
        }
        #endregion

        #region 6f fv

        static int Osszhianyzas(List<Data> lista, string nap, int ora)
        {

            int hianyok = 0;

            for (int i = 0; i<lista.Count; i++)
            {
                if (Hetnapja(lista[i].ho, lista[i].nap) == nap)
                {
                    if (lista[i].jelen[ora-1] == 'X' || lista[i].jelen[ora - 1] == 'I')
                    {
                        hianyok++;
                    }
                }
            }

            return hianyok;

        }

        #endregion

        #region 7f fv

        static void Sok(List<Data> lista)
        {

            List<string> nevek = new List<string>();

            for (int i = 0; i < lista.Count; i++)
            {

                if (!nevek.Contains(lista[i].nev))
                {
                    nevek.Add(lista[i].nev);
                }

            }

            int[] orak = new int[nevek.Count];

            for (int i = 0; i < lista.Count; i++)
            {

                for (int j = 0; j < nevek.Count; j++)
                {
                    if (lista[i].nev == nevek[j])
                    {
                        for (int g = 0; g < 7; g++)
                        {
                            if (lista[i].jelen[g] == 'X' || lista[i].jelen[g] == 'I')
                            {
                                orak[j]++;
                            }
                        }
                    }
                }
            }

            Console.Write("A legtöbbet hiányzó tanulók: ");

            for (int i=0; i<orak.Length; i++)
            {
                if (orak.Max() == orak[i])
                {
                    Console.Write(nevek[i] + " ");
                }
            }

            Console.WriteLine();

        }
        
        #endregion
    }
}
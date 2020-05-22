using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace eutazas
{

    class Data
    {

        public int stopid;
        public int datestamp;
        public int timestamp;
        public int ticid;
        public string tictype;
        public int val;
        


        public Data ()
        { }

        public Data(string s)
        {

            stopid = int.Parse(s.Split(' ')[0]);
            datestamp = int.Parse(s.Split(' ')[1].Split('-')[0]);
            timestamp = int.Parse(s.Split(' ')[1].Split('-')[1]);
            ticid = int.Parse(s.Split(' ')[2]);
            tictype = s.Split(' ')[3];
            val = int.Parse(s.Split(' ')[4]);


        }


    }
        
        
    

    
    class Program
    {
        static void Main(string[] args)
        {

            #region 1f

            List<Data> log = new List<Data>();

            StreamReader sr = new StreamReader("utasadat.txt");

            while (!sr.EndOfStream)
            {
                log.Add(new Data(sr.ReadLine()));
            }

            sr.Close();

            #endregion

            #region 2f

            Console.WriteLine("2. feladat");
            Console.WriteLine("A buszra {0} utas akart felszállni." , log.Count);

            #endregion

            #region 3f

            
            Console.WriteLine(Feladat3(log, 3));

            #endregion

            #region 4f

            int[] felszallok = new int[30];

            for (int i = 0; i<log.Count; i++)
            {
                for (int j = 0; j<30; j++)
                {
                    if (log[i].stopid == j)
                    {
                        felszallok[j]++;
                    }
                }
            }

            Console.WriteLine("4. feladat");
            Console.WriteLine("A legtöbb utas ({0} fő) a {1}. megállóban próbált felszállni.", felszallok.Max(), Ind(felszallok.Max(), felszallok) );

            #endregion

            #region 5f

            Console.WriteLine(Feladat3(log, 5));

            #endregion

            #region 7f

            StreamWriter sw = new StreamWriter("figyelmeztetes.txt");


            for (int i = 0; i < log.Count; i++)
            {

                int dsev = int.Parse(log[i].datestamp.ToString().Remove(4));
                int dsho = int.Parse((log[i].datestamp.ToString().Remove(0, 4)).Remove(2));
                int dsnap = int.Parse(log[i].datestamp.ToString().Remove(0, 6));
                if (log[i].val.ToString().Length > 2)
                {
                    int valev = int.Parse(log[i].val.ToString().Remove(4));
                    int valho = int.Parse((log[i].val.ToString().Remove(0, 4)).Remove(2));
                    int valnap = int.Parse(log[i].val.ToString().Remove(0, 6));

                    if (Napokszama(dsev, dsho, dsnap, valev, valho, valnap) <= 3 && Napokszama(dsev, dsho, dsnap, valev, valho, valnap) >= 0)
                    {
                        sw.WriteLine("{0} {1}-{2}-{3}", log[i].ticid , log[i].val.ToString().Remove(4), (log[i].val.ToString().Remove(0, 4)).Remove(2), log[i].val.ToString().Remove(0, 6));
                    }
                }
            }

            sw.Close();

            #endregion



        }

        #region 6f
        static int Napokszama(int e1, int h1, int n1, int e2, int h2, int n2)
        {
            h1 = (h1 + 9) % 12;
            e1 = e1 - h1 / 10;
            int d1 = 365 * e1 + e1 / 4 - e1 / 100 + e1 / 400 + (h1 * 306 + 5) / 10 + n1 - 1;
            h2 = (h2 + 9) % 12;
            e2 = e2 - h2 / 10;
            int d2 = 365 * e2 + e2 / 4 - e2 / 100 + e2 / 400 + (h2 * 306 + 5) / 10 + n2 - 1;
            return d2-d1;
        }
        #endregion

        static int Ind(int be, int[] vs)
        {
            for (int i = 0; i<vs.Count(); i++)
            {
                if (be==vs[i])
                {
                    return i;
                }
            }

            return -1;
        }

        static string Feladat3(List<Data> log, int felszam)
        {

            int deny = 0;
            int kedv = 0;
            int ingy = 0;

            for (int i = 0; i < log.Count; i++)
            {
                if (log[i].val.ToString().Length < 8)
                {
                    if (log[i].val == 0)
                    {
                        deny++;
                    }

                }
                else
                {
                    if (log[i].val < log[i].datestamp)
                    {
                        deny++;
                    }
                    else
                    {
                        if (log[i].tictype == "TAB" || log[i].tictype == "NYB")
                        {
                            kedv++;
                        }
                        if (log[i].tictype == "NYP" || log[i].tictype == "RVS" || log[i].tictype == "GYK")
                        {
                            ingy++;
                        }
                    }
                }
            }

            if (felszam == 3)
            {
                Console.WriteLine("3. feladat");
                return ("A buszra " + deny + " utas nem szállhatott fel.");
            }
            if (felszam == 5)
            {
                Console.WriteLine("5. feladat");
                return ("Ingyenesen utazók száma: " + ingy + " fő\nA kedvezményesen utazók száma: " + kedv + " fő");
            }

            return "hiba";
            
        }

    }
}

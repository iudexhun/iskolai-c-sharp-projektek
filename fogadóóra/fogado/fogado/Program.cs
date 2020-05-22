using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace fogado
{

    class Foglalas
    {
        public string nev;
        public int foglora;
        public int foglperc;
        public int tsev;
        public int tsho;
        public int tsnap;
        public int tsora;
        public int tsperc;

        public Foglalas() { }

        public Foglalas(string s)
        {
            string[] sa1 = s.Split(' ');
            nev = sa1[0] + " " + sa1[1];
            foglora = int.Parse(sa1[2].Split(':')[0]);
            foglperc = int.Parse(sa1[2].Split(':')[1]);
            string[] sa2 = sa1[3].Split('-')[0].Split('.');
            tsev = int.Parse(sa2[0]);
            tsho = int.Parse(sa2[1]);
            tsnap = int.Parse(sa2[2]);
            tsora = int.Parse(sa1[3].Split('-')[1].Split(':')[0]);
            tsperc = int.Parse(sa1[3].Split('-')[1].Split(':')[1]);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Foglalas> foglalas = new List<Foglalas>();

            StreamReader sr = new StreamReader("fogado.txt");

            while (!sr.EndOfStream)
            {
                foglalas.Add(new Foglalas(sr.ReadLine()));
            }

            sr.Close();

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace furdostat
{

    class Adat
    {
        public int vendaz;
        public int reszlaz; // 0 - öltöző; 1 - uszoda; 2 - szauna; 3 - gyógyv. medence; 4 - strand
        public int kibe; // 0 - be; 1 - ki
        public int ora;
        public int perc;
        public int mperc;

        public Adat(){}

        public Adat(string s)
        {
            string[] sa = s.Split(' ');
            vendaz = int.Parse(sa[0]);
            reszlaz = int.Parse(sa[1]);
            kibe = int.Parse(sa[2]);
            ora = int.Parse(sa[3]);
            perc = int.Parse(sa[4]);
            mperc = int.Parse(sa[5]);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Adat> log = new List<Adat>();

            StreamReader sr = new StreamReader("furdoadat.txt");

            while(!sr.EndOfStream)
            {
                log.Add(new Adat(sr.ReadLine()));
            }
			
			sr.Close();

        }
    }
}

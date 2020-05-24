using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lista
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> data = new List<string>();

            for (int i = 0; i < 4; i++) // i értéke mindegy, mert nem i-re hivatkozva töltünk fel kijelölt adathelyeket.
            {
                data.Add(Console.ReadLine());
            }
            Console.WriteLine(data[0] + data[1] + data[2]); //listaelemekre ugyanúgy hivatk. mint a tömbelemekre.

            // A LISTA IS 0. ELEMMEL KEZDŐDIK!
        }
    }
}

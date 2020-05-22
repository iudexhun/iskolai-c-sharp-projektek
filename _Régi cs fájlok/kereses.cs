using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _46
{
    class Program
    {
        static void Main(string[] args)
        {

            #region TÖMB + FELTÖLTÉS

            Console.Write("Adjon meg egy tömbszámot: ");
            int tömbszám = int.Parse(Console.ReadLine());

            int[] Tömb = new int[tömbszám];

            for (int i = 0; i < tömbszám; i++)

            {
                Console.Write("Adja meg a tömb {0}. elemét: ", i + 1);
                Tömb[i] = int.Parse(Console.ReadLine());

            }

            #endregion

            #region KERESÉS

            Console.Write("Adja meg a keresett számot: ");
            int keresett = int.Parse(Console.ReadLine());

            int eredmény = 0;

            for (int i = 0; i < tömbszám; i++)
            {
                if (keresett == Tömb[i])
                {
                    eredmény++;
                }
            }

            Console.WriteLine("A keresett szám {0} alkalommal található meg a tömbben." , eredmény);

            #endregion

        }
    }
}

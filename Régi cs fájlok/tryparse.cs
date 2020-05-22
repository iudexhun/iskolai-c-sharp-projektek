using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryp
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * var y = Console.ReadLine();
            int x;
            if (int.TryParse(y, out x)) //ha az int elé teszek egy !-t, akkor invertálja. Ez máshol még érdekes lehet!
            {
                Console.WriteLine("Yess"); // ha a kívánt típust adja meg, akkor ez lesz. ezesetben az y érték a kívánt változótípusban örökítődik x néven.
            }
            else
            {
                Console.WriteLine("Csak számok!"); // ha nem a kívánt típust adja meg, akkor ez lesz. ezesetben az y értéke nem örökítődik, az x értéke pedig 0 lesz. az y értéke megmarad, mint egy string.
            }
            */
            
            
            var inp = Console.ReadLine();
            int menu;

            while (!int.TryParse(inp, out menu))
            {
                Console.WriteLine("A megadott érték nem felel meg a kritériumnak.");
                Console.Write("Új érték: ");

                inp = Console.ReadLine();

            }

            Console.WriteLine("Csak sikerült!");


        }
    }
}

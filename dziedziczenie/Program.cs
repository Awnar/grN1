using dziedziczenie.klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dziedziczenie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Liczba pojazdów: {Pojazd.LiczbaPojazdów}");

            SamochodOsobowy auto1 = new SamochodOsobowy("Fiat", "czerwony", 10);

            auto1.Info();
            SamochodOsobowy.LiczbaPojazdów = 3;

            Console.WriteLine(auto1.ToString());
            Console.WriteLine(auto1.GetType());
            Console.WriteLine(auto1.GetHashCode());

            Autobus auto2 = new Autobus("Solaris", "zielony", 21, 37);
            auto2.Info();

            Console.WriteLine($"Liczba pojazdów: {Pojazd.LiczbaPojazdów}");

            Console.ReadKey();
        }
    }
}

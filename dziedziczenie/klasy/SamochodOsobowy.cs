using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dziedziczenie.klasy
{
    class SamochodOsobowy : Pojazd
    {
        public SamochodOsobowy(string marka, string kolor):base(marka, kolor)
        {
        }

        public SamochodOsobowy(string marka, string kolor, int moc):base(marka, kolor, moc)
        {
        }

        public override void Info()
        {
            Console.WriteLine("Jestem Samochodem");
        }

        public override string ToString()
        {
            return $"Marka: {Marka}\n\tKolor: {Kolor}\n\tMoc {Moc}";
        }
    }
}

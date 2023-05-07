using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dziedziczenie.klasy
{
    class Autobus : Pojazd
    {
        public int Miejsca = 10;

        public Autobus(string marka, string kolor):base(marka, kolor)
        {
        }

        public Autobus(string marka, string kolor, int moc, int miejsca):base(marka, kolor, moc)
        {
            Miejsca = miejsca;
        }

        public override void Info()
        {
            LiczbaPojazdów--;
            Console.WriteLine("Jestem Autobusem");
            base.Info();
            Console.WriteLine($"\tdostępne miejsca: {Miejsca}");
        }
    }
}

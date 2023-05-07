using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dziedziczenie.klasy
{
    class Pojazd
    {
        public int Moc = 2;
        public string Marka;
        public string Kolor;

        public static int LiczbaPojazdów = 0;

        public Pojazd(string marka, string kolor)
        {
            Marka = marka;
            Kolor = kolor;
            LiczbaPojazdów++;
        }

        public Pojazd(string marka, string kolor, int moc)
        {
            Marka = marka;
            Kolor = kolor;
            Moc = moc;
            LiczbaPojazdów++;
        }

        public virtual void Info()
        {
            Console.WriteLine($"Marka: {Marka}\n\tKolor: {Kolor}\n\tMoc: {Moc}");
        }
    }
}

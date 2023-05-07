using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> oceny = new List<int>();

            while (true)
            {
                Console.WriteLine("Podaj ocene:");
                string line = Console.ReadLine();

                if (line.ToLower() == "koniec")
                    break;

                oceny.Add(int.Parse(line));
            }



            Console.ReadKey();
        }
    }
}

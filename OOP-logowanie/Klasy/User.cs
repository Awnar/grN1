using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_logowanie.Klasy
{
    class User
    {
        public string nick;
        public string pass;
        public string email;
        public int wiek;

        public string Hej()
        {
            return $"Witaj, {nick}";
        }
    }
}

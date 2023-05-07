using OOP_logowanie.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_logowanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] poprawnyNick = new string[] { "Maciej", "Adam" };
            string[] poprawneHasło = new string[] { "Giganci2023", "PG@023" };

            User user = new User();
            user.nick = "Maciej";
            user.pass = "Giganci2023";
            user.email = "admin@admin.pl";
            user.wiek = 30;

            User[] users = new User[10];
            users[0] = user;

            if (user.nick == tbNick.Text && user.pass == tbPass.Text)
            {
                MessageBox.Show(user.Hej());
                return;
            }

            //for (int i = 0; i < poprawneHasło.Length; i++)
            //    if (poprawnyNick[i] == tbNick.Text && poprawneHasło[i] == tbPass.Text)
            //    {
            //        MessageBox.Show("Zalogowany");
            //        return;
            //    }
            //MessageBox.Show("Złe dane");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraMemory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerujKarty();
            timerCzasGry.Start();
        }

        private void GenerujKarty()
        {
            string folderZExe = AppDomain.CurrentDomain.BaseDirectory;
            string[] obrazki = Directory.GetFiles(folderZExe + $@"\obrazki\karty");

            string tyl = folderZExe + $@"\obrazki\logo.jpg";

            List<MemoryCard> karty = new List<MemoryCard>();
            
            foreach(string img in obrazki)
            {
                Guid id = Guid.NewGuid();
                MemoryCard k1 = new MemoryCard(id, tyl, img);
                karty.Add(k1);

                MemoryCard k2 = new MemoryCard(id, tyl, img);
                karty.Add(k2);
            }

            Random random = new Random();
            //4x6

            for(int x = 0; x < 6; x++)
            {
                for(int y = 0; y < 4; y++)
                {
                    int index = random.Next(0, karty.Count);

                    MemoryCard card = karty[index];

                    card.Location = new Point((x*100)+(x*2), (y*100)+(y*2));

                    card.Width = 100;
                    card.Height = 100;

                    card.Zakryj();

                    panelGry.Controls.Add(card);
                    card.Click += BtnClick;

                    karty.Remove(card);
                }
            }

        }

        private MemoryCard _pierwsza, _druga;
        private int punkty;

        private void BtnClick(object sender, EventArgs e)
        {
            MemoryCard karta = (MemoryCard)sender;
            
            if(_pierwsza == null)
            {
                _pierwsza = karta;
                _pierwsza.Odkryj();
            }
            else
            {
                _druga = karta;
                _druga.Odkryj();
                panelGry.Enabled = false;

                if(_pierwsza.Id == _druga.Id)
                {
                    lblPunktyWartośc.Text = (++punkty).ToString();

                    _pierwsza = null;
                    _druga = null;

                    panelGry.Enabled = true;
                }
                else
                {
                    timerZakrywacz.Start();
                }

            }
        }

        private void timerZakrywacz_Tick(object sender, EventArgs e)
        {
            _pierwsza.Zakryj();
            _druga.Zakryj();

            _pierwsza = null;
            _druga = null;

            panelGry.Enabled = true;

            timerZakrywacz.Stop();
        }

        private int CzasGry = 120;

        private void timerCzasGry_Tick(object sender, EventArgs e)
        {
            CzasGry--;
            lblCzasWartośc.Text = CzasGry.ToString();

            if (CzasGry<=0 || punkty == 12)
            {
                timerCzasGry.Stop();
                timerZakrywacz.Stop();

                panelGry.Enabled = false;

                DialogResult yesNo = MessageBox.Show(
                    $"Zdobyte punkty: {punkty}. \nGrasz ponownie?",
                    "Koniec gry",
                    MessageBoxButtons.YesNo);

                if (yesNo == DialogResult.Yes)
                {
                    CzasGry = 120;
                    GenerujKarty();
                    panelGry.Enabled = true;
                    _pierwsza = null;
                    _druga = null;

                    timerCzasGry.Start();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

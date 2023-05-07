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

                    card.Odkryj();

                    panelGry.Controls.Add(card);

                    karty.Remove(card);
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
            // wywołujemy metodę, która utworzy karty do odkrywania
            GenerujKarty();
            // startujemy pierwszy timer, którego zadaniem jest odliczanie do rozpoczęcia gry
            timerCzasGry.Start();
        }

        // metoda generująca karty oraz losowo układjąca je po panelu gry
        private void GenerujKarty()
        {
            // pobieramy lokalizacje naszej aplikacji
            string folderZExe = AppDomain.CurrentDomain.BaseDirectory;

            // pobieramy ściezki do plików z obrazkami
            string[] obrazki = Directory.GetFiles(folderZExe + $@"\obrazki\karty");
            string tyl = folderZExe + $@"\obrazki\logo.jpg";

            // tworzymy listę na karty do gry
            List<MemoryCard> karty = new List<MemoryCard>();

            // dla każdego z obrazka tworzymy po dwie karty
            foreach (string img in obrazki)
            {
                // twrzymy unikalny identyfikator dla karty
                Guid id = Guid.NewGuid();
                // tworzymy pierszą kartę
                MemoryCard k1 = new MemoryCard(id, tyl, img);
                // i dodajemy ją do listy
                karty.Add(k1);

                // tworzymy drugą kartę
                MemoryCard k2 = new MemoryCard(id, tyl, img);
                karty.Add(k2);
            }

            // tworzymy generator liczb pseudolosowych
            // wykorzystamy go do losowego rozmieszczania kart na panelu
            Random random = new Random();

            // czyściemy panel z wszystkich kart
            // mogę się w nim jakieś znajdować, ponieważ tą samą metodę
            // wykorzystujemy do restartowania gry
            panelGry.Controls.Clear();

            // robimy pętlę po wszystkich kolumnach
            for (int x = 0; x < 6; x++)
            {
                // robimy pętlę po wszystkich wierszach
                // w ten sposób stworzy nam się siatka 2D z rozmieszczonymi kartami
                for (int y = 0; y < 4; y++)
                {
                    // losujemy indeks kolejnej karty z zakresu od zera 
                    // do ilości wszystkich pozostałych do rozlosowania kart
                    int index = random.Next(0, karty.Count);

                    // pobieramy z listy kartę o wylosowanym indeksie
                    MemoryCard card = karty[index];

                    // obliczamy pozycję x i y na panelu pod którą zostanie umieszzona karta
                    // x wyznaczamy mnożąc wiersz w którym jesteśmy przez długość boku
                    // dodając dwa razy margines (po lewej i po prawej)
                    // y wyznaczamy mnoząc kolumnę w której jesteśmy przez długość boku 
                    //dodając dwa razy margines (u góry i u dołu)
                    card.Location = new Point((x*100)+(x*2), (y*100)+(y*2));

                    // ustawiamy wielkość karty
                    card.Width = 100;
                    card.Height = 100;

                    // zakrywamy startowo kartę
                    card.Zakryj();

                    // dodajemy przygotowaną kartę do panelu gry
                    panelGry.Controls.Add(card);

                    // ta linijska do zdarzenia kliknięcia przypisuje metodę btnClick
                    card.Click += BtnClick;

                    // na samym końcu usuwamy z listy kartę, aby nie została ponowanie dodana
                    karty.Remove(card);
                }
            }

        }

        // zmienne pomocnicze na odkrywane karty
        private MemoryCard _pierwsza, _druga;
        private int punkty;

        // metoda podpięta pod zdarzenie kliknięcie każdej z kart
        // jej zadaniem jest sprawdzanie czy odkrywane karty zostały dopasowane
        // i w zalezności od tego zarządzać ich chowaniem,
        // a jeżeli zgadliśmy to zwiększenie punktów i pozostawienie 
        // kart odkrytych
        private void BtnClick(object sender, EventArgs e)
        {
            // sender to kontrolka, która wywołała zdarzenie
            // ponieważ metoda jest podpięta tylko pod karty do gry
            // możemy zrzutować object na MemoryCard, bo wiemy, że nie może to być nic innego
            MemoryCard karta = (MemoryCard)sender;

            // w pierwszej kolejności sprawdzamy czy pierwsza karta została odkryta
            // czyli czy została przypisana do zmiennej pierwsza
            if (_pierwsza == null)
            {
                // jeżeli nie to znaczy, że jest to pierwsza odkrywana karta
                // przypisujemy ją do zmiennej pomocniczej
                _pierwsza = karta;
                // oraz odkrywamy
                _pierwsza.Odkryj();
            }
            else
            {
                // jeżeli pierwsza karta jest ustawiona, 
                // to znaczy, że aktualnie odkryliśmy drugą
                // przypisujemy ją do zmiennej pomocniczej
                _druga = karta;
                // i odkrywamy
                _druga.Odkryj();
                // wyłączamy na chwilę możliwość klikania po panelu gry
                panelGry.Enabled = false;

                // sprawdzamy czy obie odkryte karty mają ten sam obrazek
                // czyli czy ich identyfikatory są sobie równe
                if (_pierwsza.Id == _druga.Id)
                {
                    // jeżeli tak to udało nam się odgadnąć
                    // zwiększamy ilość zdobytych punktów o 1
                    // oraz odrazu aktualizujemy labelkę wyświetlającą punkty
                    lblPunktyWartośc.Text = (++punkty).ToString();

                    // czyścimy zmienne pomocnicze
                    _pierwsza = null;
                    _druga = null;

                    // i odblokowujemy panel gry
                    panelGry.Enabled = true;
                }
                else
                {
                    // w przeciwnym razie nie udało nam się dopasować kart
                    // uruchamiamy timer zakrywacz, który po chwili zakryje obie karty i odblokuje panel
                    timerZakrywacz.Start();
                }

            }
        }

        // metoda timera Zakrywacz, którego zadaniem jest zakrycie dwóch niedopasowanych kart
        // dzięki zastosowaniu do tego timera, dajemy graczowi czas na przyjrzenie się drugiej
        // odkrytej karcie
        private void timerZakrywacz_Tick(object sender, EventArgs e)
        {
            // zakrywamy obie karty
            _pierwsza.Zakryj();
            _druga.Zakryj();

            // czyścimy zmienne pomocnicze przypisując im wartość null
            _pierwsza = null;
            _druga = null;

            // aktywujemy panel gry, który został zamrożony na czas podglądu odkrytych kart
            panelGry.Enabled = true;

            // zatrzymujemy timer Zakrywacz, ponieważ chcemy,
            // żeby uruchomił się tylko raz na rządanie
            timerZakrywacz.Stop();
        }

        private int CzasGry = 120;
        // metoda timera CzasGry, która wywołuje się co jedną sekundę
        // jej zadaniem jest zmniejszanie czasu gry oraz sprawdzanie
        // czy gra nie powinna się juz zakończyć
        private void timerCzasGry_Tick(object sender, EventArgs e)
        {
            // zmniejszamy czas gry o jeden
            CzasGry--;
            // aktualizujemy labelkę wyświetlającą ten czas
            lblCzasWartośc.Text = CzasGry.ToString();

            // sprawdzamy czy nie nastąpił koniec gry z jednego z dwóch powodów
            // - skończył się czas gry
            // lub odkryliśmy wszystkie karty - czyli zostały zdobyte wszystkie możliwe punkty
            if (CzasGry<=0 || punkty == 12)
            {
                // jeżeli tak to zatrzymujemy timer CzasGry oraz timer Zakrywacz
                timerCzasGry.Stop();
                timerZakrywacz.Stop();
                // możemy ty,czasowo zaqblokować karty
                panelGry.Enabled = false;

                // wyświetlamy MessageBox z wynikiem i zapytaniem czy rozpocząć grę od nowa
                // wynik, który z przycisków został kliknięty zapisujemy do zmiennej
                DialogResult yesNo = MessageBox.Show(
                    $"Zdobyte punkty: {punkty}. \nGrasz ponownie?",
                    "Koniec gry",
                    MessageBoxButtons.YesNo);

                // sprawdzamy czy wybrano "Yes"
                if (yesNo == DialogResult.Yes)
                {
                    // jeżeli tak to musimy zrestartować ustawienia gry
                    // i wygenerować nową kolejnośc kart
                    CzasGry = 120;
                    punkty = 0;
                    lblCzasWartośc.Text = CzasGry.ToString();
                    lblPunktyWartośc.Text = "0";
                    GenerujKarty();
                    panelGry.Enabled = true;
                    _pierwsza = null;
                    _druga = null;

                    // startujemy ponownie timer CzasPodglądu
                    timerCzasGry.Start();
                }
                else
                {
                    // jezeli wybrano nie to zamykamy program
                    Application.Exit();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using tfmarkt.Produktklassen;

namespace tfmarkt
{
    /// <summary>
    /// Interaktionslogik für TapetenBerechnung.xaml
    /// </summary>
    public partial class TapetenBerechnung : Window
    {
        // Attribute
        Tapete tapete;
        Berechnung berechnung;
        MainWindow mainwindow;
        double wandhoehe;
        double wandbreite;
        double flaeche;
        int anzahlTapetenrollen;
        int anzahlKleisterpackungen;

        // Konstruktor
        public TapetenBerechnung(Tapete tapete, MainWindow mainwindow)
        {
            InitializeComponent();

            this.tapete = tapete;
            this.berechnung = new Berechnung();
            this.mainwindow = mainwindow;

            tapeteBeschreibungTextBlock.Text += " Name:\t\t\t" + tapete.name + "\n";
            tapeteBeschreibungTextBlock.Text += " Artikelnummer:\t\t" + tapete.artikelnummer + "\n";
            tapeteBeschreibungTextBlock.Text += " Beschreibung:\t\t" + tapete.beschreibung + "\n";
            tapeteBeschreibungTextBlock.Text += " Preis:\t\t\t" + tapete.preis + " / Rolle" + "\n";
        }

        private void BerechnenButton(object sender, RoutedEventArgs e)
        {
            bool error = false;

            if (wandhoeheTapeten.Text == "")
            {
                wandhoeheTapeten.Background = Brushes.OrangeRed;
                error = true;
            }
            else
            {
                wandhoeheTapeten.Background = Brushes.White;

                if (Convert.ToDouble(wandhoeheTapeten.Text) <= 0)
                {
                    wandhoeheTapeten.Background = Brushes.OrangeRed;
                    error = true;
                }
                else
                {
                    wandhoeheTapeten.Background = Brushes.White;
                    error = false;
                }
            }

            if (wandbreiteTapeten.Text == "")
            {
                wandbreiteTapeten.Background = Brushes.OrangeRed;
                error = true;
            }
            else
            {
                wandbreiteTapeten.Background = Brushes.White;

                if (Convert.ToDouble(wandbreiteTapeten.Text) <= 0)
                {
                    wandbreiteTapeten.Background = Brushes.OrangeRed;
                    error = true;
                }
                else
                {
                    wandbreiteTapeten.Background = Brushes.White;
                    error = false;
                }
            }






            if (error == false)
	        {
                wandbreiteTapeten.Background = Brushes.White;
                wandhoeheTapeten.Background = Brushes.White;

                this.wandhoehe = Convert.ToDouble(wandhoeheTapeten.Text);
                this.wandbreite = Convert.ToDouble(wandbreiteTapeten.Text);
                this.flaeche = wandbreite * wandhoehe;

                TapetenBerechnungWindow.Height = 450;
                berechnenButton.Content = "Aktualisieren";

                this.anzahlTapetenrollen = berechnung.TapetenBerechnen(flaeche, wandbreite, wandhoehe, tapete);
                this.anzahlKleisterpackungen = berechnung.TapetenkleisterBerechnen(this.tapete, this.flaeche, mainwindow.produktkatalog.tapetenkleister);

                ergebnisBox.Text = "";
                ergebnisBox.Text += "Ausgerechnete Gesamtfläche:\t" + flaeche + " m²" + "\n";
                ergebnisBox.Text += "Notwendige Tapetenrollen:\t\t" + " " + anzahlTapetenrollen + " Stück\n";
                ergebnisBox.Text += "Notwendige Kleisterpackungen:\t" + " " + anzahlKleisterpackungen + " Stück\n";		 
	        }
        }

        private void Abbrechen(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TapeteDemWarenkorbHinzufuegen(object sender, RoutedEventArgs e)
        {

            // Prüfen ob sich die Tapeten schon im Warenkorb befindet, wenn ja Anzahl updaten anstatt neu hinzufügen
            if (mainwindow.warenkorb.Any(x => x.Produkt.name == tapete.name))
            {
                var tapeteAusDemWarenkorb = mainwindow.warenkorb.Single(i => i.Produkt.name == tapete.name);
                tapeteAusDemWarenkorb.Anzahl += this.anzahlTapetenrollen;
            }
            else
            {
                mainwindow.warenkorb.Add(new WarenkorbObjekt(tapete, this.anzahlTapetenrollen));
            }

            // Prüfen ob sich der Tapetenkleister schon im Warenkorb befindet, wenn ja Anzahl updaten anstatt neu hinzufügen
            if (mainwindow.warenkorb.Any(x => x.Produkt.name == mainwindow.produktkatalog.tapetenkleister.name))
            {
                var tapetenkleister = mainwindow.warenkorb.Single(i => i.Produkt.name == mainwindow.produktkatalog.tapetenkleister.name);
                tapetenkleister.Anzahl += this.anzahlKleisterpackungen;
            }
            else
            {
                mainwindow.warenkorb.Add(new WarenkorbObjekt(mainwindow.produktkatalog.tapetenkleister, this.anzahlKleisterpackungen));
            }

            mainwindow.Warenkorb.ItemsSource = mainwindow.warenkorb;
            mainwindow.Warenkorb.Items.Refresh();
            MessageBox.Show("Zum Warenkorb hinzugefügt");
            this.Close();
        }
    }
}

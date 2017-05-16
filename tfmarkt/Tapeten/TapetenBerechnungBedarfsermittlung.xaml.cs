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

            tapeteBeschreibungTextBlock.Text += "Name:\t\t" + tapete.name + "\n";
            tapeteBeschreibungTextBlock.Text += "Artikelnummer:\t" + tapete.artikelnummer + "\n";
            tapeteBeschreibungTextBlock.Text += "Beschreibung:\t" + tapete.beschreibung + "\n";
            tapeteBeschreibungTextBlock.Text += "Preis:\t\t" + tapete.preis + " / Rolle" + "\n";
        }

        private void BerechnenButton(object sender, RoutedEventArgs e)
        {
            this.wandhoehe = Convert.ToDouble(wandhoeheTapeten.Text);
            this.wandbreite = Convert.ToDouble(wandbreiteTapeten.Text);
            this.flaeche = wandbreite * wandhoehe;

            TapetenBerechnungWindow.Height = 450;
            berechnenButton.Content = "Aktualisieren";

            this.anzahlTapetenrollen = berechnung.TapetenBerechnen(flaeche, tapete);
            this.anzahlKleisterpackungen = berechnung.ZusatzproduktBerechnen("Tapetenkleister", this.tapete);

            ergebnisBox.Text = "";
            ergebnisBox.Text += "Ausgerechnete Gesamtfläche:\t" + flaeche + " qm²" + "\n";
            ergebnisBox.Text += "Notwendige Tapetenrollen:\t\t" + " " + anzahlTapetenrollen  + " Stück\n";
            ergebnisBox.Text += "Notwendige Kleisterpackungen:\t" + " " + anzahlKleisterpackungen + " Stück\n";
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
                var fliesenkleber = mainwindow.warenkorb.Single(i => i.Produkt.name == "Tapetenkleister A");
                fliesenkleber.Anzahl += this.anzahlKleisterpackungen;
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

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
        ObservableCollection<Produkt> warenkorb;
        Tapete tapete;
        Berechnung berechnung;
        MainWindow mainwindow;

        public TapetenBerechnung(ObservableCollection<Produkt> warenkorb, Tapete tapete, MainWindow mainwindow)
        {
            InitializeComponent();

            this.warenkorb = warenkorb;
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
            double wandhoehe = Convert.ToDouble(wandhoeheTapeten.Text);
            double wandbreite = Convert.ToDouble(wandbreiteTapeten.Text);
            double flaeche = wandbreite * wandhoehe;

            TapetenBerechnungWindow.Height = 450;
            berechnenButton.Content = "Aktualisieren";

            double anzahlTapetenrollen = berechnung.TapetenBerechnen(flaeche, tapete);
            int anzahlKleisterpackungen = berechnung.ZusatzproduktBerechnen("Tapetenkleister", this.tapete);

            ergebnisBox.Text = "";
            ergebnisBox.Text += "Ausgerechnete Gesamtfläche:\t" + flaeche + " qm²" + "\n";
            ergebnisBox.Text += "Notwendige Tapetenrollen:\t\t" + " " + anzahlTapetenrollen  + " Stück\n";
            ergebnisBox.Text += "Notwendige Kleisterpackungen:\t" + " " + anzahlKleisterpackungen + " Stück\n";
        }

        private void Abbrechen(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ProduktDemWarenkorbHinzufuegen(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zum Warenkorb hinzugefügt");
            this.Close();
        }
    }
}

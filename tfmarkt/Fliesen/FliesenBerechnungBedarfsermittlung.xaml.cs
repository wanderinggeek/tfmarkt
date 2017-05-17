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
using tfmarkt.Produktklassen;


namespace tfmarkt.Fliesen
{
    /// <summary>
    /// Interaktionslogik für FliesenBerechnungBedarfsermittlung.xaml
    /// </summary>
    public partial class FliesenBerechnungBedarfsermittlung : Window
    {
        // Attribute
        Fliese fliese;
        Berechnung berechnung;
        MainWindow mainwindow;
        double bodenlaenge;
        double bodenbreite;
        double flaeche;
        double fugenbreite;
        int anzahlFliesenpakete;
        int anzahlFliesenkleber;
        int anzahlFugenfueller;
        bool fliesenkleberSelected;

        // Konstruktor
        public FliesenBerechnungBedarfsermittlung(Fliese fliese, MainWindow mainwindow)
        {
            InitializeComponent();

            this.fliese = fliese;
            this.berechnung = new Berechnung();
            this.mainwindow = mainwindow;

            flieseBeschreibungTextBlock.Text += " Name:\t\t\t" + fliese.name + "\n";
            flieseBeschreibungTextBlock.Text += " Artikelnummer:\t\t" + fliese.artikelnummer + "\n";
            flieseBeschreibungTextBlock.Text += " Beschreibung:\t\t" + fliese.beschreibung + "\n";
            flieseBeschreibungTextBlock.Text += " Preis:\t\t\t" + fliese.preis + " / Paket" + "\n";
        }

        private void BerechnenButton(object sender, RoutedEventArgs e)
        {
            bool error = false;

            if (bodenlaengeFliesen.Text == "")
            {
                bodenlaengeFliesen.Background = Brushes.OrangeRed;
                error = true;
            }
            else
            {
                bodenlaengeFliesen.Background = Brushes.White;

                if (Convert.ToDouble(bodenbreiteFliesen.Text) <= 0)
                {
                    bodenlaengeFliesen.Background = Brushes.OrangeRed;
                    error = true;
                }
                else
                {
                    bodenlaengeFliesen.Background = Brushes.White;
                }
            }

            if (bodenbreiteFliesen.Text == "")
            {
                bodenbreiteFliesen.Background = Brushes.OrangeRed;
                error = true;
            }
            else
            {
                bodenbreiteFliesen.Background = Brushes.White;

                if (Convert.ToDouble(bodenbreiteFliesen.Text) <= 0)
                {
                    bodenbreiteFliesen.Background = Brushes.OrangeRed;
                    error = true;
                }
                else
                {
                    bodenbreiteFliesen.Background = Brushes.White;
                }
            }

            if (error == false)
            {
                this.bodenlaenge = Convert.ToDouble(bodenlaengeFliesen.Text);
                this.bodenbreite = Convert.ToDouble(bodenbreiteFliesen.Text);
                this.flaeche = bodenbreite * bodenlaenge;
                this.fugenbreite = Convert.ToDouble(fugenbreiteTextbox.Text);
                
                FliesenberechnungWindow.Height = 540;
                berechnenButton.Content = "Aktualisieren";

                this.anzahlFliesenpakete = berechnung.FliesenBerechnen(this.flaeche, fliese, fugenbreite);
                this.anzahlFugenfueller = berechnung.FugenfuellerBerechnen(this.flaeche, mainwindow.produktkatalog.fugenfueller);
                this.anzahlFliesenkleber = berechnung.FliesenkleberBerechnen(this.flaeche, mainwindow.produktkatalog.fliesenkleber);

                ergebnisBox.Text = "";
                ergebnisBox.Text += "Gesamtfläche des Bodens:\t\t" + flaeche + " m²" + "\n";
                ergebnisBox.Text += "Notwendige Fliesenpakete:\t\t" + anzahlFliesenpakete + " Stück\n";
                ergebnisBox.Text += "Notwendige Fugenfüller: \t\t"  + anzahlFugenfueller + " Stück\n";
                if (fliesenkleberSelected)
                {
                    ergebnisBox.Text += "Notwendige Fliesenkleber: \t\t" + anzahlFliesenkleber + " Stück\n";
                }
            }
        }

        private void Abbrechen(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FlieseDemWarenkorbHinzufuegen(object sender, RoutedEventArgs e)
        {

            // Prüfen ob sich die Tapeten schon im Warenkorb befindet, wenn ja Anzahl updaten anstatt neu hinzufügen
            if (mainwindow.warenkorb.Any(x => x.Produkt.name == fliese.name))
            {
                var flieseAusDemWarenkorb = mainwindow.warenkorb.Single(i => i.Produkt.name == fliese.name);
                flieseAusDemWarenkorb.Anzahl += this.anzahlFliesenpakete;
            }
            else
            {
                mainwindow.warenkorb.Add(new WarenkorbObjekt(fliese, this.anzahlFliesenpakete));
            }

            // Prüfen ob sich der Tapetenkleister schon im Warenkorb befindet, wenn ja Anzahl updaten anstatt neu hinzufügen
            if (mainwindow.warenkorb.Any(x => x.Produkt.name == mainwindow.produktkatalog.fugenfueller.name))
            {
                var fugenfueller = mainwindow.warenkorb.Single(i => i.Produkt.name == mainwindow.produktkatalog.fugenfueller.name);
                fugenfueller.Anzahl += this.anzahlFugenfueller;
            }
            else
            {
                mainwindow.warenkorb.Add(new WarenkorbObjekt(mainwindow.produktkatalog.fugenfueller, this.anzahlFugenfueller));
            }

            mainwindow.Warenkorb.ItemsSource = mainwindow.warenkorb;
            mainwindow.Warenkorb.Items.Refresh();
            MessageBox.Show("Zum Warenkorb hinzugefügt");
            this.Close();
        }


        private void KleberBox_OnChecked(object sender, RoutedEventArgs e)
        {
            fliesenkleberSelected = true;
        }

        private void KleberBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            fliesenkleberSelected = false;
        }
    }
}

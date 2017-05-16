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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using tfmarkt.Produktklassen;

namespace tfmarkt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<WarenkorbObjekt> warenkorb;
        public Verwaltung verwaltungGui;
        public FliesenGUI fliesenGui;
        public TapetenGUI tapetenGui;
        Berechnung berechnung;
        public ProduktKatalog produktkatalog;

        public MainWindow()
        {
            InitializeComponent();

            // Später den Produktkatalog als Parameter für Berechnung übergeben
            this.berechnung = new Berechnung();
            this.produktkatalog = new ProduktKatalog();

            GetProdukte();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (TapetenTab.IsSelected)
            //    {
            //        if (tapetenGui == null)
            //        {
            //           tapetenGui = new TapetenGUI();
            //        }
            //        TapetenTab.Content = tapetenGui.Content;
            //    }

            if (VerwaltungTab.IsSelected)
                {
                    if (verwaltungGui == null)
                    {
                        verwaltungGui = new Verwaltung();
                    }
                    VerwaltungTab.Content = verwaltungGui.Content;
                }

            //if (FliesenTab.IsSelected)
            //     {
            //         if (fliesenGui == null)
            //         {
            //             fliesenGui = new FliesenGUI();
            //         }
            //         FliesenTab.Content = fliesenGui;
            //     }                    
        }

        private void GetProdukte()
        {
            // Liste mit Testdaten, wird im DataGrid des Hauptmenues angezeigt
            warenkorb = new ObservableCollection<WarenkorbObjekt>();
            //warenkorb.Add(new Tapete(1.99, "Fancy Tapete", 11111111, "Hui", 10, 10, 10));
            //warenkorb.Add(new Tapetenkleister(1.49, "Meister Kleister", 22222222, "Toller Tapetenkleister", 26));
            //warenkorb.Add(new Fugenfueller(1.49, "Fugenfüller Fugi", 33333333, "Fugenfüller, das Original", 300));
            //warenkorb.Add(new Fliesenkleber(1.49, "Sticky Fliesenkleber", 44444444, "Klebt super!", 300, true));
            //produkte.Clear();
            Warenkorb.ItemsSource = warenkorb;

            // Produktkatalog einlesen
            produktkatalog = produktkatalog.ProdukteEinlesen();
            Tapeten.ItemsSource = produktkatalog.tapeten;
            Fliesen.ItemsSource = produktkatalog.fliesen;
        }

        private void EntferneProduktAusWarenkorb(object sender, RoutedEventArgs e)
        {
            // Ausgewähltes Produkt aus dem Warenkorb löschen
            WarenkorbObjekt warenkorbObjekt = (WarenkorbObjekt)Warenkorb.SelectedItem;
            warenkorb.Remove(warenkorbObjekt);
            Warenkorb.Items.Refresh();

            // Später ausformulieren: Preis für entfernten Warenkorbposten ermitteln
            // Anzahl des Produkts * Preis des Produkts
            berechnung.GesamtBetragAktualisieren(0, "Abziehen");
        }

        private void erstelleGesamtrechnung(object sender, RoutedEventArgs e)
        {
            // Gesamtrechnung erstellen
            MessageBox.Show("Neues Fenster für Gesamtrechnung");
        }

        private void kalkulationAbbrechen(object sender, RoutedEventArgs e)
        {
            // Kalkulation abbrechen, alle Werte auf Standard zurücksetzen
            warenkorb.Clear();
            Warenkorb.Items.Refresh();
        }

        private void TapetenBerechnungStarten(object sender, RoutedEventArgs e)
        {
            // Fenster für Tapetenberechnung öffnen
            Tapete tapete = (Tapete)Tapeten.SelectedItem;

            TapetenBerechnung tapetenberechnung = new TapetenBerechnung(tapete, this);
            tapetenberechnung.Show();
        }

        private void FliesenBerechnungStarten(object sender, RoutedEventArgs e)
        {
            // Fenster für Fliesenberechnung öffnen
            Fliese fliese = (Fliese)Fliesen.SelectedItem;
            MessageBox.Show(fliese.name);
        }
    }
}

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
        public ObservableCollection<Produkt> produkte;
        public Verwaltung verwaltungGui;
        public FliesenGUI fliesenGui;
        public TapetenGUI tapetenGui;


        public MainWindow()
        {
            InitializeComponent();
            GetProdukte();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
                    {
                      
                        if (TapetenTab.IsSelected)
                            {
                                if (tapetenGui == null)
                                {
                                   tapetenGui = new TapetenGUI();
                                }
                                TapetenTab.Content = tapetenGui.Content;
                            }
                        if (VerwaltungTab.IsSelected)
                            {
                                if (verwaltungGui == null)
                                {
                                    verwaltungGui = new Verwaltung();
                                }
                                VerwaltungTab.Content = verwaltungGui.Content;
                            }
                       if (FliesenTab.IsSelected)
                            {
                                if (fliesenGui == null)
                                {
                                    fliesenGui = new FliesenGUI();
                                }
                                FliesenTab.Content = fliesenGui;
                            }                    
        }

        private void GetProdukte()
        {
            // Liste mit Testdaten, wird im DataGrid des Hauptmenues angezeigt
            produkte = new ObservableCollection<Produkt>();
            produkte.Add(new Tapete(1.99, "Fancy Tapete", 11111111, "Hui", 10, 10, 10));
            produkte.Add(new Tapetenkleister(1.49, "Meister Kleister", 22222222, "Toller Tapetenkleister", 26));
            produkte.Add(new Fugenfueller(1.49, "Fugenfüller Fugi", 33333333, "Fugenfüller, das Original", 300));
            produkte.Add(new Fliesenkleber(1.49, "Sticky Fliesenkleber", 44444444, "Klebt super!", 300, true));

            //produkte.Clear();
            Warenkorb.ItemsSource = produkte;
        }

        private void loescheProdukt(object sender, RoutedEventArgs e)
        {
            // Ausgewähltes Produkt aus dem Warenkorb löschen
            Produkt produkt = (Produkt)Warenkorb.SelectedItem;
            produkte.Remove(produkt);
            Warenkorb.Items.Refresh();
        }

        private void erstelleGesamtrechnung(object sender, RoutedEventArgs e)
        {
            // Gesamtrechnung erstellen
            MessageBox.Show("Neues Fenster für Gesamtrechnung");
            Tapetenkleister TP = new Tapetenkleister(1.00, "TK Name", 1111, "Beschreibung", 26);
        }

        private void kalkulationAbbrechen(object sender, RoutedEventArgs e)
        {
            // Kalkulation abbrechen, alle Werte auf Standard zurücksetzen
            produkte.Clear();
            Warenkorb.Items.Refresh();
        }
    }
}

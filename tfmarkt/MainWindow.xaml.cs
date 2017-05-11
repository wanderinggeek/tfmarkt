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

        public MainWindow()
        {
            InitializeComponent();
            GetProdukte();
        }

        private void GetProdukte()
        {
            // Liste mit Testdaten, wird im DataGrid des Hauptmenues angezeigt
            produkte = new ObservableCollection<Produkt>();
            produkte.Add(new Tapete(1.99, "Tapete A", 12345678, "Beschreibung", 10, 10, 10));
            produkte.Add(new Tapete(2.99, "Tapete B", 11111111, "Beschreibung", 20, 20, 20));
            produkte.Add(new Tapete(3.99, "Tapete C", 22222222, "Beschreibung", 30, 30, 30));
            produkte.Add(new Tapete(4.99, "Tapete D", 33333333, "Beschreibung", 40, 40, 40));
            produkte.Add(new Tapete(5.99, "Tapete E", 44444444, "Beschreibung", 50, 50, 50));
            produkte.Add(new Tapete(6.99, "Tapete F", 55555555, "Beschreibung", 60, 60, 60));
            produkte.Add(new Tapete(7.99, "Tapete G", 66666666, "Beschreibung", 70, 70, 70));
            produkte.Add(new Tapete(8.99, "Tapete H", 77777777, "Beschreibung", 80, 80, 80));
            //produkte.Clear();
            Produktliste.ItemsSource = produkte;
        }

        private void loescheProdukt(object sender, RoutedEventArgs e)
        {
            var items = Produktliste.SelectedItems;

            // Mehrere Items löschen (funktioniert nicht)
            //foreach (Produkt item in items)
            //{
            //    produkte.Remove(item);
            //}

            // Einzelnes Item löschen
            Produkt test = (Produkt)Produktliste.SelectedItem;
            produkte.Remove(test);
            Produktliste.Items.Refresh();
        }

        private void erstelleGesamtrechnung(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Neues Fenster für Gesamtrechnung");   
        }

        private void kalkulationAbbrechen(object sender, RoutedEventArgs e)
        {
            produkte.Clear();
            Produktliste.Items.Refresh();
        }
    }
}

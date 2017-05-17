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
using System.Xml.Serialization;
using System.IO;

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
        public Passwortdialog passwortdialog;

        public MainWindow()
        {
            InitializeComponent();

            // Fenster wird zentriert dargestellt
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.berechnung = new Berechnung();
            this.produktkatalog = new ProduktKatalog();
            this.warenkorb = new ObservableCollection<WarenkorbObjekt>();
            this.passwortdialog = new Passwortdialog(this);
            produktkatalog = produktkatalog.ProdukteEinlesen();
            Tapeten.ItemsSource = produktkatalog.tapeten;
            Fliesen.ItemsSource = produktkatalog.fliesen;

            // Test
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            //this.warenkorb.Add(new WarenkorbObjekt(new Tapete(5.99m, "GesamtrechnungTest", 12345678, "Blabla", 10.05, 0.53, 0.72), 2));
            
            //this.Warenkorb.ItemsSource = this.warenkorb;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VerwaltungTab.IsSelected && verwaltungGui == null)
            {
                if (!passwortdialog.passGueltig)
                {
                    passwortdialog = new Passwortdialog(this);

                    // Position des Popup Fenster relativ zum Hauptfenster setzen
                    passwortdialog.Top = this.Top + 140;
                    passwortdialog.Left = this.Left + 230;

                    passwortdialog.Show();
                }
               

                if (passwortdialog.passGueltig)
                {
                    ladeVerwaltung();
                }            
            
            }
        }

        public void ladeVerwaltung()
        {
            verwaltungGui = new Verwaltung(this);
            VerwaltungTab.Content = verwaltungGui.Content;
        }

        private void EntferneProduktAusWarenkorb(object sender, RoutedEventArgs e)
        {
            if (warenkorb.Count >= 1)
            {
                if (Warenkorb.SelectedIndex != -1)
                {
                    MessageBoxResult rsltMessageBox = MessageBox.Show("Produkt aus Warenkorb löschen?", "TF Kalkulation", MessageBoxButton.YesNo);

                    switch (rsltMessageBox)
                    {
                        case MessageBoxResult.Yes:
                            // Ausgewähltes Produkt aus dem Warenkorb löschen
                            WarenkorbObjekt warenkorbObjekt = (WarenkorbObjekt)Warenkorb.SelectedItem;
                            warenkorb.Remove(warenkorbObjekt);
                            Warenkorb.Items.Refresh();
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Kein Produkt zum Löschen ausgewählt");
                }
            }
            else
            {
                MessageBox.Show("Keine Produkte im Warenkorb vorhanden");
            }

        }

        private void WarenkorbLoeschen(object sender, RoutedEventArgs e)
        {
            if (warenkorb.Count >= 1)
            {
                MessageBoxResult rsltMessageBox = MessageBox.Show("Warenkorb wirklich löschen?", "TF Kalkulation", MessageBoxButton.YesNo);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        // Kalkulation abbrechen, alle Werte auf Standard zurücksetzen nötig?           
                        warenkorb.Clear();
                        Warenkorb.Items.Refresh();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Keine Produkte im Warenkorb vorhanden");
            }
        }

        private void erstelleGesamtrechnung(object sender, RoutedEventArgs e)
        {
            if (warenkorb.Count >= 1)
            {
                // Gesamtrechnung erstellen
                decimal gesamtbetrag = berechnung.GesamtbetragBerechnen(warenkorb);
                decimal mehrwertsteuer = berechnung.SteuerBerechnen(gesamtbetrag);

                Gesamtrechnung gesamtrechnung = new Gesamtrechnung(warenkorb, gesamtbetrag, mehrwertsteuer);
                gesamtrechnung.Top = this.Top - 100;
                gesamtrechnung.Left = this.Left + 50;
                gesamtrechnung.Show();
            }
            else
            {
                MessageBox.Show("Keine Produkte im Warenkorb vorhanden");
            }
        }

        private void WarenkorbSpeichern(object sender, RoutedEventArgs e)
        {
            if (warenkorb.Count >= 1)
            {
                //XmlSerializer xs = new XmlSerializer(typeof(WarenkorbObjekt));
                //using (StreamWriter wr = new StreamWriter("warenkorb.xml"))
                //{
                //    xs.Serialize(wr, warenkorb);
                //}
                Type[] typen = {
                                   typeof(Produkt), 
                                   typeof(Tapete),
                                   typeof(Tapetenkleister)
                                 
                               };

                var serializer = new XmlSerializer(
                    typeof(ObservableCollection<WarenkorbObjekt>),
                    typen
                );
                TextWriter writer = new StreamWriter("warenkorb.xml");
                serializer.Serialize(writer, warenkorb);
                writer.Close();
            }
            else
            {
                MessageBox.Show("Keine Produkte im Warenkorb vorhanden");
            }
        }

        private void TapetenBerechnungStarten(object sender, RoutedEventArgs e)
        {
            if (Tapeten.SelectedIndex != -1)
            {
                // Fenster für Tapetenberechnung öffnen
                Tapete tapete = (Tapete)Tapeten.SelectedItem;

                TapetenBerechnung tapetenberechnung = new TapetenBerechnung(tapete, this);

                // Position des Popup Fenster relativ zum Hauptfenster setzen
                tapetenberechnung.Top = this.Top + 140;
                tapetenberechnung.Left = this.Left + 230;

                tapetenberechnung.Show();                
            }
            else
            {
                MessageBox.Show("Keine Tapete ausgewählt");
            }
        }

        private void FliesenBerechnungStarten(object sender, RoutedEventArgs e)
        {
            // Fenster für Fliesenberechnung öffnen
            Fliese fliese = (Fliese)Fliesen.SelectedItem;
            MessageBox.Show(fliese.name);
        }
    }
}

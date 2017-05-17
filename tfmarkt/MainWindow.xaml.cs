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
using tfmarkt.Fliesen;
using tfmarkt.Produktklassen;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;

namespace tfmarkt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<WarenkorbObjekt> warenkorb;
        public Verwaltung verwaltungGui;
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

        public void loadProduktkatalog()
        {
            produktkatalog = produktkatalog.ProdukteEinlesen();
            this.Tapeten.ItemsSource = produktkatalog.tapeten;
            this.Fliesen.ItemsSource = produktkatalog.fliesen;
            this.Tapeten.Items.Refresh();
            this.Fliesen.Items.Refresh();
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
                SaveFileDialog dialog = new SaveFileDialog()
                {
                    Filter = "XML Datei(*.xml)|*.xml"
                };

                if (dialog.ShowDialog() == true)
                {
                    Type[] typen = {
                                   typeof(Produkt), 
                                   typeof(Tapete),
                                   typeof(Tapetenkleister),
                                   typeof(Fliese),
                                   typeof(Fugenfueller),
                                   typeof(Fliesenkleber)
                               };

                    var serializer = new XmlSerializer(
                        typeof(ObservableCollection<WarenkorbObjekt>),
                        typen
                    );
                    TextWriter writer = new StreamWriter(dialog.FileName);
                    serializer.Serialize(writer, warenkorb);
                    writer.Close();
                }
            }
            else
            {
                MessageBox.Show("Keine Produkte im Warenkorb vorhanden");
            }
        }

        private void WarenkorbLaden(object sender, RoutedEventArgs e)
        {

            warenkorb.Clear();

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "XML Datei(*.xml)|*.xml"
            };

            if (dialog.ShowDialog() == true)
            {
                Type[] typen = {
                                typeof(Produkt), 
                                typeof(Tapete),
                                typeof(Tapetenkleister),
                                typeof(Fliese),
                                typeof(Fugenfueller),
                                typeof(Fliesenkleber)
                            };

                var serializer = new XmlSerializer(
                    typeof(ObservableCollection<WarenkorbObjekt>),
                    typen
                );
                FileStream writer = new FileStream(dialog.FileName, FileMode.Open);
                //serializer.Serialize(reader, warenkorb);
                warenkorb = (ObservableCollection<WarenkorbObjekt>)serializer.Deserialize(writer);
                writer.Close();
                this.Warenkorb.ItemsSource = warenkorb;
                this.Warenkorb.Items.Refresh();
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
            if (Fliesen.SelectedIndex != -1)
            {
                // Fenster für Tapetenberechnung öffnen
                Fliese fliese = (Fliese)Fliesen.SelectedItem;

                FliesenBerechnungBedarfsermittlung fliesenberechnung = new FliesenBerechnungBedarfsermittlung(fliese, this);

                // Position des Popup Fenster relativ zum Hauptfenster setzen
                fliesenberechnung.Top = this.Top + 140;
                fliesenberechnung.Left = this.Left + 230;

                fliesenberechnung.Show();
            }
            else
            {
                MessageBox.Show("Keine Fliese ausgewählt");
            }
        }

        public void InfoAnzeigen(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TF-Kalkulation\nVersion: 0.99");
        }

        public void ProgrammBeenden(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

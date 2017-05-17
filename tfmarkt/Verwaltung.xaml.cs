using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using tfmarkt.Produktklassen;
using System.Xml.Linq;
using System.Xml.XPath;


namespace tfmarkt
{
    /// <summary>
    /// Interaktionslogik für Verwaltung.xaml
    /// </summary>
    public partial class Verwaltung : UserControl
    {
        public ProduktKatalog produktKatalog;
        public bool aendereArtikel;
        public ObservableCollection<Produkt> produkteList;
        public Produkt ausgewaehltesProdukt; 

        public Verwaltung()
        {
            InitializeComponent();
            this.produktKatalog = new ProduktKatalog();
            this.aendereArtikel = false;
            this.produkteList = new ObservableCollection<Produkt>();
            LadeKatalog();
        }

        private void LadeKatalog()
        {
            //Hole produkte aus Katalog
            produktKatalog = produktKatalog.ProdukteEinlesen();
            List<Tapete> tapeten = produktKatalog.tapeten;

            //Baue List zur Darstellung
            foreach (var tapete in tapeten)
            {
                this.produkteList.Add(tapete);
            }

            List<Fliese> fliesen = produktKatalog.fliesen;

            foreach (var fliese in fliesen)
            {
                this.produkteList.Add(fliese);
            }

            if (produktKatalog.fliesenkleber != null)
            {
                this.produkteList.Add(produktKatalog.fliesenkleber);
            }

            if (produktKatalog.fugenfueller != null)
            {
                this.produkteList.Add(produktKatalog.fugenfueller);
            }

            if (produktKatalog.tapetenkleister != null)
            {
                this.produkteList.Add(produktKatalog.tapetenkleister);
            }

            //Setze Datenquelle für Grid
            VerwaltungsGrid.ItemsSource = this.produkteList;
        }

        private Boolean PasswortUeberpruefen(string passwort)
        {
            return true;
        }
        //Erstelle neues Produkt
        private void produktAnlegen(object sender, RoutedEventArgs e)
        {
            this.aendereArtikel = false;
            AendereErstelleProduktFenster erstelleProduktFenster = new AendereErstelleProduktFenster(aendereArtikel, produktKatalog, this);
            erstelleProduktFenster.Show();                               
        }


        //Ändere Produkt 
        public void produktAendern(object sender, RoutedEventArgs e)
        {
            ausgewaehltesProdukt = (Produkt)VerwaltungsGrid.SelectedItem;
            this.aendereArtikel = true;
            AendereErstelleProduktFenster erstelleProduktFenster = new AendereErstelleProduktFenster(this.aendereArtikel, produktKatalog, this, ausgewaehltesProdukt);
            erstelleProduktFenster.Show();
        }
        //Lösche Produkt 
        public void produktLoeschen(object sender, RoutedEventArgs e)
        {
            {
                if (!aendereArtikel)
                {
                    ausgewaehltesProdukt = (Produkt) VerwaltungsGrid.SelectedItem;

                }
                else
                {
                    ausgewaehltesProdukt = ausgewaehltesProdukt;
                }

                string produkttyp = ausgewaehltesProdukt.produkttyp;

                if (ausgewaehltesProdukt != null)
                {
                    var artikelnummer = ausgewaehltesProdukt.artikelnummer.ToString();

                    try
                    {
                        XDocument doc = XDocument.Load("produktkatalog.xml");
                        if (produkttyp == "Fliese" || produkttyp == "Tapete")
                        {
                            var xElements = doc.Descendants(produkttyp)
                                .Where(x => x.Element("artikelnummer").Value == artikelnummer);

                            xElements.Remove();
                        }
                        else
                        {
                            IEnumerable<XElement> foo = doc.Root.Elements();
                            foreach (XElement node in foo)
                            {
                                if (node.Element("produkttyp") !=null && node.Element("produkttyp").Value == produkttyp)
                                {
                                    node.Remove();
                                }
                            }
                        }

                        produktKatalog.artikelnummern.Remove(ausgewaehltesProdukt.artikelnummer);

                        doc.Save("produktkatalog.xml");
                        if (!aendereArtikel)
                        {
                            reloadKatalog();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }


                }
            }
          
        
        }

        //nur zum testen
        private void deleteXmlDoc()
        {
            File.WriteAllText("produktkatalog.xml", "");

        }

        private void VerwaltungsGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ausgewaehltesProdukt = (Produkt)VerwaltungsGrid.SelectedItem;

        }

        public void reloadKatalog()
        {
            this.produkteList = new ObservableCollection<Produkt>();           
            LadeKatalog();
            VerwaltungsGrid.Items.Refresh();
        }
    }
}

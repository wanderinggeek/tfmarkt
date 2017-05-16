﻿using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace tfmarkt
{
    /// <summary>
    /// Interaktionslogik für AendereErstelleProduktFenster.xaml
    /// </summary>
    public partial class AendereErstelleProduktFenster : Window
    {
        private string produktTyp;
        private bool aendereArtikel;
        private ProduktKatalog produktKatalog;
        private Verwaltung verwaltung;

        public AendereErstelleProduktFenster(bool aendereArtikel, ProduktKatalog produktKatalog, Verwaltung verwaltung, dynamic produkt = null)
        {
            InitializeComponent();

            this.aendereArtikel = aendereArtikel;
            this.produktKatalog = produktKatalog;
            this.verwaltung = verwaltung;
            if (!aendereArtikel)
            {
                CreateProduktWindow.Title = "Erstelle Produkt";
            }
            else
            {
                CreateProduktWindow.Title = "Ändere Produkt";
            }

        }

        private void AbbrechenButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SpeichernButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal preis = Convert.ToDecimal(PreisTextBox.Text);
                string name = ProduktnameTextBox.Text;
                int artikelnummer = Convert.ToInt32(ArtikelnummerTextBox.Text);
                string beschreibung = BeschreibungTextBox.Text;
                int laenge;
                int breite;
                double reichweite;
                int anzahl = Convert.ToInt32(ExtraTextBox.Text);
                int musterversatz = Convert.ToInt32(ExtraTextBox.Text);
                int zusatzProduktMass = Convert.ToInt32(ExtraTextBox.Text);

                if (!aendereArtikel)
                {

                    switch (produktTyp)
                    {
                        case "Fliese":
                            laenge = Convert.ToInt32(LaengeReichweiteTextBox.Text);
                            breite = Convert.ToInt32(BreiteTextBox.Text);
                            Fliese flieseZuSpeichern = new Fliese(preis, name, artikelnummer, beschreibung, laenge, breite, anzahl);
                            produktKatalog.ArtikelSpeichern(flieseZuSpeichern, aendereArtikel);
                            Close();
                            break;
                        case "Tapete":
                            laenge = Convert.ToInt32(LaengeReichweiteTextBox.Text);
                            breite = Convert.ToInt32(BreiteTextBox.Text);
                            Tapete tapeteZuSpeichern = new Tapete(preis, name, artikelnummer, beschreibung, laenge, breite,musterversatz);
                            produktKatalog.ArtikelSpeichern(tapeteZuSpeichern, aendereArtikel);
                            Close();
                            break;
                        case "Fugenfüller":
                            reichweite = double.Parse(LaengeReichweiteTextBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture);
                            Fugenfueller fugenfuellerZuSpeichern = new Fugenfueller(preis, name, artikelnummer, beschreibung, zusatzProduktMass, reichweite);
                            produktKatalog.ArtikelSpeichern(fugenfuellerZuSpeichern, aendereArtikel);
                            Close();
                            break;
                        case "Tapetenkleister":
                            reichweite = double.Parse(LaengeReichweiteTextBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture);
                            Tapetenkleister kleisterZuSpeichern = new Tapetenkleister(preis, name, artikelnummer, beschreibung, zusatzProduktMass, reichweite);
                            produktKatalog.ArtikelSpeichern(kleisterZuSpeichern, aendereArtikel);
                            Close();
                            break;
                        case "Fliesenkleber":
                            reichweite = double.Parse(LaengeReichweiteTextBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture);
                            Fliesenkleber kleberZuSpeichern = new Fliesenkleber(preis, name, artikelnummer, beschreibung, zusatzProduktMass, reichweite);
                            produktKatalog.ArtikelSpeichern(kleberZuSpeichern, aendereArtikel);
                            Close();
                            break;
                    }

                }
                else
                {

                }
            }          
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

        }

        private void ProdukttypComboBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<string> comboBoxData = new List<string>();
            comboBoxData.Add("Fliese");
            comboBoxData.Add("Tapete");
            comboBoxData.Add("Fugenfüller");
            comboBoxData.Add("Tapetenkleister");
            comboBoxData.Add("Fliesenkleber");

            ProdukttypComboBox.ItemsSource = comboBoxData;

            ProdukttypComboBox.SelectedIndex = 0;
        }

        private void ProdukttypComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            produktTyp = ProdukttypComboBox.SelectedItem as string;

            switch (produktTyp)
            {
                case "Fliese":
                    ExtraTextBoxLabel.Content = "Anzahl der Fliesen";
                    LaengeReichweiteTextBox.Visibility = Visibility.Visible;
                    LaengeReichweiteLabel.Content = "Länge in Zentimeter";
                    LaengeReichweiteLabel.Visibility = Visibility.Visible;
                    BreiteTextBox.Visibility = Visibility.Visible;
                    BreiteLabel.Visibility = Visibility.Visible;
                    break;
                case "Tapete":
                    ExtraTextBoxLabel.Content = "Musterversatz";
                    LaengeReichweiteTextBox.Visibility = Visibility.Visible;
                    LaengeReichweiteLabel.Content = "Länge in Meter";
                    LaengeReichweiteLabel.Visibility = Visibility.Visible;
                    BreiteTextBox.Visibility = Visibility.Visible;
                    BreiteLabel.Visibility = Visibility.Visible;
                    break;
                case "Fliesenkleber":
                    ExtraTextBoxLabel.Content = "Gewicht in KG";
                    LaengeReichweiteTextBox.Visibility = Visibility.Visible;
                    LaengeReichweiteLabel.Content = "Reichweite";
                    LaengeReichweiteLabel.Visibility = Visibility.Visible;
                    BreiteTextBox.Visibility = Visibility.Hidden;
                    BreiteLabel.Visibility = Visibility.Hidden;
                    break;
                case "Fugenfüller":
                    ExtraTextBoxLabel.Content = "Gewicht in ML/KG";
                    LaengeReichweiteTextBox.Visibility = Visibility.Visible;
                    LaengeReichweiteLabel.Content = "Reichweite";
                    LaengeReichweiteLabel.Visibility = Visibility.Visible;
                    BreiteTextBox.Visibility = Visibility.Hidden;
                    BreiteLabel.Visibility = Visibility.Hidden;
                    break;
                case "Tapetenkleister":
                    ExtraTextBoxLabel.Content = "Gewicht in Gramm";
                    LaengeReichweiteTextBox.Visibility = Visibility.Visible;
                    LaengeReichweiteLabel.Content = "Reichweite";
                    LaengeReichweiteLabel.Visibility = Visibility.Visible;
                    BreiteTextBox.Visibility = Visibility.Hidden;
                    BreiteLabel.Visibility = Visibility.Hidden;
                    break;
  
            }
        }

        private void AendereErstelleProduktFenster_OnClosed(object sender, EventArgs e)
        {
            this.verwaltung.reloadKatalog();
        }
    }
}

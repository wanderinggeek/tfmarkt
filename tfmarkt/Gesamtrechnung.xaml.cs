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

namespace tfmarkt
{
    /// <summary>
    /// Interaktionslogik für Gesamtrechnung.xaml
    /// </summary>
    public partial class Gesamtrechnung : Window
    {
        ObservableCollection<WarenkorbObjekt> warenkorb;
        decimal gesamtpreis;
        decimal mehrwertsteuer;

        public Gesamtrechnung(ObservableCollection<WarenkorbObjekt> warenkorb, decimal gesamtpreis, decimal mehrwertsteuer)
        {
            InitializeComponent();

            this.warenkorb = warenkorb;
            this.gesamtpreis = gesamtpreis;
            this.mehrwertsteuer = mehrwertsteuer;

            int y = 240;

            foreach (WarenkorbObjekt warenkorbobjekt in warenkorb)
            {
                // Produktname
                Label name = new Label();
                name.Content = warenkorbobjekt.Produkt.name;
                name.Margin = new Thickness(17,y,0,0);
                this.TestGrid.Children.Add(name);

                // Artikelnummer
                Label artikelnummer = new Label();
                artikelnummer.Content = warenkorbobjekt.Produkt.artikelnummer;
                artikelnummer.Margin = new Thickness(224, y, 0, 0);
                this.TestGrid.Children.Add(artikelnummer);

                // Preis
                Label preis = new Label();
                preis.Content = warenkorbobjekt.Produkt.preis.ToString("##.##") + "€";
                preis.Margin = new Thickness(401, y, 0, 0);
                this.TestGrid.Children.Add(preis);

                // Anzahl
                Label anzahl = new Label();
                anzahl.Content = warenkorbobjekt.Anzahl + "Stück";
                anzahl.Margin = new Thickness(525, y, 0, 0);
                this.TestGrid.Children.Add(anzahl);

                // Gesamt
                decimal gs = warenkorbobjekt.Anzahl * warenkorbobjekt.Produkt.preis;
                Label gesamt = new Label();
                gesamt.Content = gs.ToString("##.##") + "€";
                gesamt.Margin = new Thickness(657, y, 0, 0);
                this.TestGrid.Children.Add(gesamt);               

                y += 20;

            }

            y += 10;

            Label nettoLabel = new Label();
            nettoLabel.Content = "Nettobetrag:";
            nettoLabel.Margin = new Thickness(525, y, 0, 0);
            this.TestGrid.Children.Add(nettoLabel);

            Label nettoBetrag = new Label();
            nettoBetrag.Content = gesamtpreis.ToString("##.##") + "€";
            nettoBetrag.Margin = new Thickness(657, y, 0, 0);
            this.TestGrid.Children.Add(nettoBetrag);

            y += 20;

            Label mwstLabel = new Label();
            mwstLabel.Content = "19 % Mehrwertsteuer:";
            mwstLabel.Margin = new Thickness(525, y, 0, 0);
            this.TestGrid.Children.Add(mwstLabel);

            Label mwst = new Label();
            mwst.Content = mehrwertsteuer.ToString("##.##") + "€";
            mwst.Margin = new Thickness(657, y, 0, 0);
            this.TestGrid.Children.Add(mwst);

            y += 20;

            Label bruttoLabel = new Label();
            bruttoLabel.Content = "Gesamtbetrag:";
            bruttoLabel.FontWeight = FontWeights.Bold;
            bruttoLabel.Margin = new Thickness(525, y, 0, 0);
            this.TestGrid.Children.Add(bruttoLabel);

            decimal bruttobetrag = gesamtpreis + mehrwertsteuer;
            Label bruttoBetrag = new Label();
            bruttoBetrag.Content = bruttobetrag.ToString("##.##") + "€";
            bruttoLabel.FontWeight = FontWeights.Bold;
            bruttoBetrag.Margin = new Thickness(657, y, 0, 0);
            this.TestGrid.Children.Add(bruttoBetrag);


            y += 50;

            Label zahlungsbedingungenLabel = new Label();
            zahlungsbedingungenLabel.Content = "Zahlungsbedingungen";
            zahlungsbedingungenLabel.FontWeight = FontWeights.Bold;
            zahlungsbedingungenLabel.Margin = new Thickness(17, y, 0, 0);
            this.TestGrid.Children.Add(zahlungsbedingungenLabel);

            y += 20;

            Label zahlungszielLabel = new Label();
            zahlungszielLabel.Content = "Zahlungsziel:\tsofort";
            zahlungszielLabel.Margin = new Thickness(17, y, 0, 0);
            this.TestGrid.Children.Add(zahlungszielLabel);

            y += 50;

            Label bankverbindungLabel = new Label();
            bankverbindungLabel.Content = "Bankverbindung";
            bankverbindungLabel.FontWeight = FontWeights.Bold;
            bankverbindungLabel.Margin = new Thickness(17, y, 0, 0);
            this.TestGrid.Children.Add(bankverbindungLabel);

            y += 20;

            Label bankZeile1Label = new Label();
            bankZeile1Label.Content = "Inhaber:\t\tMax Mustermann\t\t\tKonto-Nr.:\t123456789";
            bankZeile1Label.Margin = new Thickness(17, y, 0, 0);
            this.TestGrid.Children.Add(bankZeile1Label);

            y += 20;

            Label bankZeile2Label = new Label();
            bankZeile2Label.Content = "Bank:\t\tMeine Bank\t\t\tBIC:\t\t123456789";
            bankZeile2Label.Margin = new Thickness(17, y, 0, 0);
            this.TestGrid.Children.Add(bankZeile2Label);

            y += 20;

            Label bankZeile3Label = new Label();
            bankZeile3Label.Content = "BLZ:\t\t12345\t\t\t\tIBAN:\t\t123456789";
            bankZeile3Label.Margin = new Thickness(17, y, 0, 0);
            this.TestGrid.Children.Add(bankZeile3Label);

            y += 50;

            Label mfgLabel = new Label();
            mfgLabel.Content = "Mit freundlichen Grüßen";
            mfgLabel.Margin = new Thickness(17, y, 0, 0);
            this.TestGrid.Children.Add(mfgLabel);

            y += 50;

            Label unterschriftLabel = new Label();
            unterschriftLabel.Content = "Max Mustermann";
            unterschriftLabel.Margin = new Thickness(17, y, 0, 0);
            this.TestGrid.Children.Add(unterschriftLabel);   
        }
    }
}

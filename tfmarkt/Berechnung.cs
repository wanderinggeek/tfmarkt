using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tfmarkt.Produktklassen;

namespace tfmarkt
{
    class Berechnung
    {
        // Attribute
        public double flaeche;
        public double gesamtbetrag;
        public Fliesenkleber fliesenkleber;
        public Tapetenkleister tapetenkleister;
        public Fugenfueller fugenfueller;

        public Berechnung(double flaeche, Fliesenkleber fliesenkleber, Tapetenkleister tapetenkleister, Fugenfueller fugenfueller)
        {
            this.flaeche = flaeche;
            this.gesamtbetrag = 0;
            this.fliesenkleber = fliesenkleber;
            this.tapetenkleister = tapetenkleister;
            this.fugenfueller = fugenfueller;
        }

        // Der Typ vom Parameter fliese muss auf Fliese geändert werden, sobald die Klasse dazu verfügbar ist
        public void FliesenBerechnen(Produkt fliese)
        {
            // Berechnung Fliesen
            // GesamtBetragAktualiseren
        }

        public void TapetenBerechnen(Tapete tapete)
        {
            // Berechnung Tapeten
            // GesamtBetragAktualsieren
        }

        public void ZusatzproduktBerechnen(string zusatzprodukt)
        {
            switch (zusatzprodukt)
            {
                case "Tapetenkleister":
                    // Berechnung für Tapetenkleister
                    break;

                case "Fliesenkleber":
                    // Berechnung für Fliesenkleber
                    break;

                case "Fugenfueller":
                    // Berechnung für Fugenfueller
                    break;

                default:
                    break;
            }
        }

        public void GesamtBetragAktualisieren(double betragFuerAktuelleTransaktion)
        {
            this.gesamtbetrag += betragFuerAktuelleTransaktion;
        }
    }
}

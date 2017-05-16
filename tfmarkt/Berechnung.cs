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
        public double gesamtbetrag;

        // Später als Parameter den Produktkatalog übergeben
        public Berechnung()
        {
            this.gesamtbetrag = 0;
        }

        // Der Typ vom Parameter fliese muss auf Fliese geändert werden, sobald die Klasse dazu verfügbar ist
        public void FliesenBerechnen(double flaeche, Produkt fliese)
        {
            // Berechnung Fliesen
            // GesamtBetragAktualiseren
        }

        public int TapetenBerechnen(double flaeche, Tapete tapete)
        {
            // Berechnung Tapeten

            double ergebnis = flaeche * 2;

            return Convert.ToInt32(ergebnis);
        }

        public int ZusatzproduktBerechnen(string zusatzprodukt, Tapete tapete)
        {
            switch (zusatzprodukt)
            {
                case "Tapetenkleister":
                    // Berechnung für Tapetenkleister
                    return 2; 
                case "Fliesenkleber":
                    // Berechnung für Fliesenkleber
                    return 0;
                case "Fugenfueller":
                    // Berechnung für Fugenfueller
                    return 0;
                default:
                    return 0; // Kann für Fehlerbehandlung benutzt werden
            }
        }

        public void GesamtBetragAktualisieren(double betragFuerAktuelleTransaktion, string aktion)
        {
            if (aktion == "Hinzufuegen")
            {
                this.gesamtbetrag += betragFuerAktuelleTransaktion;
            }
            else
            {
                this.gesamtbetrag -= betragFuerAktuelleTransaktion;
            }
        }
    }
}

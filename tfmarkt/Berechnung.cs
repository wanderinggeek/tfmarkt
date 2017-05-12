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

        public void TapetenBerechnen(double flaeche, Tapete tapete)
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

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

        public int TapetenBerechnen(double flaeche, double wandbreite, double wandhoehe, Tapete tapete)
        {
            // Berechnung Tapeten
            double benoetigteBahnen = Convert.ToInt32(Math.Ceiling(wandbreite / tapete.breite));
            double laengeTapetenbahn = wandhoehe + (tapete.musterversatz / 10);
            double bahnenProTapetenRolle = Convert.ToInt32(Math.Round(tapete.laenge / laengeTapetenbahn, MidpointRounding.ToEven));
            double benoetigteTapetenRollen = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(benoetigteBahnen / bahnenProTapetenRolle)));

            return Convert.ToInt32(benoetigteTapetenRollen);
        }

        public int TapetenkleisterBerechnen(Tapete tapete, double flaeche, Tapetenkleister tapetenkleister)
        {
            double benoetigtePackungenKleister = flaeche / tapetenkleister.reichweite;
            return Convert.ToInt32(Math.Ceiling(benoetigtePackungenKleister));
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

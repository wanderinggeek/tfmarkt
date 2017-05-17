using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tfmarkt.Produktklassen;
using System.Collections.ObjectModel;
using System.Windows;

namespace tfmarkt
{
    class Berechnung
    {
        // Konstruktor
        public Berechnung()
        {
        }

        // Der Typ vom Parameter fliese muss auf Fliese geändert werden, sobald die Klasse dazu verfügbar ist
        public void FliesenBerechnen(double flaeche, Produkt fliese)
        {
            // Berechnung Fliesen
            // GesamtBetragAktualiseren
        }

        public int TapetenBerechnen(double flaeche, double wandbreite, double wandhoehe, Tapete tapete)
        {
            // Berechnung der Anzahl an benötigten Tapetenrollen
            double verschnitt = 0.10; // es wird von 10 cm Verschnitt ausgegangen
            double benoetigteBahnen = Convert.ToInt32(Math.Ceiling(wandbreite / tapete.breite));

            double laengeTapetenbahn = wandhoehe + verschnitt;
            
            double bahnenProTapetenRolle = Convert.ToInt32(Math.Round(tapete.laenge / laengeTapetenbahn, MidpointRounding.ToEven));
            double benoetigteTapetenRollen = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(benoetigteBahnen / bahnenProTapetenRolle)));

            return Convert.ToInt32(benoetigteTapetenRollen);
        }

        public int TapetenkleisterBerechnen(Tapete tapete, double flaeche, Tapetenkleister tapetenkleister)
        {
            // Berechnung der Anzahl an benötigten Packungen Tapetenkleister
            double benoetigtePackungenKleister = flaeche / tapetenkleister.reichweite;
            return Convert.ToInt32(Math.Ceiling(benoetigtePackungenKleister));
        }

        public decimal GesamtbetragBerechnen(ObservableCollection<WarenkorbObjekt> warenkorb)
        {
            // Liefert den Gesamtbetrag zu einem Warenkorb zurück
            decimal gesamtbetrag = 0;

            foreach (WarenkorbObjekt warenkorbobjekt in warenkorb)
            {
                gesamtbetrag += warenkorbobjekt.Produkt.preis * warenkorbobjekt.Anzahl;
            }

            return gesamtbetrag;
        }        
        
        public decimal SteuerBerechnen(decimal gesamtbetrag)
        {
            // Liefert die Mehrwertsteuer zu einem Betrag zurück
            return (gesamtbetrag / 100) * 19;
        }
    }
}

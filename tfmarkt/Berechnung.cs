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
        public int FliesenBerechnen(double flaeche, Fliese fliese, double fugenbreite)
        {
            // Berechnung Fliesen
            // GesamtBetragAktualiseren
            double flieseGroesse = (double)Math.Ceiling((fliese.laenge * (fliese.breite + fugenbreite)) * 1.05);

            double flaecheinZm = flaeche * 100;

            int benoetigteFliesen = (int)Math.Ceiling(flaecheinZm / flieseGroesse);

            int benoetigtePakete = (int)Math.Ceiling((double)benoetigteFliesen / fliese.anzahl);


            return benoetigtePakete;
        }

        public int FugenfuellerBerechnen(double flaeche, Fugenfueller fugenfueller)
        {
            //Berechnung Fugenfüller
            int benoetigteFugenfueller = (int)Math.Ceiling((double)flaeche / fugenfueller.reichweite);

            return benoetigteFugenfueller;
        }

        public int FliesenkleberBerechnen(double flaeche, Fliesenkleber fliesenkleber)
        {
            //Berechnung der Fliesenkleber
            int beoetigteFlesenkleber = (int)Math.Ceiling((double)flaeche / fliesenkleber.reichweite);

            return beoetigteFlesenkleber;
        }

        public int TapetenBerechnen(double flaeche, double wandbreite, double wandhoehe, Tapete tapete)
        {
            // Berechnung der Anzahl an benötigten Tapetenrollen
            
            // Verworfen
            /*
                double verschnitt = 0.10; // es wird von 10 cm Verschnitt ausgegangen
                int benoetigteBahnen = Convert.ToInt32(Math.Ceiling(wandbreite / tapete.breite));

                double laengeTapetenbahn = wandhoehe + verschnitt;
            
                int bahnenProTapetenRolle = Convert.ToInt32(Math.Round(tapete.laenge / laengeTapetenbahn, MidpointRounding.ToEven));
                int benoetigteTapetenRollen = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(benoetigteBahnen / bahnenProTapetenRolle)));

                return Convert.ToInt32(benoetigteTapetenRollen);
            */

            // Wieviele Tapetenbahnen werden für die Wand benötigt?
            int benoetigeBahnen = Convert.ToInt32(Math.Ceiling(wandbreite / tapete.breite));
            
            // Welche Bahnenlänge wird benötigt?
            double anzahlMuster = Math.Ceiling(wandhoehe / tapete.musterversatz);
            double bahnenLaenge = anzahlMuster * tapete.musterversatz;

            // Wieviele Bahnen bekomme ich aus einer Rolle
            int bahnen = Convert.ToInt32(tapete.laenge / bahnenLaenge);

            // Wieviele Rollen werden benötigt?
            int benoetigeRollen = Convert.ToInt32(Math.Ceiling(tapete.laenge / bahnen));

            // Berechnung laut http://www.meinewand.de/wie-berechne-tapetenbedarf-tapeten-rapport

            return benoetigeRollen;
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

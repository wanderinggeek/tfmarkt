using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmarkt.Produktklassen
{
   public class Fugenfueller : Zusatzprodukt
    {
        // Attribute
        public double verbrauch;

        // Konstruktor
        public Fugenfueller(double preis, string name, int artikelnummer, string beschreibung, double verbrauch)
        {
            base.preis = preis;
            base.name = name;
            base.artikelnummer = artikelnummer;
            base.beschreibung = beschreibung;

            this.produkttyp = "fugenfueller";
            this.verbrauch = verbrauch;
        }

        public Fugenfueller() { }

        // Get / Set
        public double Verbrauch
        {
            get { return verbrauch; }
            set { this.verbrauch = value; }
        }
    }
}

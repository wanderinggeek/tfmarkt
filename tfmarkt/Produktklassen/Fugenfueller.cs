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

        // Konstruktor
        public Fugenfueller(decimal preis, string name, int artikelnummer, string beschreibung, double gewicht, double reichweite)
        {
            base.preis = preis;
            base.name = name;
            base.artikelnummer = artikelnummer;
            base.beschreibung = beschreibung;
            base.gewicht = gewicht;
            base.reichweite = reichweite;

            this.produkttyp = "Fugenfüller";
        }

        public Fugenfueller() { }

    }
}

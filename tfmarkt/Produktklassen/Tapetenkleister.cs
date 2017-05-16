using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmarkt.Produktklassen
{
    public class Tapetenkleister : Zusatzprodukt
    {
        // Attribute

        // Konstruktor
        public Tapetenkleister(decimal preis, string name, int artikelnummer, string beschreibung, double gewicht, double reichweite)
        {
            base.preis = preis;
            base.name = name;
            base.artikelnummer = artikelnummer;
            base.beschreibung = beschreibung;
            base.gewicht = gewicht;
            base.reichweite = reichweite;

            this.produkttyp = "Tapetenkleister";
        }

        public Tapetenkleister() { }

    }
}

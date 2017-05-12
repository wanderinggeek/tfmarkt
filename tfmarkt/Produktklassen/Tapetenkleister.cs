using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmarkt.Produktklassen
{
    class Tapetenkleister : Zusatzprodukt
    {
        // Attribute
        private double reichweite;

        // Konstruktor
        public Tapetenkleister(double preis, string name, int artikelnummer, string beschreibung, double reichweite)
        {
            base.preis = preis;
            base.name = name;
            base.artikelnummer = artikelnummer;
            base.beschreibung = beschreibung;

            this.reichweite = reichweite;
        }

        // Get / Set
        public double Reichweite
        {
            get { return reichweite; }
            set { this.reichweite = value; }
        }
    }
}

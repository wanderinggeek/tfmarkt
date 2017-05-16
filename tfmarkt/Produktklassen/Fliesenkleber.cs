using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmarkt.Produktklassen
{
    public class Fliesenkleber : Zusatzprodukt
    {
        // Attribute
        private bool angehakt { get; set; }

        // Konstruktor
        public Fliesenkleber(decimal preis, string name, int artikelnummer, string beschreibung, double gewicht, double reichweite, bool angehakt = false)
        {
            base.preis = preis;
            base.name = name;
            base.artikelnummer = artikelnummer;
            base.beschreibung = beschreibung;
            base.gewicht = gewicht;
            base.reichweite = reichweite;


            this.produkttyp = "Fliesenkleber";
            this.angehakt = angehakt;
        }

        public Fliesenkleber() { }

        public bool Angehakt
        {
            get { return this.angehakt; }
        }
    }
}

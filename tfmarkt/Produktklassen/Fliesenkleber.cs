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
        private double flaeche { get; set; } // eventuell müssen wir Flaeche noch umbennenen, weitere Recherche ist notwendig!
        private bool angehakt { get; set; }

        // Konstruktor
        public Fliesenkleber(double preis, string name, int artikelnummer, string beschreibung, double flaeche, bool angehakt = false)
        {
            base.preis = preis;
            base.name = name;
            base.artikelnummer = artikelnummer;
            base.beschreibung = beschreibung;

            this.produkttyp = "fliesenkleber";
            this.flaeche = flaeche;
            this.angehakt = angehakt;
        }

        public Fliesenkleber() { }

        // Get / Set
        public double Flaeche
        {
            get { return this.flaeche; }
            set { this.flaeche = value; }
        }

        public bool Angehakt
        {
            get { return this.angehakt; }
        }
    }
}

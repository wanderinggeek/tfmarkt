using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tfmarkt.Produktklassen
{
    //Die Klasse ist das Modell der Tapeten
    //Erbt Eigebnscaften von Produkt
    public class Tapete:Produkt
    {
        //Klassen Member
        public double laenge { get; set; }
        public double breite { get; set; }
        public double musterversatz { get; set; }

        //Konstruktor
        public Tapete(decimal preis, string name, int artikelnummer, string beschreibung, double laenge, double breite, double musterversatz = 0)
        {
            base.preis = preis;
            base.name = name;
            base.artikelnummer = artikelnummer;
            base.beschreibung = beschreibung;

            this.laenge = laenge;
            this.breite = breite;
            this.musterversatz = musterversatz;
            this.produkttyp = "Tapete";
        }

        public Tapete() { }

    }
}


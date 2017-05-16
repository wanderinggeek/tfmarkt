using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmarkt.Produktklassen
{
    //Die Klasse ist das Modell der Fliesen
    //Erbt Eigenschaften von Produkt
    public class Fliese : Produkt
    {
        //Klassenmember
        public double laenge { get; set; }
        public double breite { get; set; }
        public int anzahl { get; set; }
        public double flaeche;

        //Konstruktor
        public Fliese(decimal preis, string name, int artikelnummer, string beschreibung, double laenge, double breite, int anzahl)
        {
            base.preis = preis;
            base.name  = name;
            base.artikelnummer = artikelnummer;
            base.beschreibung = beschreibung;

            this.laenge = laenge;
            this.breite = breite;
            this.anzahl = anzahl;
            this.produkttyp = "Fliese";
        }

        public Fliese() { }

        //Gibt die Fläche zurück, die mit der Fliese abgedeckt werden kann
        public double GetFlaeche()
        {
            return this.breite * this.laenge;
        }

    }
}

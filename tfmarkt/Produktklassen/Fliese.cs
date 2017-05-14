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
        public int laenge { get; set; }
        public int breite { get; set; }
        public int anzahl { get; set; }
        public double flaeche;

        //Konstruktor
        public Fliese(double preis, string name, int artikelnummer, string beschreibung, int laenge, int breite, int anzahl)
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

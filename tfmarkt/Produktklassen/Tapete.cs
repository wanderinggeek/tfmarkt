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
        public int laenge { get; set; }
        public int breite { get; set; }
        public int musterversatz { get; set; }
        double flaeche;

        //Konstruktor
        public Tapete(double preis, string name, int artikelnummer, string beschreibung, int laenge, int breite, int musterversatz)
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

        //Gibt die Fläche zurück, die mit der Tapete abgedeckt werden kann
        public double GetFlaeche()
        {
            return this.breite * this.laenge;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmarkt
{
    abstract class Produkt
    {
        double preis;
        string name;
        int artikelnummer;
        string beschreibung;
        private Produkt()
        { 
            this.preis = 0;
            this.name = null;
            this.artikelnummer = 0;
            this.beschreibung = "";
        }

        public double getPreis()
        {
            return this.preis;
        }

        public void setPreis(double neuerPreis)
        {
            this.preis = neuerPreis;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string neuerName)
        {
            this.name = neuerName;
        }

        public int getArtikelnummer()
        {
            return this.artikelnummer;
        }

        public void setArtikelnummer(int neueArtikelnummer)
        {
            this.artikelnummer = neueArtikelnummer;
        }

        public string getBeschreibung()
        {
            return this.beschreibung;
        }

        public void setBeschreibung(string neueBeschreibung)
        {
            this.beschreibung = neueBeschreibung;
        }
    }
}


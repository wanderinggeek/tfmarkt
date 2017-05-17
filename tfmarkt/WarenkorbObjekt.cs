using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tfmarkt.Produktklassen;

namespace tfmarkt
{
    public class WarenkorbObjekt
    {
        // Attribute
        public Produkt produkt;
        int anzahl;

        // Konstruktor
        public WarenkorbObjekt(Produkt produkt, int anzahl)
        {
            this.produkt = produkt;
            this.anzahl = anzahl;
        }

        public WarenkorbObjekt()
        {

        }

        // Get / Set
        public Produkt Produkt
        {
            get { return produkt; }
        }

        public int Anzahl
        {
            get { return anzahl; }
            set { this.anzahl = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmarkt.Produktklassen.Produkt
{
    public abstract class Produkt
    {
        public double preis { get; set; }
        public string name { get; set; }
        public int artikelnummer { get; set; }
        public string beschreibung { get; set; }

    }
}
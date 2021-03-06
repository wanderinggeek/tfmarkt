﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmarkt.Produktklassen
{
    //Abstrakte Klasse für alle Produkte
    public abstract class Produkt 
    {
        public decimal preis { get; set; }
        public string name { get; set; }
        public int artikelnummer { get; set; }
        public string beschreibung { get; set; }
        public string produkttyp { get; set; }
    }
}
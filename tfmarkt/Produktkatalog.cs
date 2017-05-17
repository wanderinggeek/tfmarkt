using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;
using tfmarkt.Produktklassen;


namespace tfmarkt
{
    public class ProduktKatalog
    {
        public List<int> artikelnummern { get; set; }
        public List<Tapete> tapeten { get; set; }
        public List<Fliese> fliesen { get; set; }
        public Fliesenkleber fliesenkleber {get; set;}
        public Fugenfueller fugenfueller { get; set; }
        public Tapetenkleister tapetenkleister { get; set; }

        public ProduktKatalog()
        {
            this.artikelnummern = new List<int>(103);
            this.tapeten = new List<Tapete>(50);
            this.fliesen = new List<Fliese>(50);
            this.fugenfueller = fugenfueller;
        }

        public ProduktKatalog ProdukteEinlesen()
        {
            ProduktKatalog produktKatalog = new ProduktKatalog();
            if (File.Exists("produktkatalog.xml"))
            {
                var serializer = new XmlSerializer(typeof(ProduktKatalog));
                FileStream myFileStream = new FileStream("produktkatalog.xml", FileMode.Open);
                produktKatalog = (ProduktKatalog) serializer.Deserialize(myFileStream);
                myFileStream.Close();
                return produktKatalog;
            }
            else
            {
                var serializer = new XmlSerializer(typeof(ProduktKatalog));
                TextWriter writer = new StreamWriter("produktkatalog.xml");
                serializer.Serialize(writer, this);
                writer.Close();
                return produktKatalog;
            }
        }

        public void ArtikelSpeichern(dynamic artikel, bool aendereArtikel, int alteArtikelnummer = 0)
        {
            var returnType = artikel.GetType();
            string dataTypeString = returnType.ToString();
            try
            {
                if (!artikelnummern.Contains(artikel.artikelnummer) && !aendereArtikel)
                {
                    //save and add to artikelnummern

                    switch (dataTypeString)
                    {
                        case "tfmarkt.Produktklassen.Fliese":
                            this.fliesen.Add(artikel);                        
                            this.artikelnummern.Add(artikel.artikelnummer);
                            MessageBox.Show("Fliese hinzugefügt");
                            break;
                        case "tfmarkt.Produktklassen.Tapete":
                            this.tapeten.Add(artikel);
                           this.artikelnummern.Add(artikel.artikelnummer);
                            MessageBox.Show("Tapete hinzugefügt");
                            break;
                        case "tfmarkt.Produktklassen.Fliesenkleber":
                            this.fliesenkleber = artikel;
                            this.artikelnummern.Add(artikel.artikelnummer);
                            MessageBox.Show("Fliesenkleber hinzugefügt");
                            break;
                        case "tfmarkt.Produktklassen.Fugenfueller":
                            this.fugenfueller = artikel;
                            this.artikelnummern.Add(artikel.artikelnummer);
                            MessageBox.Show("Fuegenfueller hinzugefügt");
                            break;
                        case "tfmarkt.Produktklassen.Tapetenkleister":
                            this.tapetenkleister = artikel;
                            this.artikelnummern.Add(artikel.artikelnummer);
                            MessageBox.Show("Tapetenkleister hinzugefügt");
                            break;
                    }

                }
                else if (aendereArtikel)
                {
                   
                    switch (dataTypeString)
                    {
                        case "tfmarkt.Produktklassen.Fliese":
                            this.fliesen.Add(artikel);
                            Fliese alteFliese = this.fliesen.Find(x => x.artikelnummer == alteArtikelnummer);
                            this.fliesen.Remove(alteFliese);
                            if (alteArtikelnummer != artikel.artikelnummer)
                            {
                                this.artikelnummern.Add(artikel.artikelnummer);
                            }
                            MessageBox.Show("Fliese wurde geändert");
                            break;
                        case "tfmarkt.Produktklassen.Tapete":
                            this.tapeten.Add(artikel);
                            Tapete alteTapete = this.tapeten.Find(x => x.artikelnummer == alteArtikelnummer);
                            this.tapeten.Remove(alteTapete);
                            if (alteArtikelnummer != artikel.artikelnummer)
                            {
                                this.artikelnummern.Add(artikel.artikelnummer);
                            }                            
                            MessageBox.Show("Tapete wurde geändert");
                            break;
                        case "tfmarkt.Produktklassen.Fliesenkleber":
                            this.fliesenkleber = artikel;
                            if (alteArtikelnummer != artikel.artikelnummer)
                            {
                                this.artikelnummern.Add(artikel.artikelnummer);
                            }    
                            MessageBox.Show("Fliesenkleber wurde geändert");
                            break;
                        case "tfmarkt.Produktklassen.Fugenfueller":
                            this.fugenfueller = artikel;
                            if (alteArtikelnummer != artikel.artikelnummer)
                            {
                                this.artikelnummern.Add(artikel.artikelnummer);
                            }                       
                            MessageBox.Show("Fuegenfueller wurde geändert");
                            break;
                        case "tfmarkt.Produktklassen.Tapetenkleister":
                            this.tapetenkleister = artikel;
                            if (alteArtikelnummer != artikel.artikelnummer)
                            {
                                this.artikelnummern.Add(artikel.artikelnummer);
                            }                          
                            MessageBox.Show("Tapetenkleister wurde geändert");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Ein Produkt mit der Artikelnummer: " + artikel.artikelnummer.ToString() + " ist schon im System");
                }

                var serializer = new XmlSerializer(typeof(ProduktKatalog));
                TextWriter writer = new StreamWriter("produktkatalog.xml");
                serializer.Serialize(writer, this);
                writer.Close();
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.ToString());
            }
        }
    }
}

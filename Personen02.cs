using System.Diagnostics.Metrics;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Personen02
{
    public class Person
    {
        public string Nachname;
        public string Vorname;
        public DateTime Geburtsdatum;

        public Person()
        {
            
        }
        public Person(string nachname, string vorname, DateTime gdatum)
        {
            Nachname = nachname;
            Vorname = vorname;
            Geburtsdatum = gdatum;
        }
        public override string ToString()
        {
            return Vorname + " " + Nachname + " " + Geburtsdatum.ToShortDateString();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> liste = new List<Person>();
            liste.Add(new Person("Druffel", "Lea", new DateTime(1991,12,7 )));
            liste.Add(new Person("Druffel", "Markus", new DateTime(1977,2,17)));
            liste.Add(new Person("Druffel", "Lasse", new DateTime(2017, 7,6)));
            liste.Add(new Person("Druffel", "Nils", new DateTime(1990, 11,7)));
            liste.Add(new Person("Noll-Druffel", "Silke", new DateTime(1964, 2, 8)));

            XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
            using (FileStream stream = File.Create("Personen.xml"))
            {
               
                xml.Serialize(stream, liste);

                
            }

            liste = null;

            List<Person> listeneu = new List<Person>();
            using (FileStream stream = File.OpenRead("Personen.xml"))
            {
                listeneu = xml.Deserialize(stream) as List<Person>;
            }

            foreach (var p in listeneu)
            {
                Console.WriteLine(p.ToString());
             
            }
        }
    }
}

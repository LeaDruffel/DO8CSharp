using System.Text.Json;
using System.Xml.Serialization;

namespace Personen01
{
    public class Person
    {
        public string vorname;
        public string nachname;
        public int alter;

        public Person(string vorname_, string nachname_, int alter_)
        {
            vorname = vorname_;
            nachname = nachname_;
            alter = alter_;
        }
        public Person()
        {
            
        }
    }
    internal class Program
    {
        public static void Laden()
        {
            Console.Clear();
            Console.Write("Bitte geben sie den Vornamen der Person ein die Sie laden möchten: ");
            string suchname = Console.ReadLine();
            suchname = suchname.ToLower();



            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Person));
                Person neuperson;
                using (FileStream stream = File.OpenRead($"{suchname}.xml"))
                {
                    neuperson = xml.Deserialize(stream) as Person;
                }

                Console.Clear();
                Console.WriteLine($"Vorname: {neuperson.vorname}");
                Console.WriteLine($"Nachname: {neuperson.nachname}");
                Console.WriteLine($"Alter: {neuperson.alter}");
            }
            catch (Exception)
            {

                Console.WriteLine("Person nicht gefunden.");
            }
        }
        public static void Speichern()
        {
            Console.Clear();
            Console.Write("Bitte Vornamen angeben: ");
            string vname = Console.ReadLine();
            Console.Clear();
            Console.Write("Bitte Nachnamen angeben: ");
            string nname = Console.ReadLine();
            Console.Clear();
            Console.Write("Bitte Alter angeben: ");
            int alter = int.Parse(Console.ReadLine());
            Console.Clear();


            XmlSerializer xml = new XmlSerializer(typeof(Person));
            using (FileStream stream = File.Create($"{vname.ToLower()}.xml"))
            {
                xml.Serialize(stream, (new Person(vname, nname, alter)));
            }
        }

        public static void Menueausgabe()
        {
            Console.WriteLine("Möchtest du eine Person einspeichern oder eine Person laden? 1/2/3");
            Console.WriteLine("1. Speichern");
            Console.WriteLine("2. Laden");
            Console.WriteLine("3. Beenden");
           
        }
        static void Main(string[] args)
        {
            string auswahl;

            do
            {
                Menueausgabe();
                auswahl = Console.ReadLine();

                if (auswahl == "1")
                {
                    Speichern();

                }
                else if (auswahl == "2")
                {

                    Laden();
                   
                }
                else if (auswahl != "3")
                {

                    Console.WriteLine("Ungültige Eingabe");
                }
            } while (auswahl != "3");
        }
    }
}

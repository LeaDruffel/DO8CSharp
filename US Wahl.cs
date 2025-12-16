using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace US_Wahl
{
    public enum Geschlecht
    {
        w,
        m
        
    }

    public enum Schicht
    {
        Unterschicht,
        UntereMittelschicht,
        ObereMittelschicht,
        Oberschicht
    }

    public enum PolitischeOrientierung
    {
        Republikaner,
        Demokraten

    }
    public enum Beeinflußbarkeit
    {
        Leicht,
        Mittel,
        Schwer
    }
    public enum Wahlalter
    {
        Erstwähler,
        Bis30,
        Bis40,
        Bis50,
        Bis60,
        Sonstige
    }


    public class Person
    {
        private string _ID;
        private string _vorname; 
        private string _nachname; 
        private string _PLZ; 
        private Geschlecht _geschlecht; 
        private Wahlalter _alter; 
        private Schicht _schicht; 
        private PolitischeOrientierung _pol;
        private Beeinflußbarkeit _beein;

        public Person(string id, Geschlecht geschlecht, string vorname, string nachname, string PLZ,  Wahlalter alter, Schicht schicht, PolitischeOrientierung pol, Beeinflußbarkeit beein)
        {
            _ID = id;
            _vorname = vorname;
            _nachname = nachname;
            _PLZ = PLZ;
            _alter = alter;
            _pol = pol;
            _beein = beein;
            _geschlecht = geschlecht;
            _alter = alter;
            _schicht = schicht;
            _beein = beein;
        }

        public string GetName() { return $"{_vorname} {_nachname}"; }
        public string GetID() { return _ID; }
        public string GetPLZ() { return _PLZ; }
        public Geschlecht GetGeschlecht() { return _geschlecht; }
        public string GetVorname() { return _vorname; }
        public string GetNachname() {  return _nachname; }
        public Wahlalter GetAlter() { return _alter; }
        public Schicht GetSchicht() { return _schicht; }
        public PolitischeOrientierung GetPol() { return _pol; }
        public Beeinflußbarkeit GetBeeinflußbarkeit() { return _beein; }

    }
    static class Model
    {
         
        public static List<Person> people = new List<Person>();
        public static List<string> vornamenw = new List<string>();
        public static List<string> vornamenm = new List<string>();
        public static List<string> nachnamen = new List<string>();

        public static void Nameneinlesen()
        {
            using (StreamReader sr = File.OpenText("vornamen_w.txt"))
            {
                while (true)
                {
                    string zeile = sr.ReadLine();
                    if (zeile != null)
                    {
                        vornamenw.Add(zeile);
                    } else
                    {
                        break;
                    }
                }
            }
            using (StreamReader sr = File.OpenText("vornamen_m.txt"))
            {
                while (true)
                {
                    string zeile = sr.ReadLine();
                    if (zeile != null)
                    {
                        vornamenm.Add(zeile);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            using (StreamReader sr = File.OpenText("nachnamen.txt"))
            {
                while (true)
                {
                    string zeile = sr.ReadLine();
                    if (zeile != null)
                    {
                        nachnamen.Add(zeile);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public static void GenerateValues(int anzahl)
        {
            for (int i = 0; i < anzahl; i++)
            {
            Random randy = new Random();
               
                string vorname;
                int gesch = randy.Next(0, 2);
                Geschlecht geschlecht = (randy.Next(2) == 0) ? Geschlecht.w : Geschlecht.m;
                if (geschlecht == Geschlecht.w )
                {
                int indexn = randy.Next(vornamenw.Count);
                    vorname = vornamenw[indexn];
                } else
                {
                int indexn = randy.Next(vornamenm.Count);
                    vorname = vornamenm[indexn];

                }
                int indexnn = randy.Next(nachnamen.Count);
                string nachname = nachnamen[indexnn];
                Wahlalter wahlalter = (Wahlalter)(randy.Next(0, 6));
                Schicht schicht = (Schicht)(randy.Next(0, 4));
                PolitischeOrientierung pol = (PolitischeOrientierung)(randy.Next(0, 2));
                Beeinflußbarkeit beein = (Beeinflußbarkeit)(randy.Next(0, 3));

                    Person person = new Person(
                        i.ToString(),
                        geschlecht,
                        vorname,
                        nachname,
                        randy.Next(10000, 100000).ToString(),
                        wahlalter,
                        schicht,
                        pol,
                        beein
                        );
                people.Add(person);
            }
        }

        public static List<Person> GetVoters()
        {
            return people;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Model.Nameneinlesen();
            Model.GenerateValues(1000);
            List<Person> list = Model.GetVoters();

            List<Person> list1 = new List<Person>();
            foreach (Person person in list)
            {
                if (person.GetPLZ().StartsWith('3') && person.GetSchicht() == Schicht.ObereMittelschicht && person.GetPol() == PolitischeOrientierung.Republikaner)
                {
                    list1.Add(person);
                }
            }

            List<Person> list2 = new List<Person>();
            foreach (Person person in list)
            {
                if (person.GetAlter() == Wahlalter.Bis60 && person.GetPol() == PolitischeOrientierung.Demokraten && person.GetBeeinflußbarkeit() == Beeinflußbarkeit.Leicht)
                {
                    list2.Add(person);
                }
            }

            List<Person> list3 = new List<Person>();
            foreach (Person person in list)
            {
                if (person.GetSchicht() == Schicht.Oberschicht && person.GetBeeinflußbarkeit() == Beeinflußbarkeit.Schwer && person.GetPol() == PolitischeOrientierung.Republikaner)
                {
                    list3.Add(person);
                }
            }

            foreach (Person person in list1)
            {
                Console.WriteLine(person.GetName());
            }
        }
    }
}

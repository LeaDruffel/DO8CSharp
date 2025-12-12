namespace Wasserstand_2
{
    public class MyEventArgs : EventArgs
    {
        public string Operation { get; }
        public int Value { get; }
        public MyEventArgs(int val)
        {
            
            Value = val;
        }
    }
    public class Fluss
    {
        private string _name;
        private int _wasserstand;
        public event EventHandler<MyEventArgs> WasserstandÄnderungsEvent;
        

        Random random = new Random();
        public Fluss(string name)
        {
            _name = name;
            _wasserstand = random.Next(100, 10000);
        }
        public void Wasserstandänderung()
        {
            int alterstand = _wasserstand;
            _wasserstand = random.Next(100, 10000);

            Console.WriteLine($"{_name}: Der Wasserstand hat sich geändert. Neuer Wasserstand: {_wasserstand}");
            WasserstandÄnderungsEvent(this, new MyEventArgs(_wasserstand));
            Console.WriteLine();

        }

    }

    public class Schiff
    {
        private string _name;
        private Fluss _fluss;

        public Schiff(string name, Fluss fluss)
        {
            _name = name;
            _fluss = fluss;
            _fluss.WasserstandÄnderungsEvent += Stopped;
        }
        public void Stopped(object sender, MyEventArgs e)
        {
            if (e.Value < 250)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{_name} hat die Fahrt gestoppt.");
                Console.ResetColor();
            }
            else if (e.Value > 8000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{_name} hat die Fahrt gestoppt.");
                Console.ResetColor();
            }
        }
    }

    public class Stadt
    {
        private string _name;
        private Fluss _fluss;

        public Fluss GetFluss() { return _fluss; }

        public Stadt(string name, Fluss fluss)
        {
            _name =name;
            _fluss = fluss;
            _fluss.WasserstandÄnderungsEvent += Wasserschutzwand;
            
        }

        public void Wasserschutzwand(object sender, MyEventArgs e)
        {
            if (e.Value > 8200)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Die Einwohner von {_name} bauen hektisch eine Wasserschutzwand.");
                Console.ResetColor();
            }
        }
    }

    public class Klärwerk
    {
        private string _name;
        private Fluss _fluss;
        public Klärwerk(string name, Fluss fluss)
        {
            _fluss = fluss;
            _fluss.WasserstandÄnderungsEvent += Einleitungen;
        }

        public void Einleitungen(object sender, MyEventArgs e)
        {
            if (e.Value <3000)
            {
                Console.WriteLine($"Das Klärwerk {_name} steigert seine Einleitungen.");
            }
            else if (e.Value >8000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Das Klärwerk {_name} stoppt seine Einleitungen.");
                Console.ResetColor();
            }
        }

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Fluss rhein = new Fluss("Rhein");
            Fluss donau = new Fluss("Donau");
            Schiff schiff1 = new Schiff("Rheingold", rhein);
            Schiff schiff2 = new Schiff("Lorelai", rhein);
            Schiff schiff3 = new Schiff("Xaver", donau);
            Schiff schiff4 = new Schiff("Franz", donau);
            Stadt stadt1 = new Stadt("Köln", rhein);
            Stadt stadt2 = new Stadt("Düsseldorf", rhein);
            Stadt stadt3 = new Stadt("Ulm", donau);
            Klärwerk werk1 = new Klärwerk("Strauß 1", donau);
            while (true)
            {
                Console.Clear();
                rhein.Wasserstandänderung();
                donau.Wasserstandänderung();
                Console.ReadLine();
            }
        }
    }
}
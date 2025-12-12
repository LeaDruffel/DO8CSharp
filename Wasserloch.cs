namespace Wasserloch
{


    public class RaubkatzeEventArgs : EventArgs
    {
        public string Info { get; }

        public RaubkatzeEventArgs(string info)
        {
            Info = info;
        }
    }


    public class Tier
    {

    }
    public class Wächtertier :Tier
    {
       
        public event EventHandler<RaubkatzeEventArgs> RaubkatzeKommt;


        public Wächtertier()
        {
            RaubkatzeKommt += OnRaubkatzekommt;
        }
        Random random = new Random();
        public void Beobachten()
        {
            int chance = random.Next(0,2);
            if (chance == 0)
            {
                Console.WriteLine("Alles ist friedlich.");
            }
            else
            {
                RaubkatzeKommt(this, new RaubkatzeEventArgs("Raubkatze in der Nähe"));
            }

        }

        public void OnRaubkatzekommt(Object sender, RaubkatzeEventArgs e)
        {
            Console.WriteLine("Da schleicht sich etwas an. Das Wächtertier macht Sirenengeräusche!");
        }
    }
    public class Fluchttier : Tier
    {
        private Wächtertier _wt;

        public Fluchttier(Wächtertier wt)
        {
            _wt = wt;
            _wt.RaubkatzeKommt += Fliehen;
        }

        public void Fliehen(Object sender, RaubkatzeEventArgs e)
        {
            Console.WriteLine("Die Fluchttiere nehmen die Beine in die Hand!");
        }
    }
    public class Kampftier : Tier
    {
        private Wächtertier _wt;
        public Kampftier(Wächtertier wt)
        {
            _wt = wt;
            _wt.RaubkatzeKommt += Kämpfen;
        }
        public void Kämpfen(Object sender, RaubkatzeEventArgs e)
        {
    
            Console.WriteLine("Die Kampftiere zücken die Springmesser und Schlagstöcke.");
        }

    }
    public class Tarntier : Tier
    {
        private Wächtertier _wt;

        public Tarntier(Wächtertier wt)
        {
            _wt = wt;
            _wt.RaubkatzeKommt += Tarnen;
        }
        public void Tarnen(Object sender, RaubkatzeEventArgs e)
        {

            Console.WriteLine("Die Tarntiere setzen sich Brillen auf. Diese doofen mit Nase und Schnurrbart dran.");
        }

    }
    public class Raubkatze : Tier
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Wächtertier wt = new Wächtertier();
            Fluchttier ft = new Fluchttier(wt);
            Kampftier kt = new Kampftier(wt);
            Tarntier tt = new Tarntier(wt);

            while (true)
            {
                Console.Clear();
                wt.Beobachten();
                Console.ReadLine();
            }
        }
    }
}

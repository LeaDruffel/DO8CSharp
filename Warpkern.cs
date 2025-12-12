namespace Warpkern
{
    public class MyEventArgs : EventArgs
    {
        public string Operation {  get; }
        public int Value { get; }
        public int Value2 { get; }

        public MyEventArgs(string op, int val, int val2)
        {
            Operation = op;
            Value = val;
            Value2 = val2;
        }
    }
    public class Warpkern
    {
        private int _warpKernTemperatur;
        private int _prevtemp;
        public event EventHandler<MyEventArgs> TempChanged;
        public event EventHandler<MyEventArgs> TempHoch;

        Random randy = new Random();
        public Warpkern()
        {
            _warpKernTemperatur = randy.Next(100, 1000);
        }

        public void TempChange()
        {
            _prevtemp = _warpKernTemperatur;
            _warpKernTemperatur = randy.Next(100, 1000);
            if (_warpKernTemperatur > 500)
            {
                TempHoch(this, new MyEventArgs("Temperatur zu hoch!", _warpKernTemperatur, _prevtemp));
            }
            else
            {
                TempChanged(this, new MyEventArgs("Temperaturänderung.", _warpKernTemperatur, _prevtemp));

            }
        }
    }

    public class WarpKernKonsole
    {
        private Warpkern _warpkern;

        public WarpKernKonsole(Warpkern warpkern)
        {
            _warpkern = warpkern;
            _warpkern.TempChanged += TempChange;
            _warpkern.TempHoch += Warnmeldung;
        }

        public void TempChange(object sender, MyEventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Uhrzeit: ");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Operation: ");
            Console.WriteLine(e.Operation);
            Console.WriteLine("Vorherige Temperatur des Warpkerns: ");
            Console.WriteLine(e.Value2);
            Console.WriteLine("Aktuelle Temperatur des Warpkerns: ");
            Console.WriteLine(e.Value);
        }

        public void Warnmeldung(object sender, MyEventArgs e)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Uhrzeit: ");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Warnung: ");
            Console.WriteLine(e.Operation);
            Console.WriteLine("Vorherige Temperatur des Warpkerns: ");
            Console.WriteLine(e.Value2);
            Console.WriteLine("Aktuelle Temperatur des Warpkerns: ");
            Console.WriteLine(e.Value);
            Console.ResetColor();
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Warpkern warpkern = new Warpkern();
            WarpKernKonsole warpKernKonsole = new WarpKernKonsole(warpkern);

            while (true)
            {
                warpkern.TempChange();
                Console.ReadLine();
            }
        }
    }
}

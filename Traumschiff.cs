using System.Xml.Linq;

namespace Traumschiff
{
    public class Position
    {

        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Traumschiff
    {
        private static Random r = new Random();
        private static object _consoleLock = new object();
        private ConsoleColor _cc;
        private string _name;
        private Position _position;


        public Traumschiff(string name, ConsoleColor cc)
        {
            _name = name;
            _position = new Position(r.Next(0, Console.WindowWidth-name.Length), r.Next(0, Console.WindowHeight));
            _cc = cc;
            this.ZeigeSchiff();
        }

        public void ZeigeSchiff()
        {
            lock (_consoleLock)
            {

            Console.SetCursorPosition(_position.x, _position.y);
            Console.ForegroundColor = _cc;
            Console.Write(_name);
            }
        }

        public void LöscheSchiff()
        {
            lock (_consoleLock)
            {

            Console.SetCursorPosition(_position.x, _position.y);
            Console.Write(new string(' ', _name.Length));
            }
        }

        public void FahreHerum(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
            int neux = r.Next(0, Console.WindowWidth-_name.Length);
            int neuy = r.Next(0, Console.WindowHeight);

                
                while (_position.x != neux || _position.y != neuy)
                {

                    LöscheSchiff();
                    if (_position.x != neux)
                    {
                        if (_position.x < neux) _position.x++;
                        else if (_position.x > neux) _position.x--;
                    }
                    if (_position.y != neuy)
                    {
                        if (_position.y < neuy) _position.y++;
                        else if (_position.y > neuy) _position.y--;
                    }

                    ZeigeSchiff();
                    Thread.Sleep(500);
                    
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Traumschiff schiff1 = new Traumschiff("Germania", ConsoleColor.Magenta);
            Thread t1 = new Thread(schiff1.FahreHerum);
            t1.Start(10);

            Traumschiff schiff2 = new Traumschiff("Persia", ConsoleColor.Blue);
            Thread t2 = new Thread(schiff2.FahreHerum);
            t2.Start(10);

            Traumschiff schiff3 = new Traumschiff("Helvetica", ConsoleColor.Yellow);
            Thread t3 = new Thread(schiff3.FahreHerum);
            t3.Start(10);
            Console.ReadKey();
        }
    }
}

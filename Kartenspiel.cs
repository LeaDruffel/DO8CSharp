using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kartenspiel
{
    public class Karte
    {
        public string _farbe;
        public string _wert;

        public Karte(string farbe, string wert)
        {
            _farbe = farbe;
            _wert = wert;
        }
    }

    internal class Program
    {
        public static void KartenZeigen(Stack<Karte> karten)
        {
            Console.WriteLine("Dieser Stapel: ");
            foreach (Karte karte in karten)
            {
                Console.Write(karte._farbe + " ");
                Console.WriteLine(karte._wert);
                Console.WriteLine();
            }
        }
        public static List<Stack<Karte>> StapelTeilen(Stack<Karte> stapel, int teilstapel)
        {
            List<Stack<Karte>> stapel_ = new List<Stack<Karte>>();
            for (int i = 0; i < teilstapel; i++)
            {
                Stack<Karte> teil = new Stack<Karte> ();
                stapel_.Add (teil);
            }

            for (int i = 0; i < (stapel.Count); i++)
            {
                foreach (var stack in stapel_)
                {
                    stack.Push(stapel.Pop());
                }
            }

            return stapel_;
        }
        static void Main(string[] args)
        {
            Karte peins = new Karte("Pik", "7");
            Karte pzwei = new Karte("Pik", "8");
            Karte pdrei = new Karte("Pik", "9");
            Karte pvier = new Karte("Pik", "19");
            Karte pfünf = new Karte("Pik", "Bube");
            Karte psechs = new Karte("Pik", "Dame");
            Karte psieben = new Karte("Pik", "König");
            Karte pacht = new Karte("Pik", "Ass");

            Karte heins = new Karte("Herz", "7");
            Karte hzwei = new Karte("Herz", "8");
            Karte hdrei = new Karte("Herz", "9");
            Karte hvier = new Karte("Herz", "19");
            Karte hfünf = new Karte("Herz", "Bube");
            Karte hsechs = new Karte("Herz", "Dame");
            Karte hsieben = new Karte("Herz", "König");
            Karte hacht = new Karte("Herz", "Ass");

            Karte kaeins = new Karte("Karo", "7");
            Karte kazwei = new Karte("Karo", "8");
            Karte kadrei = new Karte("Karo", "9");
            Karte kavier = new Karte("Karo", "19");
            Karte kafünf = new Karte("Karo", "Bube");
            Karte kasechs = new Karte("Karo", "Dame");
            Karte kasieben = new Karte("Karo", "König");
            Karte kaacht = new Karte("Karo", "Ass");

            Karte kreins = new Karte("Kreuz", "7");
            Karte krzwei = new Karte("Kreuz", "8");
            Karte krdrei = new Karte("Kreuz", "9");
            Karte krvier = new Karte("Kreuz", "19");
            Karte krfünf = new Karte("Kreuz", "Bube");
            Karte krsechs = new Karte("Kreuz", "Dame");
            Karte krsieben = new Karte("Kreuz", "König");
            Karte kracht = new Karte("Kreuz", "Ass");

            Stack<Karte> herz = new Stack<Karte>();
            herz.Push(heins);
            herz.Push(hzwei);
            herz.Push(hdrei);
            herz.Push(hvier);
            herz.Push(hfünf);
            herz.Push(hsechs);
            herz.Push(hsieben);
            herz.Push(hacht);

            

            Stack<Karte> pik = new Stack<Karte>();
            pik.Push(peins);
            pik.Push(pzwei);
            pik.Push(pdrei);
            pik.Push(pvier);
            pik.Push(pfünf);
            pik.Push(psechs);
            pik.Push(psieben);
            pik.Push(pacht);

            

            Stack<Karte> herzpik = new Stack<Karte>();
            for (int i = 0; i < 8; i++)
            {
                herzpik.Push(herz.Pop());
                herzpik.Push(pik.Pop());
            }

            

            Stack<Karte> eins = new Stack<Karte>();
            Stack<Karte> zwei = new Stack<Karte>();
            Stack<Karte> drei = new Stack<Karte>();
            Stack<Karte> vier = new Stack<Karte>();

            for (int i = 0; i < 4; i++)
            {
                eins.Push(herzpik.Pop());
                zwei.Push(herzpik.Pop());
                drei.Push(herzpik.Pop());
                vier.Push(herzpik.Pop());
            }
            
            for (int i = 0;i < 4;i++)
            {
                drei.Push(eins.Pop());
                
            }

            for (int i = 0; i < 4; i++)
            {
                vier.Push(zwei.Pop());
            }
            

            for (int i = 0; i < 8; i++)
            {
                vier.Push(drei.Pop());
            }

            List<Stack<Karte>> neu = StapelTeilen(vier, 4);

            foreach (var stack in neu)
            {
                KartenZeigen(stack);
            }
        }
    }
}

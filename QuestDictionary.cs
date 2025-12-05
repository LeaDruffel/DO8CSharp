using System.Diagnostics;
using System.Reflection.Metadata;

namespace Quest_Dictionary
{

    public abstract class Item
    {
        protected string _name;
        protected string _description;
        public string GetName()
        {
            return _name;
        }
    }

    public class Uniform : Item
    {
        public Uniform()
        {
            _name = "Uniform der Wache von Gondor";
            _description = "Ein weißes Abzeichen auf schwarzem Mantel, das ihn als Diener der Stadt ausweist.";
        }
    }
    public class Fackel: Item
    {
        public Fackel()
        {
            _name = "Fackel der Wachen";
            _description = "Um das erste Feuer zu entzünden (erhalten durch seinen Dienst).";
        }
    }
    public class Wasser: Item
    {
        public Wasser()
        {
            _name = "Wasser aus dem Brunnen des Hofes";
            _description = "Um Faramir zu benetzen und ihn wachzuhalten.";
        }
    }
    public class Lanze : Item
    {
        public Lanze()
        {
            _name = "Lanze der Wache";
            _description = "Kein Mittel zum Kampf, sondern Zeichen seiner Verpflichtung.";
        }
    }
    public class Brot : Item
    {
        public Brot()
        {
            _name = "Brot der Stadt";
            _description = "(Lembas-ähnlich) – um die Nachtwache zu überstehen, ohne zu schwanken.";
        }
    }
    public class Harz : Item
    {
        public Harz()
        {
            _name = "Harz der ewigen Kiefer";
            _description = "Beschleunigt die Entzündung auf den nassen Gipfeln.";
        }
    }
    public class Trompete : Item
    {
        public Trompete()
        {
            _name = "Trompete der Stadtwache";
            _description = "Um Verstärkung zu rufen.";
        }
    }
    public class Schwert : Item
    {
        public Schwert()
        {
            _name = "Schwert 'Kurzbeil'";
            _description = "(seine Waffe) – nicht zum Töten, sondern um den Weg freizukämpfen.";
        }
    }
    public class QuestReward
    {
        
        private List<Item> _itembelohnung;
        private int _weisheit;

        public int GetWeisheit() { return _weisheit; }
        public List<Item> GetItems() { return _itembelohnung; }
        public QuestReward(int weisheit)
        {
            _weisheit = weisheit;
        }
      
        public QuestReward(int weisheit, List<Item> itembelohnung)
        {
            _weisheit = weisheit;
            _itembelohnung = itembelohnung;
        }
    }

    public class Quest
    {
        private string _name;
        private string _description;
        private List<string> _itemsnötig;
        private QuestReward _reward;

        public string GetName() { return _name; }
        public string GetDescription() { return _description; }
        public List<string> GetItems() { return _itemsnötig; }
        public QuestReward GetReward() {return _reward; }



        public Quest(string name, string description, QuestReward reward, List<string> itemsnötig)
        {
            _name=name;
            _reward = reward;
            _itemsnötig = itemsnötig;
            _description = description;
        }
    }
    public class Hobbit
    {
        private string _name;
        private List<Item> _inventar;
        private int _weisheitslevel;
        public Hobbit(string name)
        {
            _name = name;
            _inventar = new List<Item>();
            _weisheitslevel = 0;
        }

        public void ItemKriegen(Item item)
        {
            _inventar.Add(item);
        }

        public void AufgabeErledigen(Quest quest)
        {
            foreach (string item in quest.GetItems())
            {
                bool isda = false;
                for (int i = 0; i < _inventar.Count; i++)
                {
                    if (item == _inventar[i].GetName())
                    {
                        isda = true;
                    }
                }
                if (!isda)
                {
                    Console.WriteLine($"Du hast nicht alle erforderlichen Items für die Quest '{quest.GetName()}'.");
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine($"Du hast die Quest '{quest.GetName()}' erledigt. Dir werden {quest.GetReward().GetWeisheit()} Weisheitspunkte gutgeschrieben.");
            if (quest.GetReward().GetItems() != null)
            {
                Console.WriteLine("Folgende Gegenstände bekommst du zur Belohnung: ");
                foreach (Item item in quest.GetReward().GetItems())
                {
                    _inventar.Add((Item)item);
                    Console.WriteLine(item.GetName());
                }
                _weisheitslevel += quest.GetReward().GetWeisheit();
                Console.WriteLine();
            }

        }

        public int LVL()
        {
            return _weisheitslevel/100;
        }
    }
    internal class Program
    {
        public static char CharEingabe(string aufforderung)
        {

            Console.WriteLine(aufforderung);
            while (true)
            {
                string input = Console.ReadLine();
                input = input.ToLower();
                try
                {
                    char c = char.Parse(input);

                    return c;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Keine Eingabe erkannt. Bitte triff eine Auswahl.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Die Eingabe ist ungültig. Bitte triff eine Auswahl.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Die Eingabe ist ungültig. Bitte triff eine Auswahl.");
                }
            }
        }
        static void Main(string[] args)
        {   
            //Alle Items initialisieren

            Uniform uniform = new Uniform();
            Lanze lanze = new Lanze();
            Brot brot = new Brot();
            Fackel fackel = new Fackel();
            Harz harz = new Harz();
            Wasser wasser = new Wasser();
            Trompete trompete = new Trompete();
            Schwert schwert = new Schwert();
            //Erste Quest
            List<string> questeinsitems = new List<string>();
            questeinsitems.Add(uniform.GetName());
            questeinsitems.Add(lanze.GetName());
            questeinsitems.Add(brot.GetName());
            List<Item> itembelohneins = new List<Item>();
            itembelohneins.Add(fackel);
            itembelohneins.Add(harz);
            itembelohneins.Add(wasser);
            QuestReward rewardquesteins = new QuestReward(100, itembelohneins);
            Quest questeins = new Quest("Die Wache für Bergil – „Der Dienst am Tor“", "Pippin verspricht dem jungen Bergil, dessen Vater in der Schlacht ist, Wache am Tor von Minas Tirith zu halten – nicht aus Pflicht, sondern aus Freundschaft und Respekt. Er dient unter Hauptmann Hador und bleibt wachsam, während die Schatten über das Land kriechen.", rewardquesteins, questeinsitems);

            //Zweite Quest
            List<string> questzweiitems = new List<string>();
            questzweiitems.Add(fackel.GetName());
            questzweiitems.Add(harz.GetName());

            List<Item> itembelohnzwei = new List<Item>();
            itembelohnzwei.Add(trompete);
            itembelohnzwei.Add(schwert);
            QuestReward rewardquestzwei = new QuestReward(300, itembelohnzwei);
            Quest questzwei = new Quest("Die Flammen der Hoffnung – „Entzünde die Leuchtfeuer von Gondor“", "Als die Schatten Mordors heranziehen und Minas Tirith von Feinden umringt ist, muss ein Zeichen der Not gesandt werden – an Rohan. Doch Statthalter Denethor zögert. Es ist Gandalf, der den Befehl erteilt: Die Leuchtfeuer müssen entzündet werden!\r\nPippin, als Diener Gondors, eilt von Turm zu Turm – nicht allein, doch als Teil jener, die das Licht weitertragen. Er muss sicherstellen, dass jede Feuerstelle brennt und die Flammen von Berg zu Berg springen.", rewardquestzwei, questzweiitems);

            //Quest dreii
            List<string> questdreiitems = new List<string>();
            questdreiitems.Add(wasser.GetName());
            questdreiitems.Add(trompete.GetName());
            questdreiitems.Add(schwert.GetName());

            QuestReward rewardquestdrei = new QuestReward(250);
            Quest questdrei = new Quest("Der Dienst bei Denethor – „Die Rettung aus dem Feuertod“", "Pippin begleitet Denethor, den gebrochenen Statthalter, in die Kammer, in der Faramir dem Scheiterhaufen übergeben werden soll. Er ruft nach Gandalf, kämpft gegen die Wachen des Wahnsinns und hilft, Faramir zu retten – im letzten Moment.", rewardquestdrei, questdreiitems);

            //Dictionary warum auch immer
            Dictionary<string, Quest> BuchDerAufgaben = new Dictionary<string, Quest>();
            BuchDerAufgaben.Add(questeins.GetName(), questeins);
            BuchDerAufgaben.Add(questzwei.GetName(), questzwei);
            BuchDerAufgaben.Add(questdrei.GetName(), questdrei);

            //Aufgaben inne Warteschlange
            Queue<Quest> warteschlange = new Queue<Quest>();

            foreach (var item in BuchDerAufgaben)
            {
                warteschlange.Enqueue(item.Value);
            }

            //Pippin Sachen geben
            Hobbit pippin = new Hobbit("Pippin");
            Uniform uni = new Uniform();
            Lanze lan = new Lanze();
            Brot bro = new Brot();
            pippin.ItemKriegen(uni);
            pippin.ItemKriegen(lan);
            pippin.ItemKriegen(bro);

            //Ausprobieren
            //pippin.AufgabeErledigen(warteschlange.Dequeue());
            //pippin.AufgabeErledigen(warteschlange.Dequeue());
            //pippin.AufgabeErledigen(warteschlange.Dequeue());
            //Console.WriteLine(pippin.LVL());

            //Es mit einem Spiel versuchen
            Console.WriteLine("„Drei Ringe den Elbenkönigen, hoch im Licht…“\r\nDoch lange nach den Zeiten der alten Bundes, als die Schatten erneut über Mittelerde kriechen, erwacht ein vergessenes Artefakt: Das Buch der verborgenen Wege, verborgen in den Tiefen von Minas Tirith, tief unter der Bibliothek der Weisen.\r\nDieses uralte Werk birgt nicht Schicksale von Ringen – nein – es birgt die Aufgaben, die die neuen Hüter des Guten erfüllen müssen, um das Gleichgewicht zu wahren. Kein Krieger, kein Zauberer, kein Hobbit wird ohne Prüfung erwählt.\r\nDas Buch ist lebendig. Es spricht nur zu denen, die den Mut haben, die Struktur der Wahrheit zu erkennen.\r\n");
            char eingabe ='x';
            while (eingabe != 'c')
            {
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("a. Anstehende Prüfung begutachten");
            Console.WriteLine("b. Anstehende Prüfung erledigen");
            Console.WriteLine("c. Buch zumachen und deiner Wege gehen");
            Console.WriteLine();
                eingabe = CharEingabe("Triff deine Wahl:");
                switch (eingabe)
                {
                    case 'a':
                        if (warteschlange.TryPeek(out Quest result))
                        {
                        Console.WriteLine("Die nächste Prüfung hält folgendes für dich bereit:");
                        Console.WriteLine($"Quest: {(warteschlange.Peek()).GetName()}");
                        Console.WriteLine((warteschlange.Peek()).GetDescription());
                        Console.WriteLine();
                        } else
                        {
                            Console.WriteLine("Es stehen keine weiteren Quests an.");
                            Console.WriteLine("Das Buch seufzt zufrieden. Alle Prüfungen sind bestanden.");
                            return;
                        }
                            break;
                    case 'b':
                        if (warteschlange.TryPeek(out result))
                        {
                        Console.WriteLine($"Du machst dich auf, die Quest {(warteschlange.Peek()).GetName()} zu bestreiten.");
                        pippin.AufgabeErledigen(warteschlange.Dequeue());
                        Console.WriteLine();

                        }
                        else
                        {
                            Console.WriteLine("Es stehen keine weiteren Quests an.");
                            Console.WriteLine("Das Buch seufzt zufrieden. Alle Prüfungen sind bestanden.");
                            return;
                        }
                            break;
                    case 'c':
                        if (warteschlange.TryPeek(out result))
                        {
                        Console.WriteLine("Dann geh halt weg. Das Buch schnauft beleidigt.");
                        Console.WriteLine();

                        } else
                        {
                            Console.WriteLine("Das Buch seufzt zufrieden. Alle Prüfungen sind bestanden.");
                        }
                            break;

                }
            }
            

        }
    }
}

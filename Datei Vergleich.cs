using System.Diagnostics;
using System.IO;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Datei_Vergleich
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text1 = File.ReadAllText("Text1.txt");
            string text4 = File.ReadAllText("Text4.txt");
            

            //Version1
            if (text1 == text4)
            {
                Console.WriteLine("Text 1 und Text 4 sind identisch");

            }
           else if (text1 != text4)
            {
                Console.WriteLine("Text 1 und Text 4 sind nicht identisch");
                
            }


            //Version2
            using (StreamReader sr = File.OpenText("Text1.txt"))
            using (StreamReader sr2 = File.OpenText("Text3.txt"))
            {
                int zeile = 0;
                while (true)
                {
                    string zeile1 = sr.ReadLine();
                    string zeile2 = sr2.ReadLine();
                    zeile++;

                    if (zeile1 != zeile2)
                    {
                        Console.WriteLine($"Die Texte sind nicht identisch. Erste Abweichung gefunden in Zeile {zeile}");
                        break;
                    }
                }
            }

            //Version3
            using (StreamReader sr = File.OpenText("Text1.txt"))
            using (StreamReader sr2 = File.OpenText("Text4.txt"))
            {
                int zeile = 0;
                int abw = 0;
                string zeile1;
                string zeile2;
                while (true)
                {
                    zeile++;

                    if ((zeile1 = sr.ReadLine()) != (zeile2 = sr.ReadLine()))
                    {
                        abw++;                        
                    }
                    if ((zeile1 = sr.ReadLine()) != null && (zeile2 = sr.ReadLine()) != null)
                    {
                        break;
                    }
                }

                if (abw == 0)
                {
                    Console.WriteLine("Keine Abweichungen");
                }
                Console.WriteLine($"Anzahl abweichender Zeilen: {abw} ");
            }
        }
    }
}

namespace AufgabeWarenkorb
{
    public enum Länder { USA, GB, Germany }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kunde[] kunden = Kunde.GetKundenListe();
            Produkt[] produkte = Produkt.GetProduktListe();


            //Aufgabe a
            var produktnamen =
                 produkte
                 .Select(produkt => produkt.Name);

            var produktnamen2 =
                from produkt in produkte
                select produkt.Name;

            var namewohnort =
                kunden
                .Select(kunde => new { kunde.Name, kunde.Ort });

            var namewohnort2 =
                from kunde in kunden
                select new { kunde.Name, kunde.Ort };

            foreach (var item in namewohnort2)
            {
                Console.WriteLine(item);
            }

            //Aúfgabe b
            var ausDe =
                kunden
                .Where(kunde => kunde.Land == Länder.Germany)
                .Select(kunde => kunde);

            var ausDe2 =
                from kunde in kunden
                where kunde.Land == Länder.Germany
                select kunde;

            //Aufgabe c

            var jederzweite =
                kunden
                .Where((kunde, Index) => Index % 2 == 0)
                .Select(kunde => kunde.Name);

            //Aufgabe d
            var günstigerzwanzig =
                produkte
                .OrderByDescending(produkt => produkt.Preis)
                .Where(produkt => produkt.Preis <= 20)
                .Select(produkt => new { produkt.Name, produkt.Preis });


            var günstigerzwanzig2 =
                from produkt in produkte
                orderby produkt.Preis descending
                where produkt.Preis <= 20
                select new { produkt.Name, produkt.Preis, };

            //Aufgabe e
            var nameland =
                kunden
                .OrderBy(kunde => kunde.Land)
                .ThenBy(kunde => kunde.Name)
                .Select(kunde => new { kunde.Name, kunde.Land });

            var nameland2 =
                from kunde in kunden
                orderby kunde.Land, kunde.Name
                select new { kunde.Name, kunde.Land };

            //Aufgabe f
            var nachland =
                kunden
                .GroupBy(kunde => kunde.Land)
                .Select(kunde => kunde);

            var nachland2 =
                from kunde in kunden
                group kunde by kunde.Land into g
                from kunde in g
                select kunde;


            //Aufgabe g
            var nachnamen =
                produkte
                .GroupBy(produkt => produkt.Name[0])
                .Select(g => g.Select(produkt => produkt.Name));

            var nachnamen2 =
                from p in produkte
                group p by p.Name[0] into g
                from produkt in g
                select produkt.Name;

            //Aufgabe h
            var join =
                kunden
                .SelectMany(k => k.Bestellungen, (k, b) => new { k, b })
                .Join(produkte, kb => kb.b.ProduktNr,
                                p => p.ProduktNr,
                                (kb, p) => new { Monat = kb.b.Monat, ProduktNr = p.ProduktNr, Name = p.Name, Preis = p.Preis, Versendet = kb.b.Versendet })
                .OrderBy(p => p.Preis);

            var join2 =
                from kunde in kunden
                from best in kunde.Bestellungen
                join produkt in produkte on best.ProduktNr equals produkt.ProduktNr
                orderby produkt.Preis
                select new { Monat = best.Monat, ProduktNr = produkt.ProduktNr, Name = produkt.Name, Preis = produkt.Preis, Versendet = best.Versendet };

            //Aufgabe i
            var aufgabei =
                kunden
                .Select(kunde => new { Name = kunde.Name, Wohnort = kunde.Ort, AnzBestell = kunde.Bestellungen.Length });

            var aufgabei2 =
                from kunde in kunden
                select new { Name = kunde.Name, Wohnort = kunde.Ort, AnzBestell = kunde.Bestellungen.Length };

            //Aufgabe j
            var summepreise =
                produkte
                .Sum(p => p.Preis);

            var summepreise2 =
                (from p in produkte
                 select p.Preis).Sum();

            //Aufgabe k
            var aufgabek =
                kunden
                .Select(kunde => new
                {
                    Kunde = kunde,
                    Gesamtbetrag = kunde.Bestellungen.Join(produkte, best => best.ProduktNr, prod => prod.ProduktNr, (b, p) => p.Preis * b.Anzahl)
                .Sum()
                });
                
                
                









        }
    }

}

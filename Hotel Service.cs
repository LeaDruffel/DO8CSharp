using System;
using System.Globalization;
using System.Text;

namespace Hotel_Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string daten = File.ReadAllText("data_hotel.txt");
            Dictionary<int, decimal> data = new Dictionary<int, decimal>();
            string[] parts = daten.Split('\n');

            for (int i = 0; i < parts.Length; i++)
            {
                string[] temp = parts[i].Split(',');
                data.Add(int.Parse(temp[0]), Convert.ToDecimal(temp[1], CultureInfo.InvariantCulture));
            }


            foreach (var item in data)
            {

                Console.WriteLine($"WKN = {item.Key}, EUR = {item.Value}, DM = {item.Value * 1.95583m:F2}");
                
                
            }
        }
    }
}

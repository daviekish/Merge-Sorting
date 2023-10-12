using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "ID", 6000001 }, { "Name", "David Njoroge" },    { "Gender", "Male" },   { "Age", 45 } },
                new Dictionary<string, object> { { "ID", 6000002 }, { "Name", "Margaret Njoroge" }, { "Gender", "Female" }, { "Age", 35 } },
                new Dictionary<string, object> { { "ID", 6000011 }, { "Name", "Rawlings Mayan" },   { "Gender", "Male" },   { "Age", 25 } }
            };

            data = data.OrderBy(item => (int)item["ID"]).ToList();
            Console.WriteLine("ID\tName\t\t\tGender\tAge");


            foreach (var item in data)
            {
                Console.WriteLine($"{item["ID"]}\t{item["Name"]}\t{item["Gender"]}\t{item["Age"]}");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

}

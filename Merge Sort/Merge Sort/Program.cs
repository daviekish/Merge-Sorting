using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    public class Program
    {
        static void Main()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "ID", 6000123 }, { "Name", "David Njoroge" },{ "Gender", "Male" },  { "Age", 45 }, {"Bill", 30000}, {"DPD", 112}, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000002 }, { "Name", "Martha Njoroge" }, { "Gender", "Female" }, { "Age", 35 }, {"Bill", 230000}, {"DPD", 172}, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000011 }, { "Name", "Rawlingmans Mayan" }, { "Gender", "Male" },   { "Age", 25 }, {"Bill", 230000}, {"DPD", 232 }, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000021 }, { "Name", "Ferd Mayan" }, { "Gender", "Male" },   { "Age", 30 }, {"Bill", 230000}, {"DPD", 112 }, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000031 }, { "Name", "Bill Fridig" }, { "Gender", "Male" },   { "Age", 49 }, {"Bill", 4030000}, {"DPD", 172 }, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000032 }, { "Name", "Run Maian" }, { "Gender", "Male" },   { "Age", 50 }, {"Bill", 230000}, {"DPD", 232 }, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000045 }, { "Name", "Xenia Mayini" }, { "Gender", "Male" },   { "Age", 23 }, {"Bill", 230000}, {"DPD", 112}, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000046 }, { "Name", "Paul Mayona" }, { "Gender", "Male" },   { "Age", 32 }, {"Bill", 230000}, {"DPD", 232 }, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000001 }, { "Name", "Peter Maina" }, { "Gender", "Male" },   { "Age", 25 }, {"Bill", 230000}, {"DPD", 232 }, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000035 }, { "Name", "Clinton fyan" }, { "Gender", "Male" },   { "Age", 30 }, {"Bill", 230000}, {"DPD", 112 }, {"Disposition", "RNR" }},
                new Dictionary<string, object> { { "ID", 6000023 }, { "Name", "Collins Rina " }, { "Gender", "Male" },   { "Age", 25 }, {"Bill", 230000}, { "DPD", 172}, { "Disposition", "RNR" }}
            };

            // Edit the list
            Dictionary<int, int> maxBillByID = new Dictionary<int, int>();
            Dictionary<int, int> dpdSubtotals = new Dictionary<int, int>();
            
            int totalBills = 0;
            int entryCount = 0;
            foreach (var item in data)
            {
                int id = (int)item["ID"];
                int bill = (int)item["Bill"];
                int dpd = (int)item["DPD"];
                
                

                if (!maxBillByID.ContainsKey(id) || bill > maxBillByID[id])
                {
                    maxBillByID[id] = bill;
                }

                //update analysis variables
                totalBills += bill;
                entryCount++;
                if (dpdSubtotals.ContainsKey(dpd))
                {
                    dpdSubtotals[dpd] += bill; //add to exsisting subtotal
                }

                else
                {
                    dpdSubtotals[dpd] = bill; // initialize subtotal for the DPD
                }
            }

            data = data
                .OrderBy(item => item["ID"])
                .Where(item => (int)item["Bill"] == maxBillByID[(int)item["ID"]])
                .ToList();

            Console.WriteLine("ID\tName\t\t\t\tGender\tAge\tBill\tDPD\tDisposition");

            foreach (var item in data)
            {
                Console.WriteLine($"{item["ID"]}\t{item["Name"],-25}\t{item["Gender"]}\t{item["Age"]}\t{item["Bill"]}\t{item["DPD"]}\t{item["Disposition"]}");
            }
            Console.WriteLine();
            Console.WriteLine($"Total Entries: {entryCount}");
            Console.WriteLine($"Total Bills : {totalBills} ");
            Console.WriteLine();
            Console.WriteLine("DPD\tSubtotal Bill");

            foreach (var dpdSubtotal in dpdSubtotals)
            {
                Console.WriteLine($"{dpdSubtotal.Key}\t{dpdSubtotal.Value}");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); 
        }
    }

}

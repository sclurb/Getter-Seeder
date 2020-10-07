using Getter_Seeder.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Getter_Seeder
{
    public class Program
    {
        private static GetData rom = new GetData();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

           // rom.DeleteReadings();

            var result = rom.GetAllStuff();

            var result1 = result.OrderByDescending(d => d.Id).Take(200);
            

            List<Reading> seed = new List<Reading>();


            var readings = rom.getReadingsByDate(new DateTime(2018, 08, 01), new DateTime(2018, 08, 02));

            foreach (var reading in readings.OrderBy(y => y.Date.Year)
                                             .ThenBy(m => m.Date.Month)
                                             .ThenBy(d => d.Date.Day)
                                             .ThenBy(h => h.Date.Hour)
                                             .ThenBy(m => m.Date.Minute))
            {
                Console.WriteLine($"Temperature outside: {reading.Temp4} on {reading.Date}");
            }

            //foreach (var row in result.Skip(00000).Take(50000))
            //    foreach (var row in result) //2
            //{
                
            //    Reading r = new Reading();
            //    {
            //        r.Id = row.Id;
            //        r.Hum1 = (decimal)row.Hum1;
            //        r.Hum2 = (decimal)row.Hum2;
            //        r.Hum3 = (decimal)row.Hum3;
            //        r.Hum4 = (decimal)row.Hum4;
            //        r.Temp1 = (decimal)row.Temp1;
            //        r.Temp2 = (decimal)row.Temp2;
            //        r.Temp3 = (decimal)row.Temp3;
            //        r.Temp4 = (decimal)row.Temp4;
            //        r.Date = row.Date;
            //        Console.WriteLine($" list Id is: { r.Id} row id is: {row.Id}");
            //    };
            //    seed.Add(r);
            //}
            //rom.InsertReadings(seed);
 

            Console.WriteLine("It is Done");
            Console.ReadKey();
        }
    }
}

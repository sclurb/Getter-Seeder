using Getter_Seeder.Data;
using Getter_Seeder.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Getter_Seeder
{
    public class GetData
    {
        private GetContext _ctx = new GetContext();
        private SeedContext _seedtx = new SeedContext();
        public GetData()
        {
                
        }

        public DbSet<Stuff> GetAllStuff()
        {
            var result = _ctx.Stuff;
            return result;
        }

        public List<Reading> getReadingsByDate(DateTime begin, DateTime end)
        {
            var result = _seedtx.Readings.Where(d => d.Date > begin && d.Date < end);
            return result.ToList();
        }

        public int InsertReadings(List<Reading> readings)
        {
            int count = 0;
            int masterCount = readings.Count();
            int linesAdded = 0;
            foreach (var reading in readings)
            {
                Reading newRead = new Reading();
                if (reading.Hum1 > 150)
                {
                    reading.Hum1 = 0;
                }

                newRead.Hum1 = reading.Hum1;
                newRead.Hum2 = reading.Hum2;
                newRead.Hum3 = reading.Hum3;
                newRead.Hum4 = reading.Hum4;
                newRead.Temp1 = reading.Temp1;
                newRead.Temp2 = reading.Temp2;
                newRead.Temp3 = reading.Temp3;
                newRead.Temp4 = reading.Temp4;
                newRead.Date = reading.Date;
                _seedtx.Readings.Add(newRead);
                masterCount--;
                linesAdded++;
                count++;
                if (count == 50000 || masterCount == 0)
                {
                    _seedtx.Readings.OrderBy(d => d.Date.Year)
                        .ThenBy(m => m.Date.Month)
                        .ThenBy(d => d.Date.Day)
                        .ThenBy(h => h.Date.Hour)
                        .ThenBy(t => t.Date.Minute);
                    _seedtx.SaveChanges();
                    count = 0;
                    Console.WriteLine($"Lines added are: {linesAdded} Master count is: {masterCount}");
                }
            }
            return linesAdded;
        }

        public int DeleteReadings()
        {
            var readings = _seedtx.Readings;

            foreach (var reading in readings)
            {
                _seedtx.Readings.Remove(reading);
            }
            
            return _seedtx.SaveChanges();
        }
    }
}

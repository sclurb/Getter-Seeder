﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Getter_Seeder.Domain
{
    public class Reading
    {
        public int Id { get; set; }
        public decimal Temp1 { get; set; }
        public decimal Temp2 { get; set; }
        public decimal Temp3 { get; set; }
        public decimal Temp4 { get; set; }
        public decimal Hum1 { get; set; }
        public decimal Hum2 { get; set; }
        public decimal Hum3 { get; set; }
        public decimal Hum4 { get; set; }
        public DateTime Date { get; set; }
    }
}

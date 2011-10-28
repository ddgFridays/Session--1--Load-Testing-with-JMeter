using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoadTestDemo.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public string Club { get; set; }
        public string Position { get; set; }
        public decimal Value { get; set; }
        public int Points { get; set; }
        public int WeekPoints { get; set; }
        public string ImageName { get; set; }
    }
}
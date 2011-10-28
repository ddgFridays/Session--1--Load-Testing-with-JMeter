using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoadTestDemo.Models
{
    public class TeamModel
    {
        public string Name { get; set; }
        public List<PlayerModel> Players { get; set; }
        public int Points { get { return Players.Sum(p => p.Points); } }
    }
}
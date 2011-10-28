using System.Collections.Generic;

namespace LoadTestDemo.Models
{
    public class TeamRepository : ITeamRepository
    {
        public TeamModel GetByUser(string userName)
        {
            return new TeamModel
            {
                Name = "DDG XI",
                Players = new List<PlayerModel>
                {
                    new PlayerModel { Name = "Krul", Club = "Newcastle", Position = "Goal Keeper", Value = 4.6m, Points = 30, WeekPoints = 2, ImageName = "krul.jpg" },
                    new PlayerModel { Name = "TaylorR", Club = "Newcastle", Position = "Defender", Value = 4.4m, Points = 28, WeekPoints = 2, ImageName = "taylor_r.jpg" },
                    new PlayerModel { Name = "Ward", Club = "Wolves", Position = "Defender", Value = 4.8m, Points = 27, WeekPoints = 1, ImageName = "ward.jpg" },
                    new PlayerModel { Name = "Bosingwa", Club = "Chelsea", Position = "Defender", Value = 6.0m, Points = 27, WeekPoints = 2, ImageName = "bosingwa.jpg" },
                    new PlayerModel { Name = "Young", Club = "Man United", Position = "Midfielder", Value = 10.3m, Points = 36, WeekPoints = 9, ImageName = "young.jpg" },
                    new PlayerModel { Name = "Silva", Club = "Man City", Position = "Midfielder", Value = 9.9m, Points = 31, WeekPoints = 11, ImageName = "silva.jpg" },
                    new PlayerModel { Name = "Jarvis", Club = "Wolves", Position = "Midfielder", Value = 6.4m, Points = 26, WeekPoints = 2, ImageName = "jarvis.jpg" },
                    new PlayerModel { Name = "Petrov", Club = "Bolton", Position = "Midfielder", Value = 5.7m, Points = 25, WeekPoints = 7, ImageName = "petrov.jpg" },
                    new PlayerModel { Name = "Rooney", Club = "Man United", Position = "Forward", Value = 12.4m, Points = 55, WeekPoints = 12, ImageName = "rooney.jpg" },
                    new PlayerModel { Name = "Aguero", Club = "Man City", Position = "Forward", Value = 11.1m, Points = 40, WeekPoints = 15, ImageName = "aguero.jpg" },
                }
            };
        }
    }
}
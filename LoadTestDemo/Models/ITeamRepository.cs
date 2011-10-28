using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoadTestDemo.Models
{
    public interface ITeamRepository
    {
        TeamModel GetByUser(string userName);
    }
}
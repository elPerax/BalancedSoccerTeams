using System.Collections.Generic;
using BalancedSoccerTeams.Models;

namespace BalancedSoccerTeams.ViewModels
{
    public class TeamResultViewModel
    {
        public int TeamNumber { get; set; }
        public List<Player> Players { get; set; } = new();
        public double TotalScore { get; set; }
    }
}

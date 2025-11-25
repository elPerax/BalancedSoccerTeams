using System.Collections.Generic;
using BalancedSoccerTeams.Models;

namespace BalancedSoccerTeams.ViewModels
{
    public class TeamGeneratorViewModel
    {
        public List<Player> AllPlayers { get; set; } = new();

        public List<int> SelectedPlayerIds { get; set; } = new();

        public int NumberOfTeams { get; set; } = 2;

        public List<TeamResultViewModel>? GeneratedTeams { get; set; }
    }
}

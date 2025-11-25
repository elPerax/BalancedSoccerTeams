using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BalancedSoccerTeams.Data;
using BalancedSoccerTeams.ViewModels;

namespace BalancedSoccerTeams.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var vm = new TeamGeneratorViewModel
            {
                AllPlayers = await _context.Players.ToListAsync(),
                NumberOfTeams = 2
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(TeamGeneratorViewModel model)
        {
            if (model.NumberOfTeams < 1)
            {
                ModelState.AddModelError(nameof(model.NumberOfTeams),
                    "Number of teams must be at least 1.");
            }

            var selectedPlayers = await _context.Players
                .Where(p => model.SelectedPlayerIds.Contains(p.Id))
                .ToListAsync();

            if (!selectedPlayers.Any())
            {
                ModelState.AddModelError(string.Empty,
                    "You must select at least one player.");
            }

            if (!ModelState.IsValid)
            {
                model.AllPlayers = await _context.Players.ToListAsync();
                return View(model);
            }

            model.GeneratedTeams = GenerateBalancedTeams(selectedPlayers, model.NumberOfTeams);
            model.AllPlayers = await _context.Players.ToListAsync();

            return View(model);
        }

        private static System.Collections.Generic.List<TeamResultViewModel> GenerateBalancedTeams(
            System.Collections.Generic.List<Models.Player> players,
            int numberOfTeams)
        {
            
            var sorted = players
                .OrderByDescending(p => p.OverallScore)
                .ToList();

            var teams = new System.Collections.Generic.List<TeamResultViewModel>();
            for (int i = 0; i < numberOfTeams; i++)
            {
                teams.Add(new TeamResultViewModel
                {
                    TeamNumber = i + 1
                });
            }

          
            int direction = 1; 
            int teamIndex = 0;

            foreach (var player in sorted)
            {
                var team = teams[teamIndex];
                team.Players.Add(player);
                team.TotalScore += player.OverallScore;

                teamIndex += direction;

                if (teamIndex == numberOfTeams)
                {
                    direction = -1;
                    teamIndex = numberOfTeams - 1;
                }
                else if (teamIndex < 0)
                {
                    direction = 1;
                    teamIndex = 0;
                }
            }

            return teams;
        }
    }
}

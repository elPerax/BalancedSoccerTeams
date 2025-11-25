using BalancedSoccerTeams.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BalancedSoccerTeams.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; } = null!;
    }
}


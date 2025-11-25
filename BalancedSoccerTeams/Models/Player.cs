using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalancedSoccerTeams.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Player Name")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 10)]
        [Display(Name = "Ball Control")]
        public int BallControl { get; set; }

        [Range(1, 10)]
        [Display(Name = "Passing Accuracy")]
        public int PassingAccuracy { get; set; }

        [Range(1, 10)]
        public int Dribbling { get; set; }

        [Range(1, 10)]
        [Display(Name = "Defensive Awareness")]
        public int DefensiveAwareness { get; set; }

        [Range(1, 10)]
        public int Shooting { get; set; }

        [NotMapped]
        [Display(Name = "Overall Score")]
        public double OverallScore =>
            (BallControl + PassingAccuracy + Dribbling + DefensiveAwareness + Shooting) / 5.0;

        [NotMapped]
        [Display(Name = "Rank (1 = best)")]
        public int Rank
        {
            get
            {
                if (OverallScore >= 8.0) return 1;
                if (OverallScore >= 6.5) return 2;
                if (OverallScore >= 5.0) return 3;
                if (OverallScore >= 3.5) return 4;
                return 5;
            }
        }
    }
}

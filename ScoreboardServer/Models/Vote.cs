using System.ComponentModel.DataAnnotations;

namespace ScoreboardServer.Models
{
    public class Vote
    {
        public int VoteId { get; set; }

        [Required]
        public Player Player { get; set; }
    }
}
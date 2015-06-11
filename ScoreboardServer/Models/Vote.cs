using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ScoreboardServer.Models
{
    [DataContract(IsReference = true)]
    public class Vote
    {
        public int VoteId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public virtual Player Player { get; set; }
    }
}
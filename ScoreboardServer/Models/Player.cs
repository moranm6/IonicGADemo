using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;

namespace ScoreboardServer.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        [ScriptIgnore]
        [IgnoreDataMember]
        public string LastName { get; set; }

        [ScriptIgnore]
        [IgnoreDataMember]
        public ICollection<Vote> Votes { get; set; }

        [NotMapped]
        public int VoteCount
        {
            get { return Votes.Count; }
            // ReSharper disable once ValueParameterNotUsed
            // The setter only exists because it's necessary for WebAPI to serialize
            set { }
        }
    }
}
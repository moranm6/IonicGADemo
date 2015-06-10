using System;
using System.Collections.Generic;
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
    }
}
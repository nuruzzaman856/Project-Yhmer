using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class MatchManagerModel
    {
        public string SearchProfileId { get; set; }
        public bool AcceptedLia { get; set; }
        public bool DeclinedLia { get; set; }
        public bool AcceptedJob { get; set; }
        public bool DeclinedJob { get; set; }
    }
}

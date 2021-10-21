using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class MatchManagerModel
    {
        public string MatchedSearchProfileId { get; set; }
        public string SearchProfileId { get; set; }
        public bool AcceptedLIA { get; set; }
        public bool DeclinedLIA { get; set; }
        public bool AcceptedJob { get; set; }
        public bool DeclinedJob { get; set; }
    }
}

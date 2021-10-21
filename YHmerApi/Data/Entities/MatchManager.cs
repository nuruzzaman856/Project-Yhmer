using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Entities
{
    public class MatchManager
    {
        public string Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
        public bool AcceptedLIA { get; set; }
        public bool DeclinedLIA { get; set; }
        public bool AcceptedJob { get; set; }
        public bool DeclinedJob { get; set; }
        public string MatchedSearchProfileId { get; set; }
        public string SearchProfileId { get; set; }

        public MatchManager()
        {
            MatchedSearchProfileId = string.Empty;
            SearchProfileId = string.Empty;
        }



    }
}

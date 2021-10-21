using Api.Areas.Identity.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Entities
{
    public class SearchProfileSkillMatch
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("SearchProfileId")]
        public SearchProfile SearchProfile { get; set; }
        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
    }
}

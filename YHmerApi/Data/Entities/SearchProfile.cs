using Api.Areas.Identity.Data;
using Api.Areas.Identity.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Entities
{
    public class SearchProfile
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Name { get; set; }
        public bool Aktiv { get; set; }
        public string Period { get; set; }
        public string Contact { get; set; }
        public string ContactInformation { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string Role { get; set; }
        public string About { get; set; }
        public bool LIA { get; set; }
        public bool Employment { get; set; }
        public List<SearchProfileSkillMatch> Skills { get; set; }
        public SearchProfile()
        {
            Skills = new List<SearchProfileSkillMatch>();
        }
    }
}

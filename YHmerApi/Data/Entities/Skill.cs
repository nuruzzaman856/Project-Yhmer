using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        public string Id { get; set; }
        public virtual List<SkillMatch> skillMatches { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }


        // public virtual List<JobSkill> JobSkills { get; set; } = new List<JobSkill>(); // Jobskills blir instansierad två gånger

        public Skill()
        {
            Id = Guid.NewGuid().ToString();
            Name = String.Empty;
            IsVerified = false;
            skillMatches = new List<SkillMatch>();
            //JobSkills = new List<JobSkill>();
        }
    }
}

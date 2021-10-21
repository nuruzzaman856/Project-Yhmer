using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("SkillMatches")]
    public class SkillMatch
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("SkillId")]
        public Skill Skill { get; set; } //Fk
        [ForeignKey("UserId")]
        public User User { get; set; } //Fk

        public string SkillLevel { get; set; }
        public int YearsOfSkill { get; set; }
        public bool IsVerified { get; set; }
        public DateTime Created { get; set; }
        public SkillMatch()
        {
            Created = default;
            IsVerified = false;
            SkillLevel = String.Empty;
            YearsOfSkill = default;
            Id = Guid.NewGuid().ToString();
          
        }
    }
}

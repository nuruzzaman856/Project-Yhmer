using Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("JobSkills")]
    public class JobSkill
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public Skill Skill { get; set; }
        [ForeignKey("ID")]
        public Job Job { get; set; }

        public JobSkill()
        {          
            ID = Guid.NewGuid().ToString();
        }
    }
}

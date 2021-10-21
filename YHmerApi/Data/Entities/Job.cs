using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public bool IsVisible { get; set; } = false;

        public virtual List<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
        public Job()
        {

            Title = string.Empty;
            Description = string.Empty;
            Body = string.Empty;
            Body = string.Empty;
            ImageUrl = string.Empty;
            IsVisible = default;
            JobSkills = new List<JobSkill>();
            ID = Guid.NewGuid().ToString();
        }

    }
}
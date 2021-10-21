using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Api.Areas.Identity.Data;
using Api.Models;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Experiences")]
    public class Experience
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public UserSpecification UserSpecification { get; set; }
        public string Name { get; set; }
        public string ExperienceLevel { get; set; }
        public bool IsVerified { get; set; }
        public string VerifiedByOrganizerID { get; set; } //Should be a string

        public Experience()
        {
            ID = Guid.NewGuid().ToString();
            Name = String.Empty;
            ExperienceLevel = String.Empty;
            IsVerified = false;
            VerifiedByOrganizerID = String.Empty;            
        }
    }
}

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
    public class EducationStudent
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("EducationId")]
        public bool IsVerified { get; set; }
        public Education Education { get; set; }
    public EducationStudent()
    {
            Id = Guid.NewGuid().ToString();
    }
    }
}

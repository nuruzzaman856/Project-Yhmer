using Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [ForeignKey("EducationId")]
        public Education Education { get; set; }
        public string Name { get; set; } // Two names?
        public int Points { get; set; }
        public bool IsLiaCourse { get; set; }
        public string Location { get; set; }
        public bool SearchingForEducator { get; set; }
        public string About { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool SearchingForGuestLecturer { get; set; }
        //public virtual List<Class> Classes { get;  set; }

        public Course()
        {
            Id = Guid.NewGuid().ToString();
            Name = String.Empty;
            Points = default;
            IsLiaCourse = false;
            Location = String.Empty;
            //Classes = new List<Class>();
        }
    }
}

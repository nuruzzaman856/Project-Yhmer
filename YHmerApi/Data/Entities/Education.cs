using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Api.Areas.Identity.Data;
using Api.Data.Entities;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Educations")]
    public class Education
    {
        [Key]
        public string Id { get; set; }
        //[ForeignKey("Id")]
        [Required]
        [ForeignKey("SchoolId")]
        public School School { get; set; } //FK
        public string Name { get; set; } // Two names?
        public int Points { get; set; }
        public bool IsLiaCourses { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string YHNumber { get; set; }
        public DateTime LastDateForApplication { get; set; }
        [Required]
        public string RegisterCode { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<EducationStudent> EducationStudent { get; set; }
        public bool SearchingForBoardMembers { get; set; }


        public Education()
        {
            Id = Guid.NewGuid().ToString();
            Name = String.Empty;
            Points =  default;
            IsLiaCourses = false;
            City = String.Empty;
            Courses = new List<Course>();
            About = String.Empty;
            EducationStudent = new List<EducationStudent>();
            RegisterCode = ToolBox.GenerateCode();

        }
    }
}

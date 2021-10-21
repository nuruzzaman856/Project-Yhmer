using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class EducationModel
    {
        public string ID { get; set; }
        public string Name { get; set; } // Two names?
        public string Period { get; set; } //Hur???? Start/End date
        public int Points { get; set; }
        public bool IsLiaCourses { get; set; }
        public string City { get; set; }
        public string YHNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastDateForApplication { get; set; }
        public string About { get; set; }
        public bool SearchingForBoardMembers{ get; set; }
        public string CourseId { get; set; }
        public List<CourseModel> Courses { get; set; }
        public string RegisterCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class EducationStudentsModel
    {
        public bool IsStudentVerified { get; set; }
        public string SchoolName { get; set; }
        public string EducationName { get; set; }
        public int Points { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string About { get; set; }
        public string City { get; set; }
        public CourseModel[] Courses { get; set; }
    }
}

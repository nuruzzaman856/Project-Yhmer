using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class CourseModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Points { get; set; }
        public bool IsLiaCourses { get; set; }
        public string Location { get; set; }
        public string YHNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string About { get; set; }
        public bool SearchingForEducators { get; set; }
        public bool SearchingForGuestLecturer { get; set; }

    }
}

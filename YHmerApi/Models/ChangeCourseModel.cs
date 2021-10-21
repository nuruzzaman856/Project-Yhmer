using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ChangeCourseModel
    {
        public string CourseId { get; set; }
        public string EducationId { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public int Points { get; set; }
        public bool IsLiaCourse { get; set; }
        public string Location { get; set; }
        public bool SearchingForEducators { get; set; }
        public bool SearchingForGuestLecturer { get; set; }
        public string About { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

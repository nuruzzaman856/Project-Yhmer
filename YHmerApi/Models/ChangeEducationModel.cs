using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ChangeEducationModel
    {
        public string EducationID { get; set; }
        public string Period { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public bool IsLiaCourses { get; set; }
        public string City { get; set; }
        public bool SearchingForBoardMembers { get; set; }
        public string About { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string YHNumber { get; set; }
        public DateTime LastDateForApplication { get; set; }
    }
}

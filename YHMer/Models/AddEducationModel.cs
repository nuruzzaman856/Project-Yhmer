using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class AddEducationModel
    {
        public string userId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; } // Two names?
        public string Period { get; set; } //Hur???? Start/End date
        public int Points { get; set; }
        public bool IsLiaCourses { get; set; }
        public string City { get; set; }
        public bool SearchingForBoardMembers { get; set; }
    }
}

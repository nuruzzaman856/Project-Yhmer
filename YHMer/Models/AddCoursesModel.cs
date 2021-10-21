using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class AddCoursesModel
    {
        public string Name { get; set; } // Two names?
        public string Period { get; set; } // //Hur???? Start/End date? Borde vara 2 properties: Start och End
        public int Points { get; set; }
        public bool IsLiaCourse { get; set; }
        public string Location { get; set; }
        public string EducationId { get; set; }
    }
}

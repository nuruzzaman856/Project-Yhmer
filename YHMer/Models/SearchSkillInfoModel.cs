using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class SearchSkillInfoModel
    {

        public string name { get; set; }
        public string skillLevel { get; set; }
        public int yearsOfExperience { get; set; }
        public bool IsVerified { get; set; }
    }
}

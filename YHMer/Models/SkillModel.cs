using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class SkillModel
    {


        public string Id { get; set; }

        public string Name { get; set; }
        public bool IsVerified { get; set; }

        public string SkillLevel { get; set; }
        public int YearsOfSkill { get; set; }

        public DateTime Created { get; set; }
    }
}

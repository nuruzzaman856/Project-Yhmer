using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ChangeSkillModel
    {


        public string SkillId { get; set; }
        public string Name { get; set; }

        public string SkillLevel { get; set; }

        public int YearsOfSkill { get; set; }
        public bool IsVerified { get; set; }
      
    }
}

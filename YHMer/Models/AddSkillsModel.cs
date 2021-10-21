using Api.Areas.Identity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class AddSkillsModel
    {

        public string Name { get; set; }
        public string SkillLevel { get; set; }
        public int YearsOfExperience { get; set; }
    }
}

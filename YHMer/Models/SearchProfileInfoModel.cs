using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{


    public class SearchProfileInfoModel
    {
        public string id { get; set; }
        public bool makeProfileSearchable { get; set; }
        public bool lookingForEmploymentAfterExam { get; set; }
        public bool viewMyGradsFromOrganizers { get; set; }
        public string freeTextDescription { get; set; }
        public int yearsOfExprienceInCompany { get; set; }
        public string Area { get; set; }
        public Skill[] skills { get; set; }
    }

    public class Skill
    {
        public string name { get; set; }
        public string skillLevel { get; set; }
        public int yearsOfExperience { get; set; }
        public bool IsVerified { get; set; }
    }
    
}

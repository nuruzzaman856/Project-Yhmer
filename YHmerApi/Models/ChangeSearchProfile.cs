using Api.Areas.Identity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ChangeSearchProfile
    {
        
        public string UserName { get; set; }
        public string SearchProfileId { get; set; }
        public bool MakeProfileSearchable { get; set; }
        public bool LookingForEmploymentAfterExam { get; set; }
        public bool ViewMyGradsFromOrganizers { get; set; }
        public string FreeTextDescription { get; set; }
        public int YearsOfExprienceInCompany { get; set; }
        public string Area { get; set; }
        public List<SkillListModel> skills { get; set; }
    }
}

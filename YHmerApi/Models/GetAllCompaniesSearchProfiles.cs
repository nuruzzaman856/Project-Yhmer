using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class GetAllCompaniesSearchProfiles
    {
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public int MatchedSkills { get; set; }
        public int WeightOfMatch { get; set; }
        public string Period { get; set; }
        public string MatchedSearchProfileId { get; set; }
        public string Area { get; set; }
        public string ContactPerson { get; set; }
        public int WantedSkills { get; set; }
        public string SearchProfileName { get; set; }
        public string Role { get; set; }
        public bool LIA { get; set; }
        public bool Employment { get; set; }
        public bool cLIA { get; set; }
        public bool cEmployment { get; set; }
        public string AcceptedLia { get; set; }
        public string DeniedLia { get; set; }
        public string AcceptedJob { get; set; }
        public string DeniedJob { get; set; }
        public string SearchProfileId { get; set; }
        public List<SkillListModel> Skills = new List<SkillListModel>();



    }
}

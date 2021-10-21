using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class CompanyMatchedProfileModel
    {

        public string userId { get; set; }
        public string companyName { get; set; }
        public int matchedSkills { get; set; }
        public int weightOfMatch { get; set; }
        public string period { get; set; }
        public string MatchedSearchProfileId { get; set; }
        public string area { get; set; }
        public string contactPerson { get; set; }
        public int wantedSkills { get; set; }
        public string searchProfileName { get; set; }
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


    }
}

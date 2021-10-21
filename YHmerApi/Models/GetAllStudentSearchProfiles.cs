using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Entities;

namespace Api.Models
{
    public class GetAllStudentSearchProfiles
    {
        public string StudentId { get; set; }
        public string MatchedIndividual { get; set; }
        public int Matches { get; set; }
        public int WeightOfMatch { get; set; }
        public string Period { get; set; }
        public string BelongsToSchool { get; set; }
        public bool Grades { get; set; }
        public string SearchProfile { get; set; }
        public int wantedSkills { get; set; }
        public bool LIA { get; set; }
        public bool Employment { get; set; }
        public bool cLia { get; set; }
        public bool cEmployment { get; set; }
        public string MatchedSearchProfileId { get; set; }
        public string AcceptedLia { get; set; }
        public string DeniedLia { get; set; }
        public string AcceptedJob { get; set; }
        public string DeniedJob { get; set; }
        public string SearchProfileId { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{


    public class StudentSearchProfileModel
    {
        public string studentId { get; set; }
        public string matchedIndividual { get; set; }
        public int matches { get; set; }
        public int weightOfMatch { get; set; }
        public string period { get; set; }
        public object belongsToSchool { get; set; }
        public bool grades { get; set; }
        public string searchProfile { get; set; }
        public int wantedSkills { get; set; }
        public bool lia { get; set; }
        public bool employment { get; set; }
        public bool cLia { get; set; }
        public bool cEmployment { get; set; }
        public string MatchedSearchProfileId { get; set; }
        public string AcceptedLia { get; set; }
        public string DeniedLia { get; set; }
        public string AcceptedJob { get; set; }
        public string DeniedJob { get; set; }
        public string SearchProfileId { get; set; }
    }

   












    //public class StudentSearchProfileModel
    //{
    //    public MatchManagers[] RootmatchManagers { get; set; }
    //}

    //public class MatchManagers
    //{
    //    public string studentId { get; set; }
    //    public string matchedIndividual { get; set; }
    //    public int matches { get; set; }
    //    public int weightOfMatch { get; set; }
    //    public string period { get; set; }
    //    public object belongsToSchool { get; set; }
    //    public bool grades { get; set; }
    //    public string searchProfile { get; set; }
    //    public int wantedSkills { get; set; }
    //    public bool lia { get; set; }
    //    public bool employment { get; set; }
    //    public bool cLia { get; set; }
    //    public bool cEmployment { get; set; }
    //    public string searchProfileId { get; set; }
    //    public Matchmanager[] matchManagers { get; set; }
    //}

    //public class Matchmanager
    //{
    //    public string id { get; set; }
    //    public string searchProfile { get; set; }
    //    public bool accepted { get; set; }
    //    public bool declined { get; set; }
    //    public string user { get; set; }
    //}

}

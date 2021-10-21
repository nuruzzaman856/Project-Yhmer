using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class CompanySearchProfileModel
    {
        public string UserId { get; set; }
        public string SearchProfileId { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public string Contact { get; set; }
        public string ContactInformation { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string About { get; set; }
        public string Role { get; set; }
        public bool Aktiv { get; set; }
        public bool LIA { get; set; }
        public bool Employment { get; set; }
        public string[] Skills { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class UserProfileModel
    {
        public object userSpecification { get; set; }
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string normalizedUserName { get; set; }
        public string email { get; set; }
        public string normalizedEmail { get; set; }
        public bool emailConfirmed { get; set; }
        public string passwordHash { get; set; }
        public string securityStamp { get; set; }
        public string concurrencyStamp { get; set; }
        public object phoneNumber { get; set; }
        public bool phoneNumberConfirmed { get; set; }
        public bool twoFactorEnabled { get; set; }
        public object lockoutEnd { get; set; }
        public bool lockoutEnabled { get; set; }
        public int accessFailedCount { get; set; }
        public DateTime DOBifStudent { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string OrgNumber { get; set; }
        public string ProfileImageUrl { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string PostalArea { get; set; }
        public string ContactPerson { get; set; }
        public bool VisibleProfile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class UpdateSchoolModel
    {
        public string UserId { get; set; }
        public string SchoolId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Orgnr { get; set; }
        public string ContactPerson { get; set; }
        public string Contacts { get; set; }
        public string StreetAdress { get; set; }
        public string PostalCode { get; set; }
        public string PostalArea { get; set; }
        public string City { get; set; }

        public UpdateSchoolModel()
        {
            Name = string.Empty;
            About = string.Empty;
            Orgnr = string.Empty;
            ContactPerson = string.Empty;
            Contacts = string.Empty;
            StreetAdress = string.Empty;
            PostalArea = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
            //Teachers = new List<User>();
            
        }
    }
}

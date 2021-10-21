using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class SchoolModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Orgnr { get; set; }
        public string ContactPerson { get; set; }
        public string Contacts { get; set; }
        public string StreetAdress { get; set; }
        public string PostalCode { get; set; }
        public string PostalArea { get; set; }
        public string City { get; set; }
    }
}

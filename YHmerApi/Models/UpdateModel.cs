using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class UpdateModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public bool Visible { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string PostalArea { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string OrgNumber { get; set; }
    }
}

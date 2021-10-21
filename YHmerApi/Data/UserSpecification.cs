using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Areas.Identity.Data.Entities;

namespace Api.Areas.Identity.Data
{
    [Table("UserSpecifications")]
    public class UserSpecification
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOBifStudent { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public int OrgNumber { get; set; }
        public string ProfileImageUrl { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        //public virtual List<Experience> Experiences { get; set; }

        public UserSpecification()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            DOBifStudent = default;
            Gender = String.Empty;
            CompanyName = String.Empty;
            OrgNumber =  default;
            ProfileImageUrl = String.Empty;
            City = String.Empty;
            About = String.Empty;
            Adress = String.Empty;
            PostalCode = String.Empty;
            //Experiences = new List<Experience>();
            ID = Guid.NewGuid().ToString();

        }
    }
}

using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Schools")]
    public class School
    {
        [Key]
        public string ID { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string SchoolName { get; set; }
        public int Courses { get; set; } //What is this??? Fråga Christer.
        public string AboutSchool { get; set; }
        public string Orgnr { get; set; }
        public string ContactPerson { get; set; }
        public string Contacts { get; set; }
        public string StreetAdress { get; set; }
        public string PostalCode { get; set; }
        public string PostalArea { get; set; }
        public string City { get; set; }
        //public virtual List<User> Teachers { get; set; }
        public virtual List<Education> Educations { get; set; }

        public School()
        {
            ID = Guid.NewGuid().ToString();
            SchoolName = string.Empty;
            Courses = default;
            AboutSchool = string.Empty;
            Orgnr = string.Empty;
            ContactPerson = string.Empty;
            Contacts = string.Empty;
            StreetAdress = string.Empty;
            PostalArea = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
            //Teachers = new List<User>();
            Educations = new List<Education>();
        }
    }

}

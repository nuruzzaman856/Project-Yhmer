using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api.Areas.Identity.Data.Entities;
using Api.Data;
using Api.Data.Entities;
using Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Api.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        // Add custom properties to your users
        // public int MyProperty { get; set; }



        //public virtual List<UserRole> UserRoles { get; set; }
        //public virtual List<Chat> Chats { get; set; }
        //public virtual List<Post> Posts { get; set; }
        //public virtual List<Comment> Comments { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOBifStudent { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string OrgNumber { get; set; }
        public string ContactPerson { get; set; }
        public string ProfileImageUrl { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string PostalArea { get; set; }
        [Column("Visible Profile")]
        public bool VisibleProfile { get; set; }
        //[ForeignKey("ClassId")]
        //public Class Class { get; set; }

        public virtual List<EducationStudent> EducationStudent { get; set; }
        public virtual List<SkillMatch> SkillMatches { get; set; }
        public virtual List<StudentSearchProfile> StudentSearchProfiles { get; set; }
        public virtual List<SearchProfile> SearchProfiles { get; set; }
        public virtual List<MatchManager> MatchManagers { get; set; }



        public string AgreedToTerms { get; set; }


        // public vairtual List<SearchProfile> SearchProfiles { get; set; }
        public virtual List<School> Schools { get; set; }
        // Setup one to one relation
        //public virtual UserSpecification UserSpecification { get; set; }
        //public virtual UserSettings Settings { get; set; }
        //public virtual UserGDPR GDPR { get; set; }

        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            DOBifStudent = default;
            Gender = String.Empty;
            CompanyName = String.Empty;
            OrgNumber = default;
            ProfileImageUrl = String.Empty;
            City = String.Empty;
            About = String.Empty;
            Adress = String.Empty;
            PostalCode = String.Empty;
            VisibleProfile = false;
            EducationStudent = new List<EducationStudent>();
            SkillMatches = new List<SkillMatch>();
            StudentSearchProfiles = new List<StudentSearchProfile>();
            SearchProfiles = new List<SearchProfile>();
            MatchManagers = new List<MatchManager>();

            AgreedToTerms = String.Empty;

            Schools = new List<School>();
            //Chats = new List<Chat>();
            //Posts = new List<Post>();
            //UserSpecification = new UserSpecification();
            //Settings = new UserSettings();
            //GDPR = new UserGDPR();
        }

        //public class DemoTable
        //{
        //    [Key]
        //    public string Id { get; set; }
        //    public string About { get; set; }

        //    public DemoTable()
        //    {
        //        Id = Guid.NewGuid().ToString();
        //        About = String.Empty;
        //    }

        //}

    }
}

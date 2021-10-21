using Api.Areas.Identity.Data;
using Api.Areas.Identity.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class StudentSearchProfile
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public bool MakeProfileSearchable { get; set; }
        public bool LookingForEmploymentAfterExam { get; set; }

        public bool ViewMyGradsFromOrganizers { get; set; }
        public int YearsOfExprienceInCompany { get; set; }
        public string Area { get; set; }

        public string FreeTextDescription { get; set; }

       


        public StudentSearchProfile()
        {
            MakeProfileSearchable = default;
            LookingForEmploymentAfterExam = default;
            ViewMyGradsFromOrganizers = default;
            FreeTextDescription = String.Empty;
            YearsOfExprienceInCompany = default;
            Area = string.Empty;

        }
    }
}

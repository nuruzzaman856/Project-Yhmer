using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Studies")]
    public class Study
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public Education Education { get; set; }
        [ForeignKey("ID")]
        public UserSpecification UserSpecification { get; set; }
        public int Rating { get; set; }
        public bool IsVerified { get; set; } 

        public Study()
        {
            Rating = default;
            IsVerified = false;
            ID = Guid.NewGuid().ToString();
        }
    }
        
}

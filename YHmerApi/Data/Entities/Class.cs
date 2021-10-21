using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public Education Education { get; set; }

        public virtual List<User> Users { get; set; }
        //[NotMapped]
        //public virtual List<User> Educators{ get; set; } //fK
        public int Rating { get; set; }
        public virtual bool IsVerified { get; set; }

        public Class()
        {
            Users = new List<User>();
            //Educators = new List<User>();
            Rating = default;
            IsVerified = false;
            ID = Guid.NewGuid().ToString();
        }
    }
}

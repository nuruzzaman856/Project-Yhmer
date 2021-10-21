using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("UserSettings")]
    public class UserSettings
    {
        [Key]
        public string Id { get; set; }
        public bool DarkMode { get; set; }

        // assign foreign key (which is the primary key of the parent table, in this case (Id) of user)
        [ForeignKey("Id")]
        public virtual User User { get; set; }

        public UserSettings()
        {
            Id = Guid.NewGuid().ToString();
            DarkMode = false;

        }


    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("UserGDPRs")]
    public class UserGDPR
    {
        [Key]
        public string Id { get; set; }

        public bool UseMyData { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }

        public UserGDPR()
        {
            Id = Guid.NewGuid().ToString();
            UseMyData = false;
        }
    }
}

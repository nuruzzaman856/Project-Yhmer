using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Ratings")]
    public class Rating
    {
        public string ID { get; set; }
        [ForeignKey("ID")]
        public User User { get; set; }
        public string CompanyName { get; set; } //??? user?
        public string OrganizerName { get; set; } //??User?
        [Column("Rating")]
        public int UserRating { get; set; }
        public bool Verified { get; set; }
        public string Comment { get; set; }

        public Rating()
        {
            ID = Guid.NewGuid().ToString();
            CompanyName = string.Empty;
            OrganizerName = default;
            UserRating = default;
            Verified = false;
            Comment = string.Empty;
        }

    }
}
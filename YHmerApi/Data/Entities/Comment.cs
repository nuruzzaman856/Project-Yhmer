using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public Post Post { get; set; } //FK     
        [Column("Comment")]
        public string UserComment { get; set; }
        public int Likes { get; set; }
        public DateTime Date { get; set; }

        public Comment()
        {
            ID = Guid.NewGuid().ToString();
            UserComment =  String.Empty;
            Likes =  default;
            Date = default;
        }

    }
}

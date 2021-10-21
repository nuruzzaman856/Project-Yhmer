using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Messages")]
    public class Message
    {
        public string ID { get; set; }
        [ForeignKey("ID")]
        public Chat Chat { get; set; } //Fk
        [ForeignKey("ID")]
        public User User { get; set; }//Fk
        [Column("Message")]
        public string ChatMessage { get; set; }
        public string MediaUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime Read { get; set; } //Bool?

        public Message()
        {
           
            ChatMessage = string.Empty;
            MediaUrl = string.Empty;
            Created = default;
            Read = default;
            ID = Guid.NewGuid().ToString();
        }
    }

}


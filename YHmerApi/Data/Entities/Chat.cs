using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Api;
using Api.Areas.Identity.Data;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Chats")]
    public class Chat
    {
        [Key]
        public string ID { get; set; }
        public int SenderID { get; set; }
        public int RecieverID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public virtual List<Message> Messages { get; set; }
        public virtual List<User> Users { get; set; }

        public Chat()
        {
            
            SenderID = default;
            RecieverID = default;
            Name = String.Empty;
            Created = default;
            Messages = new List<Message>();
            Users = new List<User>();
            ID = Guid.NewGuid().ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("Contents")]
    public class Content
    {
        [Key]
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string MediaUrl { get; set; }

        public Content()
        {
            ID = Guid.NewGuid().ToString();
            Title = string.Empty;
            Description = string.Empty;
            Body = string.Empty;
            MediaUrl = string.Empty;

        }
    }
}

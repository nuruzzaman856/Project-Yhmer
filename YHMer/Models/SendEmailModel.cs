using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Models
{
    public class SendEmailModel
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Areas.Identity.Data;

namespace Api.Data.Entities
{
    public class MatchMessagesModel
    {
        public bool AcceptedLIA { get; set; }
        public bool AcceptedJob  { get; set; }
        public string Name { get; set; }
        public string  Role { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}

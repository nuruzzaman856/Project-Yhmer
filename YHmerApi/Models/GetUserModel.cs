using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class GetUserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        //public int MyProperty { get; set; }
    }

    public class UpdateAboutMeModel
    {
        public string About { get; set; }
        //public int MyProperty { get; set; }
    }

    public class UpdateDemoTable
    {
        public string Id { get; set; }
        public string About { get; set; }
        //public int MyProperty { get; set; }
    }
}

using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class UserDetailsModel : IUserDetailsModel
    {
        private Context _context;

        public UserDetailsModel( Context context)
        {
            _context = context;
        } 
        public UserSpecification AddProfilePicture(UserSpecification id)
        {
            throw new NotImplementedException();
        }

        public UserSpecification AddUser(UserSpecification user)
        {
            throw new NotImplementedException();
        }

        public UserSpecification DeleteProfilePicture(UserSpecification id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(UserSpecification id)
        {
            throw new NotImplementedException();
        }

        public UserSpecification GetUser(UserSpecification id)
        {
            throw new NotImplementedException();
        }

        public List<UserSpecification> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserSpecification UpdateUserData(UserSpecification id)
        {
            throw new NotImplementedException();
        }
    }
}

using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public interface IUserDetailsModel
    {
        List<UserSpecification> GetUsers();

        UserSpecification AddUser(UserSpecification user);
        UserSpecification GetUser(UserSpecification id);

        void  DeleteUser(UserSpecification id);

        UserSpecification UpdateUserData(UserSpecification id);

        UserSpecification AddProfilePicture(UserSpecification id);

        UserSpecification DeleteProfilePicture(UserSpecification id);


    }
}

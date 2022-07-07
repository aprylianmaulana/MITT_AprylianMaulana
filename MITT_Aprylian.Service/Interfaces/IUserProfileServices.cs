using MITT_Aprylian.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MITT_Aprylian.Service.Interfaces
{
    public interface IUserProfileServices
    {
        Task<IEnumerable<UserProfileModel>> RegisterUser(UserProfileModel userProfileModel);
        Task<IEnumerable<UserProfileModel>> UpdateUserProfile(UserProfileModel userProfileModel);
    }
}

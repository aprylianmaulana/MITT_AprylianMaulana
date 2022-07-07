using MITT_Aprylian.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MITT_Aprylian.Repository.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfileModel>> RegisterUser(UserProfileModel userProfileModel);
        Task<IEnumerable<UserProfileModel>> UpdateUserProfile(UserProfileModel userProfileModel);
    }
}

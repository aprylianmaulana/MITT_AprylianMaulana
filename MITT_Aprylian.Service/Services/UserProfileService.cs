using MITT_Aprylian.Domain.Models;
using MITT_Aprylian.Repository.Interfaces;
using MITT_Aprylian.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MITT_Aprylian.Service.Services
{
    public class UserProfileService : IUserProfileServices
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<IEnumerable<UserProfileModel>> RegisterUser(UserProfileModel userProfileModel)
        {
            return await _userProfileRepository.RegisterUser(userProfileModel);
        }

        public async Task<IEnumerable<UserProfileModel>> UpdateUserProfile(UserProfileModel userProfileModel)
        {
            return await _userProfileRepository.UpdateUserProfile(userProfileModel);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MITT_Aprylian.Domain.Models;
using MITT_Aprylian.Repository.Interfaces;
using MITT_Aprylian.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITT_Aprylian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtManagerRepository _jwt;
        private readonly IUserProfileServices _userProfile;
        public UserController(IJwtManagerRepository jwt, IUserProfileServices userProfile)
        {
            _jwt = jwt;
            _userProfile = userProfile;
        }

        [Route("AuthenticateUser")]
        [HttpPost]
        public IActionResult Authenticate(UserModel users)
        {
            var token = _jwt.Authenticate(users);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        //[Route("Logout")]
        //[HttpPost]
        //public IActionResult Logout(UserModel users)
        //{
        //    var username = User.Identity.Name;
        //    _
        //    return Ok(token);
        //}

        [Authorize]
        [Route("RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserProfileModel usersProfile)
        {
            var data = await _userProfile.RegisterUser(usersProfile);
            return Ok(data);
        }

        [Authorize]
        [Route("UpdateUser")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserProfileModel usersProfile)
        {
            var data = await _userProfile.UpdateUserProfile(usersProfile);
            return Ok(data);
        }
    }
}

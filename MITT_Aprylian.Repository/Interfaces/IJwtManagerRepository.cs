using MITT_Aprylian.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MITT_Aprylian.Repository.Interfaces
{
    public interface IJwtManagerRepository
    {
        TokenData Authenticate(UserModel users);
    }
}

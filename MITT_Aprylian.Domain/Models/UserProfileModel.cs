using System;
using System.Collections.Generic;
using System.Text;

namespace MITT_Aprylian.Domain.Models
{
    public class UserProfileModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Bod { get; set; }
        public string Email { get; set; }
    }
}

using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.API.Requirement
{
    public class CustomUserRequirement : IAuthorizationRequirement
    {
        public string UserName = "User";
        public string Password = "P@ssw0rd";
    }
}

using LoginMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginMVCWebApp.Services.Data
{
    public class SecurityDAO
    {
        internal bool FindByUser(UserModel user)
        {
            return (user.UserName == "Admin" && user.Password == "Secret");
        }
    }
}
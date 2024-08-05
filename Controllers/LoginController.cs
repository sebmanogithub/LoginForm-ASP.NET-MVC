using LoginMVCWebApp.Models;
using LoginMVCWebApp.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVCWebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public string Login(UserModel userModel)
        {
            //return "Results: UserName = " + userModel.UserName + " PW = " + userModel.Password;
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);

            if (success)
            {
                return "Success Login";
            }
            else
            {
                return "Failure. Not logged in.";
            }
        }
    }
}
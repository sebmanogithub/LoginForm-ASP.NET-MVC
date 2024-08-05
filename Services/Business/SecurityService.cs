using LoginMVCWebApp.Models;
using LoginMVCWebApp.Services.Data;

namespace LoginMVCWebApp.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();
        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }
    }
}
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Kebattle.DomainModel;
using Kebattle.Repositories.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Kebattle.Web.Helpers
{
    public static class SessionHelper
    {
        #region Fields
        private static readonly string CURRENT_USER = "CURRENT_USER";
        #endregion //Fields

        public static void SetUserAndOtherDetails(string userName)
        {
            ClearUser();
            var aspNetUserRepository = DependencyResolver.Current.GetService<AspNetUserRepository>();
            var user = aspNetUserRepository.GetUserByEmail(userName);
            HttpContext.Current.Session.Add(CURRENT_USER, user);
        }

        public static void ClearUser()
        {
            HttpContext.Current.Session[CURRENT_USER] = null;
        }

        #region Helpers
        public static string GetUserId()
        {
            var user = InitUser();
            return user?.Id ?? "";
        }

        public static bool IsCompany()
        {
            var user = InitUser();
            if(user != null)
                if (user.Companies.Any())
                    return true;

            return false;
        }

        public static int GetCompanyId()
        {
            var user = InitUser();

            if (user != null)
                if (user.Companies.Any())
                    return user.Companies.First().Id;

            return 0;
        }

        private static AspNetUser InitUser()
        {
            var user = (AspNetUser)HttpContext.Current.Session[CURRENT_USER];

            if(user == null)
            {
                var userName = HttpContext.Current.User.Identity.Name;
                if (!string.IsNullOrEmpty(userName))
                    SetUserAndOtherDetails(userName);
            }
            
            return (AspNetUser)HttpContext.Current.Session[CURRENT_USER];
        }
        #endregion //Helpers
    }
}
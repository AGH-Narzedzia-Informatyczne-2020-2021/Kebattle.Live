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
            var aspNetUserRepository = DependencyResolver.Current.GetService<AspNetUserRepository>();
            var user = aspNetUserRepository.GetUserByEmail(userName);
            HttpContext.Current.Session.Add(CURRENT_USER, user);
        }

        #region Helpers
        public static string GetUserId()
        {
            var id = "";
            var user = (AspNetUser)HttpContext.Current.Session[CURRENT_USER];
            if (user != null)
            {
                id = user.Id;

            }
            return id;
        }
        #endregion //Helpers
    }
}
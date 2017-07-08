using Domain.Entities;
using Domain.Services.AggregatRoots.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ros.WebApplication.Utilities
{
    internal static class SessionLoginUtilities
    {
        public static UserDTO GetLoggedInUser(HttpSessionStateBase session)
        {
            UserDTO user;
            using (var userService = new UserService())
            {
                var loginUser = session["Login"].ToString();
                user = userService.EagerDisconnectedService.FindBy(u => u.Login == loginUser).First();
                return user;
            }
        }
    }
}
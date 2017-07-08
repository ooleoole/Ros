using Domain.Services.AggregatRoots.UserServices;
using Ros.WebApplication.Models.ViewModels.UserViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ros.WebApplication.Controllers
{
    public class LoginSessionController : Controller
    {
        private LazyConnectedUserService lazyService = new LazyConnectedUserService();
        private EagerDisconnectedUserService eagerService = new EagerDisconnectedUserService();

        // GET: LoginSession
        public ActionResult defautIndex()
        {
            return View();
        }

        public ActionResult LoginSession()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginSession(UserLoginViewModel user)
        {

            var _user = lazyService.FindBy(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefault(); ;
            if (_user != null)
            {
                Session["UserId"] = _user.Id;
                Session["Login"] = _user.Login;
                //var v = Session["Login"]; // Remove later
                return RedirectToAction("Main", "UserMainMenu");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is invalid!");
            }

            return View();
        }

        public ActionResult LogoutSession()
        {
            Session.Clear();
            Session.Abandon();
            //Session["UserId"] = null; / Session["Username"] =null;
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("Index", "Home");
        }
    }
}
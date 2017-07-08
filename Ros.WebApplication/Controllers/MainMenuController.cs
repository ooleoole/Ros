using System.Web.Mvc;

namespace Ros.WebApplication.Controllers
{
    public class MainMenuController : Controller
    {
        // GET: MainMenu
        public ActionResult Index()
        {
            return View();
        }
    }
}
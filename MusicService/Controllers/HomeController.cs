using System.Web.Mvc;

namespace MusicService.Controllers
{
    /// <summary>
    /// Home Controller, added by default when the project was creted.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index method.
        /// </summary>
        /// <returns>View to the default page.</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}

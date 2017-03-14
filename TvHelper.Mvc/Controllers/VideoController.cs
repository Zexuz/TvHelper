using System.Web.Mvc;

namespace TvHelper.Controllers
{
    public class VideoController : Controller
    {
        [System.Web.Http.HttpGet]
        public ActionResult Open(string filePath)
        {
            System.Diagnostics.Process.Start(filePath);
            return View();
        }
    }
}
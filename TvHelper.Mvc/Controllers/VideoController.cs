using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

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
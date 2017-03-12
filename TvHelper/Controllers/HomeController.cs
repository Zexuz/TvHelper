using System.Linq;
using System.Web.Mvc;
using TvHelper.Servicies;

namespace TvHelper.Controllers
{
    public class HomeController : Controller
    {

        private readonly FileReaderService _fileReaderService;

        public HomeController()
        {
            _fileReaderService = new FileReaderService();
        }

        public ActionResult Index()
        {
            // The view being returned is calculated based on the name of the
            // controller (Home) and the name of the action method (Index).
            // So in this case, the view returned is /Views/Home/Index.cshtml.
            return View();
        }

        public ActionResult Video()
        {
            // Creates a model and passes it on to the view.
            var files = _fileReaderService.GetAllFilesAndDirectoriesInPath("D:\\Downloads\\TorrentDay");

            return View(files);
        }

    }
}
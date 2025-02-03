using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class ChildsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

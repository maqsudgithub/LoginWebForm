using Microsoft.AspNetCore.Mvc;

namespace LoginWebForm.Controllers
{
    public class AttendenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

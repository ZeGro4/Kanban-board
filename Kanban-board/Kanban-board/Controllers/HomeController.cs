using Microsoft.AspNetCore.Mvc;

namespace Kanban_board.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

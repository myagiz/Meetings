using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SocietyManagementSystem.Models;

namespace SocietyManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SocietyDBContext _context;

        public DashboardController(SocietyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "User");

            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                ViewBag.FullName = user.FullName;
                ViewBag.FlatNumber = user.FlatNo;
                ViewBag.Contact = user.ContactNo;
            }

            return View();
        }
    }
}

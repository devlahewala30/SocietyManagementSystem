using Microsoft.AspNetCore.Mvc;
using SocietyManagementSystem.Models;

namespace SocietyManagementSystem.Controllers
{
    public class MessagesController : Controller
    {
        private readonly SocietyDBContext _context;

        public MessagesController(SocietyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var messages = _context.Messages
                .Where(m => m.ReceiverId == userId || m.SenderId == userId)
                .ToList();
            return View(messages);
        }
    }
}


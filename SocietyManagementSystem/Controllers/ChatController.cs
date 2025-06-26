// ChatController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocietyManagementSystem.Models;
using System;
using System.Linq;

namespace SocietyManagementSystem.Controllers
{
    public class ChatController : Controller
    {
        private readonly SocietyDBContext _context;

        public ChatController(SocietyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? receiverId)
        {
            int? currentUserId = HttpContext.Session.GetInt32("UserId");
            if (currentUserId == null)
                return RedirectToAction("Login", "User");

            ViewBag.Users = _context.Users.Where(u => u.UserId != currentUserId).ToList();
            ViewBag.ReceiverId = receiverId;

            if (receiverId != null)
            {
                ViewBag.Messages = _context.Messages
                    .Where(m => (m.SenderId == currentUserId && m.ReceiverId == receiverId) ||
                                (m.SenderId == receiverId && m.ReceiverId == currentUserId))
                    .OrderBy(m => m.SentOn)
                    .ToList();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Send(int receiverId, string messageText)
        {
            int? currentUserId = HttpContext.Session.GetInt32("UserId");
            if (currentUserId == null || string.IsNullOrWhiteSpace(messageText))
                return RedirectToAction("Login", "User");

            var msg = new Message
            {
                SenderId = currentUserId.Value,
                ReceiverId = receiverId,
                MessageText = messageText,
                SentOn = DateTime.Now
            };

            _context.Messages.Add(msg);
            _context.SaveChanges();

            return RedirectToAction("Index", new { receiverId });
        }
    }
}

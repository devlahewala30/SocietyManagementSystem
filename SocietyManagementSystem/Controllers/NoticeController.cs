using Microsoft.AspNetCore.Mvc;
using SocietyManagementSystem.Models;
using System;
using System.Linq;

namespace SocietyManagementSystem.Controllers
{
    public class NoticeController : Controller
    {
        private readonly SocietyDBContext _context;

        public NoticeController(SocietyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notices = _context.Notices.OrderByDescending(n => n.PostedOn).ToList();
            return View(notices);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Notice notice)
        {
            if (ModelState.IsValid)
            {
                notice.PostedOn = DateTime.Now;
                _context.Notices.Add(notice);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SocietyManagementSystem.Models;
using System;
using System.Linq;

namespace SocietyManagementSystem.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly SocietyDBContext _context;

        public ComplaintController(SocietyDBContext context)
        {
            _context = context;
        }

        // GET: Complaint/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Complaint/Add
        [HttpPost]
        public IActionResult Add(Complaint complaint)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (ModelState.IsValid)
            {
                complaint.UserId = userId.Value;
                complaint.CreatedOn = DateTime.Now;
                complaint.Status = "Pending";

                _context.Complaints.Add(complaint);
                _context.SaveChanges();

                return RedirectToAction("MyComplaints");
            }

            return View(complaint);
        }

        // GET: Complaint/MyComplaints
        public IActionResult MyComplaints()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var complaints = _context.Complaints
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedOn)
                .ToList();

            return View(complaints);
        }
    }
}

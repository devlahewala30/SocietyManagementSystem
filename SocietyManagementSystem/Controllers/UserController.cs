using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SocietyManagementSystem.Models;
using System.Linq;

namespace SocietyManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly SocietyDBContext _context;

        public UserController(SocietyDBContext context)
        {
            _context = context;
        }

        // ===================== Register =====================
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AppUser user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // ===================== Login =====================
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("FullName", user.FullName);
                HttpContext.Session.SetString("FlatNo", user.FlatNo);
                HttpContext.Session.SetString("ContactNo", user.ContactNo);
                HttpContext.Session.SetString("Email", user.Email);

                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        // ===================== Dashboard =====================
        public IActionResult Dashboard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login");

            ViewBag.FullName = HttpContext.Session.GetString("FullName");
            ViewBag.FlatNo = HttpContext.Session.GetString("FlatNo");
            ViewBag.ContactNo = HttpContext.Session.GetString("ContactNo");
            ViewBag.Email = HttpContext.Session.GetString("Email");

            return View();
        }

        // ===================== Edit Profile =====================
        public IActionResult EditProfile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login");

            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
                return RedirectToAction("Login");

            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(AppUser updatedUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == updatedUser.UserId);
            if (user != null)
            {
                user.FullName = updatedUser.FullName;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.FlatNo = updatedUser.FlatNo;
                user.ContactNo = updatedUser.ContactNo;

                _context.SaveChanges();

                // Update session data
                HttpContext.Session.SetString("FullName", user.FullName);
                HttpContext.Session.SetString("FlatNo", user.FlatNo);
                HttpContext.Session.SetString("ContactNo", user.ContactNo);
                HttpContext.Session.SetString("Email", user.Email);

                return RedirectToAction("Dashboard");
            }

            return View(updatedUser);
        }


        // ===================== Logout =====================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SocietyManagementSystem.Models;
using System.Linq;

public class MaintenanceController : Controller
{
    private readonly SocietyDBContext _context;
    public MaintenanceController(SocietyDBContext context)
    {
        _context = context;
    }

    public IActionResult MyMaintenance()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login", "User");

        var records = _context.Maintenance
            .Where(m => m.UserId == userId)
            .ToList();

        return View(records);
    }
}

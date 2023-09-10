using Jewelry.Data;
using Jewelry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Jewelry.Controllers
{
    public class HomeController : Controller
    {
        private readonly JewelryContext _context;

        public HomeController(JewelryContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            DateTime today = DateTime.UtcNow.Date;

            double todaySales = await _context.pays
                .Where(p => p.DateTime.Date == today)
                .SumAsync(p => p.TotalAmount);

            int todayUsers = await _context.pays
                .Where(p => p.DateTime.Date == today)
                .Select(p => p.UserName)
                .Distinct()
                .CountAsync();
            
            int totalBookings = await _context.pays.CountAsync();
            double totalSalesAmount = await _context.pays.SumAsync(p => p.TotalAmount);
            int totalUsers = await _context.pays.Select(p => p.UserName).Distinct().CountAsync();

            ViewBag.TotalBookings = totalBookings;
            ViewBag.TotalSalesAmount = totalSalesAmount;
            ViewBag.TotalUsers = totalUsers;
            ViewBag.TodaySales = todaySales;
            ViewBag.TodayUsers = todayUsers;

            return View(await _context.pays.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
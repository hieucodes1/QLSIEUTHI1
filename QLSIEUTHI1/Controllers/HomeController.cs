using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSIEUTHI1.Data;
using QLSIEUTHI1.Models;
using System.Diagnostics;

namespace QLSIEUTHI1.Controllers
{
    public class HomeController : Controller
    {
		private readonly QLSIEUTHI1Context _context;

		public HomeController(QLSIEUTHI1Context context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View(_context.Product?.Include(p => p.category).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
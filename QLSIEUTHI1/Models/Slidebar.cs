using Microsoft.AspNetCore.Mvc;
using QLSIEUTHI1.Data;

namespace QLSIEUTHI1.Models
{
	public class Slidebar: ViewComponent
	{
		private readonly QLSIEUTHI1Context _context;

		public Slidebar(QLSIEUTHI1Context context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_context.Category.ToList());
		}
	}
}

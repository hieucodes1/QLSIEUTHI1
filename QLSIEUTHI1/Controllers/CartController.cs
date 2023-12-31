using Microsoft.AspNetCore.Mvc;

namespace QLSIEUTHI1.Controllers
{
    public class CartController : Controller
    {
        public IActionResult AddToCart(int productId)
        {
            return View("Cart");
        }
    }
}

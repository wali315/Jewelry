using Jewelry.Data;
using Jewelry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewelry.Controllers
{
    public class payController : Controller
    {
        private readonly JewelryContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public payController(JewelryContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult pay()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }
        [HttpPost]
        public IActionResult payprocess(pay model)
        {
            // Get the session values
            string firstName = HttpContext.Session.GetString("f");
            string lastName = HttpContext.Session.GetString("l");
            string email = HttpContext.Session.GetString("y");
            List<CartItem> carts = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Calculate the total amount
            int totalAmount = (int)carts.Sum(x => x.Quantity * x.Price);
            var vk = new pay
            {
                UserName = $"{firstName} {lastName}",
                Email = email,
                TotalAmount = totalAmount,
                Cardholdername = model.Cardholdername,
                CreditCard = model.CreditCard ?? "",
                CVV = model.CVV,
                Address = model.Address ?? ""
            };
            // Assuming you have a DbSet named "Payments" in your DbContext
            _dbContext.pays.Add(vk);
            _dbContext.SaveChanges();
            // Clear the cart after successful payment
            HttpContext.Session.Remove("Cart");
            // Redirect to a success page or perform any other desired action
            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}

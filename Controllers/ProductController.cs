using Microsoft.AspNetCore.Mvc;
using Product_Details_Devops.Models;

namespace Product_Details_Devops.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details(int id)
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Cargo Pant",
                Price = 2000,
                Qunatity = 1,
                Discount = 0,
                DateTime = DateTime.Now,
            };

            Product product1 = new Product
            {
                Id = 2,
                Name = "Bodycon Dress",
                Price = 3000,
                Qunatity = 3,
                Discount = 100,
                DateTime = DateTime.Now,
            };
            return View(product);
            return View(product1);
        }
    }
}

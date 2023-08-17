using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        public static List<Cart> cart=new List<Cart>()
        {
            new Cart{CartId=1,productName="Bag",rate=1000,quantity=1,totalprice=1000},
            new Cart{CartId=2,productName="Jeans",rate=800,quantity=1,totalprice=800}

        };
        // GET: CartController
        public ActionResult Index()
        {
            return View(cart);
        }


        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            Cart c = cart.FirstOrDefault(x => x.CartId == id);
            return View(c);
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cart c)
        {
            try
            {
                //cart.IndexOf(cart.FirstOrDefault(x=>x.CartId == id));
                int index = cart.IndexOf(cart.FirstOrDefault(x => x.CartId == id));
                cart[index].quantity = c.quantity;
                cart[index].totalprice = c.totalprice;
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            Cart c = cart.FirstOrDefault(x => x.CartId == id);
            cart.Remove(c);
            return RedirectToAction("Index");
        }

    }
}

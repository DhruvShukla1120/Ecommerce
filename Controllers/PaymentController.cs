using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessPayment(string cardNumber, string cardHolder, string expirationDate, string cvv)
        {
           
            bool paymentSuccess = true;

            if (paymentSuccess)
            {
                ViewBag.Message = "Payment successful!";
            }
            else
            {
                ViewBag.Message = "Payment failed. Please try again.";
            }

            return View("PaymentResult");
        }
    }
}

using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class AccountController : Controller
    {
        private static List<User> RegisteredUsers = new List<User>();
        private static Dictionary<string, string> ResetPasswordRequests = new Dictionary<string, string>();

        public ActionResult Login(bool? loginFailed = false)
        {
            ViewBag.LoginFailed = loginFailed;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                RegisteredUsers.Add(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "manoj" && password == "manoj123")
            {
                // Admin login logic
                return RedirectToAction("AdminDashboard");
            }

            var user = RegisteredUsers.Find(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Regular user login logic
                return RedirectToAction("Index", "Home"); // Redirect to PaymentController's Index action
            }

            return RedirectToAction("Login", new { loginFailed = true });
        }

        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult UserDashboard()
        {
            return View();
        }
        private string GenerateResetToken()
        {
            return Guid.NewGuid().ToString();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            ViewBag.InvalidCredentials = false; // Initialize as false to avoid null assignment
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string username, string email)
        {
            var user = RegisteredUsers.Find(u => u.Username == username && u.Email == email);
            if (user != null)
            {
                // Generate a reset token (you can use a library for this)
                string resetToken = GenerateResetToken();

                // Store the reset token with the username
                ResetPasswordRequests[username] = resetToken;

                // Redirect to the reset password page
                return RedirectToAction("ResetPassword", new { username });
            }

            ViewBag.InvalidCredentials = true; // Set to true if credentials are invalid
            return View();
        }


        [HttpGet]
        public ActionResult ResetPassword(string username)
        {
            if (ResetPasswordRequests.ContainsKey(username))
            {
                ViewBag.Username = username;
                return View();
            }

            // Invalid request or token expired
            return RedirectToAction("ForgotPassword");
        }

        [HttpPost]
        public ActionResult ResetPassword(string username, string password)
        {
            if (ResetPasswordRequests.ContainsKey(username))
            {
                var user = RegisteredUsers.Find(u => u.Username == username);
                if (user != null)
                {
                    user.Password = password;
                    ResetPasswordRequests.Remove(username);
                    return RedirectToAction("Login");
                }
            }

            // Invalid request or token expired
            return RedirectToAction("ForgotPassword");
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Cryptography;
using ShoppingKart.DAL.Data;
using ShoppingKart.BLL.Services;
using ShoppingKart.Core.Models;
using ShoppingKart.Core.Exceptions;

namespace ShoppingKart.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show the Login form
        public IActionResult LoginForm()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home",new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        // Handle Login form submission
        [HttpPost]
        //public async Task<IActionResult> Login(string Username, string Password, bool RememberMe)
        public async Task<IActionResult> Login(string Username, string Password)
        {
            try
            {
                // Look up the user in the database
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == Username);

            if (user != null && user.PasswordHash == ComputeHash(Password))
            {
                // Create claims for the logged-in user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),         // Username
                    new Claim(ClaimTypes.Role, user.Role)              // User role (e.g., Admin/User)
                };

                // Create a claims identity and claims principal
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Sign in the user with the claims principal
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);


                //kim cr : Coockies add, read, delete codes. Added for reference
                //if (RememberMe)
                //{
                //    var cookieOptions = new CookieOptions
                //    {
                //        Expires = DateTime.Now.AddDays(7), // Cookie expires in 7 days
                //        HttpOnly = true, // Prevent JavaScript access
                //        Secure = true    // Use secure cookies (for HTTPS)
                //    };

                //    Response.Cookies.Append("Username", user.Username, cookieOptions);
                //    string username = Request.Cookies["Username"];
                //    Response.Cookies.Delete("Username");
                //}


                //kim cr - for RememberMe purpose.
                //var authProperties = new AuthenticationProperties
                //{
                //    IsPersistent = RememberMe, // Set persistence based on Remember Me checkbox
                //    ExpiresUtc = RememberMe ? DateTimeOffset.UtcNow.AddDays(7) : DateTimeOffset.UtcNow.AddMinutes(30)
                //};
                //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).Wait();


                HttpContext.Session.SetString("Username", user.UserName);
                HttpContext.Session.SetString("Role", user.Role);

                // Redirect to the homepage or any authorized action
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }

            // Invalid login attempt
            TempData["ErrorMessage"] = "Invalid username or password.";
            return RedirectToAction("LoginForm");
            }
            catch (CustomAppException ex)
            {
                return RedirectToAction("Error", "Home",new { ErrorMessage = "Custom ErrorMessage: " + ex.Message, ErrorStackTrace = "Custom ErrorStackTrace: " + ex.StackTrace });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        // Compute a SHA256 hash for the password
        private string ComputeHash(string input)
        {
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                    return Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                throw new CustomAppException(ex.Message);
            }
        }

        //Show User Profile
        public IActionResult Profile()
        {
            try
            {
                var UserInfo = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

                if (UserInfo is not null)
                {
                    return View(UserInfo);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home",new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        //Submit User Profile Edit Form
        public IActionResult UserProfileEditForm(User model)
        {
            try
            {
                var UserInfo = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);

            if (UserInfo is not null)
            {
                UserInfo.FullName = model.FullName;
                UserInfo.Email = model.Email;
                UserInfo.PhoneNum = model.PhoneNum;
                UserInfo.Address = model.Address;

                // Save user updated details in the database
                _context.Users.Update(UserInfo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home",new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        // Handle Logout
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.Session.SetString("Username", "");
                HttpContext.Session.SetString("Role", "");
                TempData["SuccessMessage"] = "Logged out successfully!";
                return RedirectToAction("LoginForm");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace});
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home",new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

        [HttpPost]
        public IActionResult SignUpForm(string Username, string Password, string FullName, string Email, string PhoneNum, string Address)
        {
            try
            {
                // Check if the username already exists
                var existingUser = _context.Users.FirstOrDefault(x => x.UserName == Username);
            if (existingUser != null)
            {
                TempData["ErrorMessage"] = "Username already exists. Please choose a different one.";
                return RedirectToAction("SignUp");
            }

            // Hash the password
            string hashedPassword = ComputeHash(Password);

            // Create a new user
            var newUser = new User
            {
                UserName = Username,
                PasswordHash = hashedPassword,
                Role = "User", // Default role
                FullName = FullName,
                Email = Email,
                PhoneNum = PhoneNum,
                Address = Address
            };

            // Save the user in the database
            _context.Users.Add(newUser);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Account created successfully! You can now log in.";
            return RedirectToAction("LoginForm");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home",new { ErrorMessage = "ErrorMessage: " + ex.Message, ErrorStackTrace = "ErrorStackTrace: " + ex.StackTrace });
            }
        }

    }
}



//using ShoppingKart.Core.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Cryptography;

//namespace ShoppingKart.UI.Controllers
//{
//    public class AccountController : Controller
//    {

//        private readonly ApplicationDbContext _context;

//        public AccountController( ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        //public IActionResult Index()
//        //{
//        //    return View();
//        //}

//        public IActionResult LoginForm()
//        {
//            return View();
//        }

//        public IActionResult Login(string Username, string Password)
//        {
//            //var user = _userRepository.GetUser(Username);
//            var user = _context.Users.FirstOrDefault(x => x.Username == Username);

//            if (user != null && user.PasswordHash == ComputeHash(Password))
//            {
//                HttpContext.Session.SetString("Username", user.Username);
//                HttpContext.Session.SetString("Role", user.Role);

//                TempData["SuccessMessage"] = "Login successful!";
//                return RedirectToAction("Index", "Home");
//            }

//            TempData["ErrorMessage"] = "Invalid username or password.";
//            return RedirectToAction("LoginForm");
//        }

//        private string ComputeHash(string input)
//        {
//            using (var sha256 = SHA256.Create())
//            {
//                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
//                return Convert.ToBase64String(bytes);
//            }
//        }

//        public IActionResult Logout()
//        {
//            HttpContext.Session.Clear();
//            return RedirectToAction("Login");
//        }
//    }
//}

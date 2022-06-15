using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using LogReg.Models;

namespace LogReg.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        // If a user is logged in already, redirect to Success
        if (HttpContext.Session.GetInt32("user") != null)
        {
            return RedirectToAction("Success");
        }
        else
        {
            return View();
        }
    }

    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if(_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");
                return View("Index");
            }

            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("user", newUser.UserId);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    
    [HttpGet("login")]
    public IActionResult Login()
    {
        // If a user is logged in already, redirect to Success
        if (HttpContext.Session.GetInt32("user") != null)
        {
            return RedirectToAction("Success");
        }
        else
        {
            return View();
        }
    }

    [HttpPost("user/login")]
    public IActionResult LoginProcess(LogUser loginUser)
    {
        if (ModelState.IsValid)
        {
            User userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LogEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
                return View("Login");
            }
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
                return View("Login");
            }
            else
            {
                HttpContext.Session.SetInt32("user", userInDb.UserId);
                return RedirectToAction("Success");
            }
        }
        else
        {
            return View("Login");
        }
    }


    [HttpGet("success")]
    public IActionResult Success()
    {
        // If a user is not logged in, redirect to Index
        if (HttpContext.Session.GetInt32("user") == null)
        {
            return RedirectToAction("Index");
        }
        User loggedInUser = _context.Users.FirstOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("user"));
        return View(loggedInUser);
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        // Clear Session on logout, redirect to Index
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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

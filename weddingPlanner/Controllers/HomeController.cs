using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using weddingPlanner.Models;

namespace weddingPlanner.Controllers;

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
        if (HttpContext.Session.GetInt32("user") != null)
        {
            return RedirectToAction("Dashboard");
        }
        return View();
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

            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("user/login")]
    public IActionResult Login(LogUser loginUser)
    {
        if (ModelState.IsValid)
        {
            User userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LogEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
                return View("Index");
            }
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetInt32("user", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("user") == null)
        {
            return RedirectToAction("Index");
        }
        ViewBag.LoggedUser = _context.Users.FirstOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("user"));
        ViewBag.AllWeddings = _context.Weddings.Include(a => a.Attendees).ThenInclude(a => a.User).ToList();
        return View();
    }

    [HttpGet("wedding/create")]
    public IActionResult Wedding()
    {
        ViewBag.LoggedUser = _context.Users.FirstOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("user"));
        return View();
    }

    [HttpPost("wedding/add")]
    public IActionResult AddWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        else
        {
            ViewBag.LoggedUser = _context.Users.FirstOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("user"));
            return View("Wedding");
        }
    }

    
    [HttpGet("wedding/{weddingId}")]
    public IActionResult OneWedding(int weddingId)
    {
        Wedding oneWedding = _context.Weddings.Include(a => a.Attendees).ThenInclude(a => a.User).FirstOrDefault(a => a.WeddingId == weddingId);
        return View(oneWedding);
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
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

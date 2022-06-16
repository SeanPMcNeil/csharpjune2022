using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsDishes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace chefsDishes.Controllers;

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
        ViewBag.AllChefs = _context.Chefs.Include(a => a.DishesCreated).ToList();
        return View();
    }

    [HttpGet("chef/new")]
    public IActionResult Chef()
    {
        return View();
    }

    [HttpPost("chef/add")]
    public IActionResult AddChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Chef");
        }
    }

    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        ViewBag.AllDishes = _context.Dishes.Include(a => a.Chef).ToList();
        return View();
    }

    [HttpGet("dish/new")]
    public IActionResult Dish()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }

    [HttpPost("dish/add")]
    public IActionResult AddDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        else
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("Dish");
        }
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

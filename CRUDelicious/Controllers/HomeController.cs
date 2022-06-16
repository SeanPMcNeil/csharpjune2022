using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

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
        ViewBag.AllDishes = _context.Dishes.OrderBy(a => a.Name).ToList();
        return View();
    }

    [HttpGet("dish/new")]
    public IActionResult NewDish()
    {
        return View();
    }

    [HttpPost("dish/new/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewDish");
        }
    }

    [HttpGet("dish/{dishId}")]
    public IActionResult OneDish(int dishId)
    {
        Dish singleDish = _context.Dishes.FirstOrDefault(a => a.DishId == dishId);
        return View(singleDish);
    }

    [HttpGet("dish/delete/{dishId}")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish dishToDelete = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        _context.Dishes.Remove(dishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("dish/edit/{dishId}")]
    public IActionResult EditDish(int dishId)
    {
        Dish singleDish = _context.Dishes.FirstOrDefault(a => a.DishId == dishId);
        return View(singleDish);
    }

    [HttpPost("dish/edit/{dishId}/process")]
    public IActionResult ProcessEdit(int dishId, Dish newVersionOfDish)
    {
        Dish oldDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (ModelState.IsValid)
        {
            oldDish.Name = newVersionOfDish.Name;
            oldDish.Chef = newVersionOfDish.Chef;
            oldDish.Tastiness = newVersionOfDish.Tastiness;
            oldDish.Calories = newVersionOfDish.Calories;
            oldDish.Description = newVersionOfDish.Description;
            oldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction("OneDish", oldDish );
        }
        else
        {
            return View("EditDish", oldDish);
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

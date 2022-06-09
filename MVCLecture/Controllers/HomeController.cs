using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCLecture.Models;

namespace MVCLecture.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(User newUser)
    {
        if (ModelState.IsValid)
        {
            // This means we passed our validations
            // Then redirect to success
            return RedirectToAction("Success", newUser);
        } 
        else 
        {
            // What to do it validation errors trigger
            return View("Index");
        }
        // Console.WriteLine(newUser.Name);
        // Console.WriteLine(newUser.FavColor);
        // Console.WriteLine(newUser.FavNum);
    }
    
    [HttpGet("success")]
    public IActionResult Success(User newUser)
    {
        // ViewBag.User = newUser;
        return View(newUser);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

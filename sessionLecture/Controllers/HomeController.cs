using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sessionLecture.Models;
using Microsoft.AspNetCore.Http;

namespace sessionLecture.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // // To set the data
        // HttpContext.Session.SetString("User", "Sean");
        // // To get the data
        // string? user = HttpContext.Session.GetString("User");
        // Console.WriteLine(user);
        // Can check if there is something in session and do something
        if (HttpContext.Session.GetInt32("Sum") == null)
        {
            HttpContext.Session.SetInt32("Sum", 0);
        }
        return View();
    }

    [HttpPost("setName")]
    public IActionResult setName(string Name, int Num)
    {
        HttpContext.Session.SetString("User", Name);
        int? original = HttpContext.Session.GetInt32("Sum");
        HttpContext.Session.SetInt32("Sum", (int)original + Num);
        return RedirectToAction("Index");
    }

    [HttpGet("delete")]
    public IActionResult delete()
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

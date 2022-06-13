using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPass2.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPass2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("password")]
    public IActionResult Password()
    {

        if (HttpContext.Session.GetInt32("Count") == null)
        {
            HttpContext.Session.SetInt32("Count", 0);
        }

        int? start = HttpContext.Session.GetInt32("Count");
        HttpContext.Session.SetInt32("Count", (int)start + 1);

        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] stringChars = new char[14];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        
        HttpContext.Session.SetString("RandomPass", new String(stringChars));

        return PartialView();
    }

    [HttpGet("clear")]
    public IActionResult Clear()
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

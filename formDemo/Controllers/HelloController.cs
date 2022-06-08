using Microsoft.AspNetCore.Mvc;
namespace formDemo.Controllers;

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string Name, string Species, int Age)
    {
        ViewBag.Name = Name;
        ViewBag.Species = Species;
        ViewBag.Age = Age;
        return View("Success");
    }

    [HttpGet("success")]
    public ViewResult Success()
    {
        return View();
    }
    
}
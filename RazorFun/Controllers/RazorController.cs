using Microsoft.AspNetCore.Mvc; // This is a service that brings in MVC functionality
namespace RazorFun.Controllers;     //be sure to use your own project's namespace!
public class RazorController : Controller   //remember inheritance??
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }
}
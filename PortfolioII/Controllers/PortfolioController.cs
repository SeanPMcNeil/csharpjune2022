using Microsoft.AspNetCore.Mvc; 
namespace PortfolioII.Controllers;
public class PortfolioController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpGet("projects")]
    public ViewResult Project()
    {
        return View();
    }

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View();
    }
}
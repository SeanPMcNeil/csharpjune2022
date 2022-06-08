using Microsoft.AspNetCore.Mvc; 
namespace PortfolioI.Controllers;
public class PortfolioController : Controller
{
    [HttpGet("")]
    public string Index()
    {
        return "This is my Index!";
    }

    [HttpGet("projects")]
    public string Project()
    {
        return "These are my projects";
    }

    [HttpGet("contact")]
    public string Contact()
    {
        return "This is my Contact!";
    }
}
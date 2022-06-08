using Microsoft.AspNetCore.Mvc; 
namespace DojoSurvey.Controllers;
public class SurveyController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("result")]
    public IActionResult Result(string Name, string Dojo, string Language, string Comment)
    {
        ViewBag.Name = Name;
        ViewBag.Dojo = Dojo;
        ViewBag.Language = Language;
        ViewBag.Comment = Comment;
        return View();
    }
}
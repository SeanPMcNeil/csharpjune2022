using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using databaseLecture.Models;

namespace databaseLecture.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // This establishes our connection to the database
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.AllItems = _context.Items.OrderBy(a => a.Name).ToList();
        return View();
    }

    [HttpPost("item/add")]
    public IActionResult AddItem(Item newItem)
    {
        // We add this to the database so long as it's correct
        if (ModelState.IsValid)
        {
            // We can add to the database
            _context.Add(newItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
        else
        {
            return View("Index");
        }
    }

    [HttpGet("item/edit/{itemId}")]
    public IActionResult EditItem(int itemId)
    {
        // We need to find the item
        Item itemToEdit = _context.Items.FirstOrDefault(a => a.ItemId == itemId);

        return View(itemToEdit);
    }

    [HttpPost("item/update/{itemId}")]
    public IActionResult UpdateItem(int itemId, Item newVersionOfItem)
    {
        Item oldItem = _context.Items.FirstOrDefault(a => a.ItemId == itemId);
        // NOT a valid method to update
        // oldItem = newVersionOfItem;
        oldItem.Name = newVersionOfItem.Name;
        oldItem.Description = newVersionOfItem.Description;
        oldItem.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


    [HttpGet("item/delete/{itemId}")]
    public IActionResult DeleteItem(int itemId)
    {
        Item itemToDelete = _context.Items.SingleOrDefault(i => i.ItemId == itemId);
        _context.Items.Remove(itemToDelete);
        _context.SaveChanges();

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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using productsCategories.Models;

namespace productsCategories.Controllers;

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
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
    }

    [HttpPost("product/add")]
    public IActionResult AddProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.AllProducts = _context.Products.ToList();
            return View("Index");
        }
    }

    [HttpPost("product/addcategory")]
    public IActionResult AddCategoryToProduct(Association newAssoc)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newAssoc);
            _context.SaveChanges();
            return RedirectToAction("OneProduct", new{productId = newAssoc.ProductId});
        }
        else
        {
            return View("OneProduct", new{productId = newAssoc.ProductId});
        }
    }

    [HttpPost("category/addproduct")]
    public IActionResult AddProductToCategory(Association newAssoc)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newAssoc);
            _context.SaveChanges();
            return RedirectToAction("OneCategory", new{categoryId = newAssoc.CategoryId});
        }
        else
        {
            return View("OneCategory", new{categoryId = newAssoc.CategoryId});
        }
    }


    [HttpGet("allcategories")]
    public IActionResult AllCategories()
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        return View();
    }

    [HttpPost("category/add")]
    public IActionResult AddCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("AllCategories");
        }
        else
        {
            ViewBag.AllCategories = _context.Categories.ToList();
            return View("AllCategories");
        }
    }

    [HttpGet("product/{productId}")]
    public IActionResult OneProduct(int productId)
    {
        Product singleProduct = _context.Products.Include(a => a.ListedCategories).ThenInclude(c => c.Category).FirstOrDefault(a => a.ProductId == productId);
        ViewBag.OneProduct = singleProduct;
        ViewBag.OtherCategories = _context.Categories.Include(a => a.ProductsInCategory).Where(a => a.ProductsInCategory.All(a => a.ProductId != productId)).ToList();
        return View();
    }

    [HttpGet("category/{categoryId}")]
    public IActionResult OneCategory(int categoryId)
    {
        Category singleCategory = _context.Categories.Include(a => a.ProductsInCategory).ThenInclude(p => p.Product).FirstOrDefault(a => a.CategoryId == categoryId);
        ViewBag.OneCategory = singleCategory;
        ViewBag.OtherProducts = _context.Products.Include(a => a.ListedCategories).Where(a => a.ListedCategories.All(a => a.CategoryId != categoryId)).ToList();
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

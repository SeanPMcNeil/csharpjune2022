using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQEruption.Models;

namespace LINQEruption.Controllers;

public class HomeController : Controller
{
    List<Eruption> eruptions = new List<Eruption>()
    {
        new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
        new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
        new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
        new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
        new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
        new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
        new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
        new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
        new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
        new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
        new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
        new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
        new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
    };
    // // Example Query - Prints all Stratovolcano eruptions
    // IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
    // PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

    // // Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
    // static void PrintEach(IEnumerable<dynamic> items, string msg = "")
    // {
    //     Console.WriteLine("\n" + msg);
    //     foreach (var item in items)
    //     {
    //         Console.WriteLine(item.ToString());
    //     }
    // }

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // First Eruption in Chile
        Eruption firstChile = eruptions.FirstOrDefault(l => l.Location == "Chile");
        ViewBag.FirstChile = firstChile;

        // First Eruption from "Hawaiian Is"
        Eruption firstHawaiian = eruptions.FirstOrDefault(l => l.Location == "Hawaiian Is");
        ViewBag.FirstHawaiian = firstHawaiian;

        // First Eruption in New Zealand after 1900
        Eruption newZeaPost1900 = eruptions.FirstOrDefault(l => l.Location == "New Zealand" &l.Year > 1900);
        ViewBag.NewZeaPost1900 = newZeaPost1900;

        // Eruptions Over 2000m Elevation
        List<Eruption> over2000 = eruptions.Where(e => e.ElevationInMeters > 2000).ToList();
        ViewBag.Over2000 = over2000;

        // Eruptions from Volcanos Starting with Z
        List<Eruption> startZ = eruptions.Where(n => n.Volcano.StartsWith("Z")).ToList();
        ViewBag.StartZ = startZ;

        // Highest Elevation Integer
        int highestElevation = eruptions.Max(e => e.ElevationInMeters);
        ViewBag.HighestElevation = highestElevation;

        // Name of Volcano from Highest Elevation
        Eruption highestName = eruptions.FirstOrDefault(i => i.ElevationInMeters == highestElevation);
        ViewBag.HighestName = highestName.Volcano;

        // Alphabetical Print
        List<Eruption> allAlpha = eruptions.OrderBy(v => v.Volcano).ToList();
        ViewBag.AllAlpha = allAlpha;

        // Eruptions before 1000 Alphabetically
        List<Eruption> before1000 = eruptions.Where(y => y.Year < 1000).OrderBy(v => v.Volcano).ToList();
        ViewBag.Before1000 = before1000;

        // Eruptions before 1000 Names Only Alphabetically
        List<string> before1000Names = eruptions.Where(y => y.Year < 1000).OrderBy(v => v.Volcano).Select(o => o.Volcano).ToList();
        // List<string> before1000Names = before1000.Select(o => o.Volcano).ToList();
        ViewBag.Before1000Names = before1000Names;

        return View();
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

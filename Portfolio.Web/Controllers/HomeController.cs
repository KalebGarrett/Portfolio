using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Models;

namespace Portfolio.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Kaleb Garrett";
        return View();
    }

    public IActionResult About()
    {
        ViewData["Title"] = "About";
        return View();
    }

    public IActionResult Project()
    {
        ViewData["Title"] = "Project";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Title"] = "Contact";
        return View();
    }

    public IActionResult Submission()
    {
        ViewData["Title"] = "Submission";
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProjectService _projectService;

    public HomeController(ILogger<HomeController> logger, ProjectService projectService)
    {
        _logger = logger;
        _projectService = projectService;
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

    public async Task<IActionResult> Project()
    {
        var model = new ProjectViewModel();
        model.Projects = await _projectService.GetAll();
        ViewData["Title"] = "Project";
        return View(model);
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
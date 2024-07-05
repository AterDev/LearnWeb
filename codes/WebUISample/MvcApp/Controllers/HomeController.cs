using Core;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers;
public class HomeController(ILogger<HomeController> logger, IWebHostEnvironment env) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IWebHostEnvironment _env = env;

    [HttpGet]
    public IActionResult Index()
    {
        var noteService = new NoteService(_env.WebRootPath);
        var notes = noteService.GetNotes();
        return View(notes);
    }

    [HttpPost]
    public IActionResult Index(string content)
    {
        var noteService = new NoteService(_env.WebRootPath);
        var res = noteService.Save(content);
        return RedirectToAction("Index");
    }
}

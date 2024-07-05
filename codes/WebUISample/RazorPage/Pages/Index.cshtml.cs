using Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Pages;
public class IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment env) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IWebHostEnvironment _env = env;

    public List<string> Notes { get; set; } = [];

    public void OnGet()
    {
        var noteService = new NoteService(_env.WebRootPath);
        Notes = noteService.GetNotes();
    }

    public void OnPost(string content)
    {
        var noteService = new NoteService(_env.WebRootPath);
        var res = noteService.Save(content);
        Notes = noteService.GetNotes();
    }
}
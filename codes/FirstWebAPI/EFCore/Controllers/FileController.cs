using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public FileController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet("stream")]
    public async Task DownloadStreamAsync()
    {
        Response.Headers.ContentDisposition = "attachment; filename=test.zip";
        var filePath = @"D:\Downloads\VisualStudio.GitHub.Copilot.vsix";
        using (var archive = new ZipArchive(Response.BodyWriter.AsStream(), ZipArchiveMode.Create))
        {
            archive.CreateEntryFromFile(filePath, "test.vsix");
        }

        await Response.CompleteAsync();
    }
}

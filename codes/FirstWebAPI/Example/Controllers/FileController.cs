using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public FileController(IWebHostEnvironment environment)
    {
        _env = environment;
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

    [HttpPost("upload")]
    public async Task<ActionResult<string>> UploadImgAsync(IFormFile file)
    {
        if (file == null)
        {
            ModelState.AddModelError("file", "没有上传的文件");
            return BadRequest(ModelState);
        }

        if (file.Length > 0)
        {
            string fileExt = Path.GetExtension(file.FileName).ToLowerInvariant();
            long fileSize = file.Length; // 获得文件大小，以字节为单位
            // 判断后缀是否是图片
            string[] permittedExtensions = [".jpeg", ".jpg", ".png", ".bmp", ".svg", ".webp"];

            if (fileExt == null)
            {
                ModelState.AddModelError("file", "上传的文件没有后缀");
                return BadRequest(ModelState);
            }
            if (!permittedExtensions.Contains(fileExt))
            {
                ModelState.AddModelError("file", "不支持的图片格式");
                return BadRequest(ModelState);
            }
            if (fileSize > 1024 * 500 * 1)
            {
                // 上传的文件不能大于1M
                ModelState.AddModelError("file", "上传的文件不能大于1M");
                return BadRequest(ModelState);
            }
            // TODO:保存文件
            var path = Path.Combine(_env.WebRootPath, file.Name);
            using (var fileStream = System.IO.File.Create(path))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }
            return path;
        }
        return Problem("文件不正确", title: "业务错误");
    }
}

using Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 获取记事本接口
app.MapGet("/notes", (IWebHostEnvironment _env) =>
{
    var note = new NoteService(_env.ContentRootPath);
    return note.GetNotes();
});

// 添加内容
app.MapPost("/notes", (IWebHostEnvironment _env, string content) =>
{
    var noteService = new NoteService(_env.ContentRootPath);
    noteService.Save(content);
    return Results.Ok();
});

app.Run();

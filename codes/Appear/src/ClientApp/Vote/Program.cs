using Blazored.LocalStorage;
using ClientAPI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Vote;
using Vote.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddClientAPI(option =>
{
    option.BaseAddress = new Uri("http://localhost:5002");
});

builder.Services.AddFluentUIComponents();
builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddSingleton<UserStateService>();

await builder.Build().RunAsync();

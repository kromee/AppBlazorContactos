using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor.Contacts.Wasm.Client;
using Blazor.Contacts.Wasm.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//se agrega el contenedor de dependencias el servicio
builder.Services.AddScoped<IContactService, ContactService>();


await builder.Build().RunAsync();


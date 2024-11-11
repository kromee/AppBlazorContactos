using System.Data;
using System.Data.SqlClient;
using Blazor.Contacts.Wasm.Repositories;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


// Configurar el servicio de base de datos con la cadena de conexión
string connectionString = builder.Configuration.GetConnectionString("ConectionSQL");
builder.Services.AddSingleton<IDbConnection>(sp => new SqlConnection(connectionString));


builder.Services.AddScoped<IContactRepository, ContactResitory>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


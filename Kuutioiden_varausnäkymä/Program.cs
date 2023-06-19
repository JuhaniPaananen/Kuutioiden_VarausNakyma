using System;
using System.Text.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

var client = new HttpClient();
using StringContent jsonContent = new(JsonSerializer.Serialize(new { target = "locations", type = "name", text = "Neptunus", dateFrom = "", dateTo = "", filters = "", show = true }), Encoding.UTF8, "application/json");
using HttpResponseMessage response = await client.PostAsync("https://lukkarit.centria.fi/rest/locations", jsonContent);
response.EnsureSuccessStatusCode();
var jsonResponse = await response.Content.ReadAsStringAsync();
//Console.WriteLine($"{jsonResponse}\n");

namespace ConsoleC
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "";
        }

    }
}
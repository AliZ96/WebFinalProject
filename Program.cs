using Microsoft.EntityFrameworkCore;
using WebFinalProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısı - MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 25))));  // MySQL sürümüne göre güncelleyin

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Controller yönlendirmeleri
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// SearchController için yönlendirme yapılacaksa, controller adı Search olarak yazılmalı
app.MapControllerRoute(
    name: "search",
    pattern: "{controller=Search}/{action=Index}/{id?}");

app.Run();

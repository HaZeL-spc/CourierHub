using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using CourierCastingApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICourierCastingAppRepository, CourierCastingAppRepository>();
builder.Services.AddDbContext<CourierCastingAppDbContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("CourierCastingAppConnection")));
builder.Services.AddSession();
// Add services to the container.
builder.SetupServices();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Seed();
app.UseSession();

app.Run();

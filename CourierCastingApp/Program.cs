using Auth0.AspNetCore.Authentication;
using CourierCastingApp.Filters;
using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Polly;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICourierCastingAppRepository, CourierCastingAppRepository>();
builder.Services.AddDbContext<CourierCastingAppDbContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("CourierCastingAppConnection")));
builder.Services.AddSession();
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
});
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(UpdateCacheFilter), order: 1);
});
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Seed();
app.UseSession();

app.Run();

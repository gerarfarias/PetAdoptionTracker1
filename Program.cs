using Microsoft.EntityFrameworkCore;
using PetAdoptionTracker.Data;

var builder = WebApplication.CreateBuilder(args);

// -----------------------
// Database + Health Checks
// -----------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>("Database");

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// -----------------------
// Health Endpoint Mapping
// -----------------------
app.MapHealthChecks("/healthz");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


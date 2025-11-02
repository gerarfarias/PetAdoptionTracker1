using Microsoft.EntityFrameworkCore;
using PetAdoptionTracker.Data;
using PetAdoptionTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext BEFORE builder.Build()
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MVC Support
builder.Services.AddControllersWithViews();

// Register PetService for Dependency Injection
builder.Services.AddScoped<IPetService, PetService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Required for Bootstrap, CSS, images, etc.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


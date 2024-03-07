using GemVogue.Data;
using GemVogue.Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<GemVogueDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
    .AddDefaultIdentity<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
    })
    .AddEntityFrameworkStores<GemVogueDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

AppDbInitializer.Seed(app);

app.Run();
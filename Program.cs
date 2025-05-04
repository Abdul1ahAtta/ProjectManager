using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Data;
using ProjectManager.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Lägg till databaskoppling
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔧 Ändra detta ⬇ (ta bort kravet på bekräftad e-post)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // 👈 Ändrad från true till false
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// 🔧 Registrera din service
builder.Services.AddScoped<IProjectService, ProjectService>();

// 🔧 MVC med Razor views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // 👈 Viktigt för Identity
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // 👈 För inloggning/registrering

app.Run();

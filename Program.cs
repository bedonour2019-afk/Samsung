using Microsoft.EntityFrameworkCore;
using SamsungStore.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add MVC Controllers and Views services
builder.Services.AddControllersWithViews();

// 2. Register ApplicationDbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 3. Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Enable serving static files (CSS, JS, Images from wwwroot)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 4. Set default route (HomeController -> Index action)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
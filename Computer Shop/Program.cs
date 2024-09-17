var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Computer}/{action=Computer}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Order}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=customer}/{id?}");

app.Run();

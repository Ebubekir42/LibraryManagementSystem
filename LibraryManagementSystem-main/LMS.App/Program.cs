using AutoMapper;
using LMS.App.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(name: "Personel", areaName: "Personel", pattern: "Personel/{controller=Dashboard}/{action=Index}/{id?}");
    endpoints.MapAreaControllerRoute(name: "Kargo", areaName: "Kargo", pattern: "Kargo/{controller=Order}/{action=Index}/{id?}");
    endpoints.MapAreaControllerRoute(name: "User", areaName: "User", pattern: "User/{controller=Loan}/{action=Index}/{id?}");
    endpoints.MapAreaControllerRoute(name: "Admin", areaName: "Admin", pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Anasayfa}/{id?}");
    endpoints.MapRazorPages();
});
app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultadminUser();

app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LMS.Repositories;
using LMS.Entities.Models;

namespace LMS.App.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                .AddSupportedUICultures("tr-TR")
                .SetDefaultCulture("tr-TR");
            });
        }
        public static async void ConfigureDefaultadminUser(this IApplicationBuilder app)
        {
            const string adminPassword = "Admin+123456";

            UserManager<ApplicationUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            ApplicationUser user = await userManager.FindByEmailAsync("f201213090@ktun.edu.tr");
            if (user is null)
            {
                user = new ApplicationUser()
                {
                    Email = "f201213090@ktun.edu.tr",
                    PhoneNumber = "5056315900",
                    IdentityNumber = "19046446100",
                    FirstName = "Muhammet Ebubekir",
                    LastName = "Türk",
                    UserName = "19046446100",
                    Password = adminPassword
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                    throw new Exception("Admin user could not created.");

                var roleResult = await userManager.AddToRolesAsync(user, roleManager
                    .Roles
                    .Select(r => r.Name)
                    .Where(r => r.Contains("Admin")));

                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for admin.");

            }
        }
    }
}

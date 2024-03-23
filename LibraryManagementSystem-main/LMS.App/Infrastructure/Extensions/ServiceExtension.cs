using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using LMS.Repositories;
using LMS.Repositories.Contracts;
using LMS.Services;
using LMS.Services.Contracts;
using LMS.Entities.Models;
using LMS.App.Models;

namespace LMS.App.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(@"Data Source = LENOVO; Initial Catalog = LMS; Integrated Security = true; MultipleActiveResultSets = true; TrustServerCertificate=True;",
                    b => b.MigrationsAssembly("LMS.App"));
                options.EnableSensitiveDataLogging(true);
            });
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.Cookie.Name = "LMS.App.Session";
                option.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Book>(b => SessionBook.GetBook(b));
            services.AddScoped<ApplicationUser>(u => SessionUser.GetUser(u));
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ICarrierTypeRepository, CarrierTypeRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IFormatRepository, FormatRepository>();
            services.AddScoped<IContentTypeRepository, ContentTypeRepository>();
            services.AddScoped<IMediaTypeRepository, MediaTypeRepository>();
            services.AddScoped<IFineRepository, FineRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<INonOrderRepository, NonOrderRepository>();
            services.AddScoped<IBookingOfficeRepository, BookingOfficeRepository>();
            services.AddScoped<IReceiveRepository, ReceiveRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IApplicationUserService, ApplicationUserManager>();
            services.AddScoped<IBookAuthorService, BookAuthorManager>();
            services.AddScoped<ILoanService, LoanManager>();
            services.AddScoped<IMediaTypeService, MediaTypeManager>();
            services.AddScoped<IContentTypeService, ContentTypeManager>();
            services.AddScoped<ICarrierTypeService, CarrierTypeManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<IFormatService, FormatManager>();
            services.AddScoped<IFineService, FineManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IProvinceService, ProvinceManager>();
            services.AddScoped<IDistrictService, DistrictManager>();
            services.AddScoped<INonOrderService, NonOrderManager>();
            services.AddScoped<IBookingOfficeService, BookingOfficeManager>();
            services.AddScoped<IReceiveService, ReceiveManager>();
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });

        }
        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
        }
    }
}

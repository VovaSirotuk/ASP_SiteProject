using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models; // ������� YourNamespace �� ��������� ������ ���� ������ �������

public class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // ������� ������������ ��� ���������� � ���������������
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        // ������� ������������ ��� DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6; // мінімальна довжина пароля
            options.Password.RequiredUniqueChars = 0; // кількість унікальних символів
            // Налаштування для дозволу українських літер у UserName
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789- ._@+абвгґдеєжзийіїклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИЙІЇКЛМНОПРСТУФХЦЧШЩЬЮЯ";
            options.User.RequireUniqueEmail = true; // Якщо ви хочете, щоб Email був унікальним
            options.SignIn.RequireConfirmedAccount = false; // Підтвердження облікового запису через email
            options.Tokens.AuthenticatorTokenProvider = null;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole>()
            .AddDefaultUI();

        var app = builder.Build();

        //using (var context = new applicationdbcontext())
        //{
        //    var user = findu

        //    context.users.removerange(users);
        //    context.savechanges();
        //}
        // ������������ ���������� �� �������������
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapControllers();
        // scope для роботи з базою даних
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            //var user = await usermanager.findbyidasync("8e55dcce-1975-4af3-8b89-3c09e41762a0");
            //await usermanager.deleteasync(user);
            //AddCourses(scope.ServiceProvider);
        }

        app.MapRazorPages();
        app.Run();
    }

    public static void AddCourses(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var course1 = new Course
        {
            Title = "English",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatibus autem corrupti quis,\r\n fugit, aliquid et optio accusantium quo maxime, quae officia iure ex dolore! Delectus modi incidunt minima accusantium ipsam?",
            StartDate = new DateTime(2024, 8, 15),
            EndDate = new DateTime(2024, 12, 12),
            CreatedDate = DateTime.Now
        };

        var course2 = new Course
        {
            Title = "Math",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatibus autem corrupti quis,\r\n fugit, aliquid et optio accusantium quo maxime, quae officia iure ex dolore! Delectus modi incidunt minima accusantium ipsam?",
            StartDate = new DateTime(2024, 8, 15),
            EndDate = new DateTime(2024, 12, 12),
            CreatedDate = DateTime.Now
        };

        var course3 = new Course
        {
            Title = "Literature",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatibus autem corrupti quis,\r\n fugit, aliquid et optio accusantium quo maxime, quae officia iure ex dolore! Delectus modi incidunt minima accusantium ipsam?",
            StartDate = new DateTime(2024, 8, 15),
            EndDate = new DateTime(2024, 12, 12),
            CreatedDate = DateTime.Now
        };

        DbContext.Add(course1);
        DbContext.Add(course2);
        DbContext.Add(course3);

        DbContext.SaveChanges();
    }

}
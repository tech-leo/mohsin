using ConversationalCFO.Business.Services.QuickBooksData;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Add session services
            builder.Services.AddDistributedMemoryCache(); // Required for session storage
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120); // Set session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Load connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add DbContext with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDbContextFactory<TenantDbContext>(options =>
    options.UseSqlServer(""));
            builder.Services.AddHostedService<HourlyJobService>();

            builder.Services.AddSingleton<TenantDbContextFactory>();

            builder.Services.AddSingleton<TenantDatabaseMigrator>();
            builder.Services.AddScoped<IQuickBooksService, QuickBooksService>();
            builder.Services.AddScoped<IQuickBooksDataService, QuickBooksDataService>();
            builder.Services.AddScoped<IQuickBooksAuthService, QuickBooksAuthService>();
            builder.Services.AddScoped<IQuickBooksSyncService, QuickBooksSyncService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Ensure database is created and migrations are applied
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                try
                {
                    dbContext.Database.Migrate();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error applying migrations: {ex.Message}");
                }
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}");
            //app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}

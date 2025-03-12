using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

public class TenantDatabaseMigrator
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IDbContextFactory<TenantDbContext> _tenantDbContextFactory;

    public TenantDatabaseMigrator(IServiceScopeFactory serviceScopeFactory, IDbContextFactory<TenantDbContext> tenantDbContextFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _tenantDbContextFactory = tenantDbContextFactory;
    }

    public void MigrateTenantDatabases(string connectionstring)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            //var masterDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //var accounts = masterDbContext.Accounts.ToList();

            //foreach (var account in accounts)
            //{
            //    Console.WriteLine($"🔄 Migrating tenant database for {account.CompanyName}...");

                try
                {
                    var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
                    optionsBuilder.UseSqlServer(connectionstring);

                    using var tenantDb = new TenantDbContext(optionsBuilder.Options);
                    tenantDb.Database.Migrate();

                    //Console.WriteLine($"✅ Tenant database for {account.CompanyName} migrated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error migrating {ex.Message}");
                }
            }
        }
    }


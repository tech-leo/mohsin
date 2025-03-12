
using ConversationalCFO.Business.Services.QuickBooksData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

    public class QuickBooksAuthService : IQuickBooksAuthService
    {
    private readonly TenantDatabaseMigrator tenantMigrator;
    private readonly ApplicationDbContext applicationDbContext;
    private readonly IConfiguration Configuration;
        private readonly IQuickBooksService quickBooksService;
        private readonly IQuickBooksDataService quickBooksDataService;
    private string startdb = "Server=.;Database=";
    private string enddb = ";Integrated Security=True;TrustServerCertificate=True;";
        public QuickBooksAuthDTO QuickBooksSettings { get; }

        public QuickBooksAuthService(TenantDatabaseMigrator tenantMigrator,IQuickBooksService quickBooksService,IQuickBooksDataService quickBooksDataService,ApplicationDbContext applicationDbContext, IConfiguration configuration) 
        {
        this.tenantMigrator = tenantMigrator;
            this.applicationDbContext= applicationDbContext;
            this.Configuration = configuration;
            this.quickBooksService = quickBooksService;
            this.quickBooksDataService = quickBooksDataService;
        this.startdb = Configuration["StartDatabase"];
        this.enddb = Configuration["EndDatabase"];
            QuickBooksSettings = new QuickBooksAuthDTO { ClientId = Configuration["QuickBooks:ClientId"] ?? "", ClientSecret = Configuration["QuickBooks:ClientSecret"] ?? "", Environment = Configuration["QuickBooks:Environment"] ?? "", RedirectURL = Configuration["QuickBooks:RedirectURL"] ?? "" };
        }
        public async Task<string?> GetAuthURI()
        {
            var data= await quickBooksService.GetAuthuri(QuickBooksSettings, "cfo");
            return data;
        }
        public async Task<int> AuthorizeRequest(string code, string state, string realmid)
        {
            QuickBooksTokenPropertiesDTO? data= await quickBooksService.AuthorizeRequest(QuickBooksSettings, code, state, realmid);
            if (data != null && !string.IsNullOrEmpty(data?.AccessToken) && !string.IsNullOrEmpty(data.RefreshToken))
            {
                var company = await quickBooksDataService.GetCompanyInfoQBO(QuickBooksSettings, realmid, data.AccessToken);
                string output = Regex.Replace(company?.CompanyName, @"[^a-zA-Z0-9]", "");
            var existingAccount = applicationDbContext.Accounts.FirstOrDefault(o=> o.RealmId== data.RealmId);
            string con = startdb + output + "_DB" + enddb;
                var qbAccount = new Account
                {
                    AccessToken = data.AccessToken,
                    RefreshToken = data.RefreshToken,
                    LastSyncDate = DateTime.UtcNow,
                    ConnectionStatus = true,
                    CompanyName = company?.CompanyName ?? "",
                    RealmId = data.RealmId,
                    DatabaseConnectionString= con,
                    SyncStatus="",
                    CreatedDate = DateTime.UtcNow,
                };

                if (existingAccount != null)
                {
                    qbAccount.UpdatedDate = DateTime.UtcNow;
                    qbAccount.ConnectionStatus = true;
                    qbAccount.CompanyName = company?.CompanyName ?? "";
                    qbAccount.AccessToken = data.AccessToken;
                    qbAccount.RefreshToken = data.RefreshToken;
                      qbAccount.SyncStatus = "";
                      qbAccount.DatabaseConnectionString = con;
                    qbAccount.LastSyncDate = null;
                    applicationDbContext.Accounts.Update(qbAccount);
                    await applicationDbContext.SaveChangesAsync();
                return qbAccount.Id;
            }
            else
            {
                await applicationDbContext.Accounts.AddAsync(qbAccount);
                await applicationDbContext.SaveChangesAsync();
                tenantMigrator.MigrateTenantDatabases(con);
                return qbAccount.Id;
                }

            }
            else
            {
                return 0;
            }
        }
    }


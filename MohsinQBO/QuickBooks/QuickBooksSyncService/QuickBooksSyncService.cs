
using ConversationalCFO.Business.Services.QuickBooksData;
using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.QueryFilter;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

    public class QuickBooksSyncService : IQuickBooksSyncService
    {
    private readonly TenantDatabaseMigrator tenantMigrator;
    private readonly TenantDbContextFactory tenantDbContextFactory;
    private readonly ApplicationDbContext applicationDbContext;

    public IConfiguration Configuration { get; }
        private readonly IQuickBooksDataService quickBooksDataService;
        public QuickBooksAuthDTO QuickBooksSettings { get; }

        public QuickBooksSyncService(TenantDatabaseMigrator tenantMigrator, IQuickBooksDataService quickBooksDataService, TenantDbContextFactory tenantDbContextFactory, IConfiguration configuration,ApplicationDbContext applicationDbContext)
        {
        this.tenantMigrator= tenantMigrator;
        this.tenantDbContextFactory = tenantDbContextFactory;
            this.applicationDbContext = applicationDbContext;
            this.Configuration = configuration;
            this.quickBooksDataService = quickBooksDataService;
            QuickBooksSettings = new QuickBooksAuthDTO { ClientId = Configuration["QuickBooks:ClientId"] ?? "", ClientSecret = Configuration["QuickBooks:ClientSecret"] ?? "", Environment = Configuration["QuickBooks:Environment"] ?? "", RedirectURL = Configuration["QuickBooks:RedirectURL"] ?? "" };
        }
        private List<string?> GetQuickBooksEntityNames() => new List<string?>
            {
                "Account", "Customer", "Invoice", "Payment", "Vendor", "Class",
            "GeneralLedger","AgedPayableDetail","AgedReceivableDetail"
            };

        public async System.Threading.Tasks.Task SyncAccountEntities(int accountid)
        {
        var accounts = applicationDbContext.Accounts.Where(o => o.ConnectionStatus == true).ToList();
            if (accounts != null && accounts.Count > 0)
            {
                    var account = accounts.FirstOrDefault(p => p.Id == accountid);
                if (account.ConnectionStatus == true&&account.SyncStatus != "In Progress")
                {
                    try
                    {

                        
                        var data = await quickBooksDataService.RefreshToken(QuickBooksSettings, account.RefreshToken);
                        account.AccessToken = data.AccessToken;
                        account.RefreshToken = data.RefreshToken;
                        account.LastSyncDate = DateTime.Now;
                        account.SyncStatus = "In Progress";
                        applicationDbContext.Accounts.Update(account);
                        await applicationDbContext.SaveChangesAsync();
                    tenantMigrator.MigrateTenantDatabases(account.DatabaseConnectionString);

                    var context =tenantDbContextFactory.CreateDbContext(account.DatabaseConnectionString);
                        await SyncEntitesForAccount(account?.RealmId, account?.AccessToken, context);
                        account.SyncStatus = "Completed";
                        account.LastSyncDate = DateTime.Now;
                        applicationDbContext.Accounts.Update(account);
                        await applicationDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                    {
                        if (ex.Message == "invalid_grant")
                            account.ConnectionStatus= false;
                        account.SyncStatus = "Completed";
                        account.LastSyncDate = DateTime.Now;
                        applicationDbContext.Accounts.Update(account);
                        await applicationDbContext.SaveChangesAsync();

                }
                }
            }
        }
        public async System.Threading.Tasks.Task SyncEntities()
        {
        var accounts = applicationDbContext.Accounts.Where(o => o.ConnectionStatus == true).ToList();
            if (accounts != null && accounts.Count > 0)
            {
                foreach (var account in accounts)
                {
                    if (account.ConnectionStatus==true &&account.SyncStatus != "In Progress")
                    {
                      
                        try
                        {

                            var data = await quickBooksDataService.RefreshToken(QuickBooksSettings, account.RefreshToken);
                        account.AccessToken = data.AccessToken;
                        account.RefreshToken = data.RefreshToken;
                        account.LastSyncDate = DateTime.Now;
                        account.SyncStatus = "In Progress";
                        applicationDbContext.Accounts.Update(account);
                        await applicationDbContext.SaveChangesAsync();

                        var context = tenantDbContextFactory.CreateDbContext(account.DatabaseConnectionString);
                        await SyncEntitesForAccount(account?.RealmId, account?.AccessToken, context);

                        account.SyncStatus = "Completed";
                        account.LastSyncDate = DateTime.Now;
                        applicationDbContext.Accounts.Update(account);
                        await applicationDbContext.SaveChangesAsync();
                    }
                        catch (Exception ex)
                        {
                        if (ex.Message == "invalid_grant")
                            account.ConnectionStatus = false;
                        account.SyncStatus = "Completed";
                        account.LastSyncDate = DateTime.Now;
                        applicationDbContext.Accounts.Update(account);
                        await applicationDbContext.SaveChangesAsync();
                    }
                    }
                }
            }
        }
        private async System.Threading.Tasks.Task SyncEntitesForAccount(string realmId, string accessToken,TenantDbContext tenantDbContext)
        {
            
            var entities = GetQuickBooksEntityNames();

            List<string?> errorslogged = new List<string?>();
            foreach (var entity in entities)
            {

                int page = 1;
                int pageSize = 1000; // Adjust based on your needs
                bool hasMorePages = true;
                bool result = false;
               
                while (hasMorePages)
                {
                    try
                    {
                        var query = $"SELECT * FROM {entity} STARTPOSITION {(page - 1) * pageSize} MAXRESULTS {pageSize}";

                        switch (entity)
                        {
                            case "Account":
                                var resultacc = await GetQuickBooksEntities<Intuit.Ipp.Data.Account>(query, realmId, accessToken);
                                if (resultacc != null && resultacc.Count > 0)
                                {
                                    var list = resultacc.Where(p => p != null).Select(o => o.Id).ToList();
                                    var savedaccounts = tenantDbContext.Accounts.Where(o=> list.Contains(o.QBId));
                                    foreach (var data in resultacc)
                                    {
                                        if (data != null)
                                        {

                                        var Account = savedaccounts?.FirstOrDefault(p => p.QBId == data.Id);
                                        if (Account != null)
                                        {
                                            Account.AccountName = data.Name;
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Accounts.Update(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            Account = new AccountEntity();
                                            Account.AccountName = data.Name;
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Accounts.Add(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                    }
                                    }
                                }
                                result = resultacc?.Count == pageSize;
                                break;
                            case "Customer":
                                var resultcustomer = await GetQuickBooksEntities<Intuit.Ipp.Data.Customer>(query, realmId, accessToken);
                                if (resultcustomer != null && resultcustomer.Count > 0)
                                {
                                    var list = resultcustomer.Where(p => p != null).Select(o => o.Id).ToList();
                                    var savedcustomers = tenantDbContext.Customers.Where(o=> list.Contains(o.QBId));
                                    foreach (var data in resultcustomer)
                                    {
                                        if (data != null)
                                        {
                                        var Account = savedcustomers?.FirstOrDefault(p => p.QBId == data.Id);
                                        if (Account != null)
                                        {
                                            Account.CustomerName = data.DisplayName;
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Customers.Update(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            Account = new Customer();
                                            Account.CustomerName = data.DisplayName;
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Customers.Add(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                    }
                                    }
                                }

                                result = resultcustomer?.Count == pageSize;
                                break;
                            case "Invoice":
                                var resultinv = await GetQuickBooksEntities<Intuit.Ipp.Data.Invoice>(query, realmId, accessToken);
                                if (resultinv != null && resultinv.Count > 0)
                                {
                                    var list = resultinv.Where(p => p != null).Select(o => o.Id).ToList();
                                    var savedinvoices = tenantDbContext.Invoices.Where(o=> list.Contains(o.QBId));
                                    foreach (var data in resultinv)
                                    {
                                        if (data != null)
                                        {
                                        var Account = savedinvoices?.FirstOrDefault(p => p.QBId == data.Id);
                                        if (Account != null)
                                        {
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Invoices.Update(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            Account = new Invoice();
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Invoices.Add(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                    }
                                    }
                                }
                                result = resultinv?.Count == pageSize;
                                break;
                            case "Payment":
                                var resultpay = await GetQuickBooksEntities<Intuit.Ipp.Data.Payment>(query, realmId, accessToken);
                                if (resultpay != null && resultpay.Count > 0)
                                {
                                    var list = resultpay.Where(p => p != null).Select(o => o.Id).ToList();
                                    var savedpayments = tenantDbContext.InvoicePayments.Where(o=> list.Contains(o.QBId));
                                    foreach (var data in resultpay)
                                    {
                                        if (data != null)
                                        {
                                        var Account = savedpayments?.FirstOrDefault(p => p.QBId == data.Id);
                                        if (Account != null)
                                        {
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.InvoicePayments.Update(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            Account = new InvoicePayment();
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.InvoicePayments.Add(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                    }
                                    }
                                }
                                result = resultpay?.Count == pageSize;
                                break;
                            case "Vendor":
                                var resultven = await GetQuickBooksEntities<Intuit.Ipp.Data.Vendor>(query, realmId, accessToken);
                                if (resultven != null && resultven.Count > 0)
                                {
                                    var list = resultven.Where(p => p != null).Select(o => o.Id).ToList();
                                    var savedpayments = tenantDbContext.Vendors.Where(o=> list.Contains(o.QBId));
                                    foreach (var data in resultven)
                                    {
                                        if (data != null)
                                        {
                                        var Account = savedpayments?.FirstOrDefault(p => p.QBId == data.Id);
                                        if (Account != null)
                                        {
                                            Account.QBId = data.Id;
                                            Account.VendorName = data.DisplayName;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Vendors.Update(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            Account = new Vendor();
                                            Account.VendorName = data.DisplayName;
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Vendors.Add(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                        }
                                    }
                                }
                                result = resultven?.Count == pageSize;
                                break;
                            case "Class":
                                var resultclass = await GetQuickBooksEntities<Intuit.Ipp.Data.Class>(query, realmId, accessToken);
                                if (resultclass != null && resultclass.Count > 0)
                                {
                                    var list = resultclass.Where(p => p != null).Select(o => o.Id).ToList();
                                    var savedpayments = tenantDbContext.Classes.Where(o=> list.Contains(o.QBId));
                                    foreach (var data in resultclass)
                                    {
                                        if (data != null)
                                        {
                                        var Account = savedpayments?.FirstOrDefault(p => p.QBId == data.Id);
                                        if (Account != null)
                                        {
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Classes.Update(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            Account = new Class();
                                            Account.QBId = data.Id;
                                            Account.RawJSON = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                            tenantDbContext.Classes.Add(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                    }
                                    }
                                }
                                result = resultclass?.Count == pageSize;

                                break;
                        case "GeneralLedger":
                            var resultreport = await quickBooksDataService.GetQuickBooksReportAsync(QuickBooksSettings, accessToken, realmId,  "GeneralLedger", new Dictionary<string, string>() { 
                                {"date_macro", "All"},
                                {"columns", "tx_date,txn_type,doc_num,name,memo,split_acc,subt_nat_amount,rbal_nat_amount,debt_amt,credit_amt,cust_name,emp_name,account_name,vend_name,klass_name"},

                            });
                            if (resultreport != null )
                            {
                                var savedpayments = tenantDbContext.GeneralLedger.FirstOrDefault();
                                var data = resultreport;
                                if (data != null)
                                    {
                                        var Account = savedpayments;
                                        if (Account != null)
                                        {
                                            Account.LastUpdate = DateTime.Now;
                                            Account.RawJSON = data;
                                            tenantDbContext.GeneralLedger.Update(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            Account = new GeneralLedger();
                                            Account.LastUpdate = DateTime.Now;
                                        Account.RawJSON = data;
                                            tenantDbContext.GeneralLedger.Add(Account);
                                            await tenantDbContext.SaveChangesAsync();
                                        }
                                    JObject jsonObject = JObject.Parse(resultreport);
                                    var columns = jsonObject["Columns"];
                                    var column = columns["Column"];
                                    var rows = jsonObject["Rows"];
                                    var row = rows["Row"];
                                    List<(string, int)> si = new List<(string, int)>();
                                    if (column is JArray ordersArray)
                                    {
                                        int i = 0;
                                        foreach (JObject order in ordersArray)
                                        {
                                            si.Add((order["ColTitle"]?.ToString(), i));
                                            i++;
                                            
                                        }
                                    }
                                    var rowsdata= RowsData(si, row);
                                    if (tenantDbContext.GeneralLedgerDetail.Count() > 0)
                                    {
                                        tenantDbContext.GeneralLedgerDetail.RemoveRange(tenantDbContext.GeneralLedgerDetail.ToList());
                                    }
                                    tenantDbContext.GeneralLedgerDetail.AddRange(rowsdata);
                                    await tenantDbContext.SaveChangesAsync();
                                }

                            }
                            result = false;

                            break;

                        case "AgedPayableDetail":
                            var resultAgedPayableDetail = await quickBooksDataService.GetQuickBooksReportAsync(QuickBooksSettings, accessToken, realmId,  "AgedPayableDetail", new Dictionary<string, string>()
                            {
                                {"date_macro", "All"},

                            });
                            if (resultAgedPayableDetail != null)
                            {
                                var savedpayments = tenantDbContext.APAgingDetail.FirstOrDefault();
                                var data = resultAgedPayableDetail;
                                if (data != null)
                                {
                                    var Account = savedpayments;
                                    if (Account != null)
                                    {
                                        Account.LastUpdate = DateTime.Now;
                                        Account.RawJSON = data;
                                        tenantDbContext.APAgingDetail.Update(Account);
                                        await tenantDbContext.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        Account = new APAgingDetail();
                                        Account.LastUpdate = DateTime.Now;
                                        Account.RawJSON = data;
                                        tenantDbContext.APAgingDetail.Add(Account);
                                        await tenantDbContext.SaveChangesAsync();
                                    }
                                }

                            }
                            result = false;

                            break;
                        case "AgedReceivableDetail":
                            var resultAgedReceivableDetail = await quickBooksDataService.GetQuickBooksReportAsync(QuickBooksSettings, accessToken, realmId,  "AgedReceivableDetail", new Dictionary<string, string>() { 
                                {"date_macro", "All"},
                            });
                            if (resultAgedReceivableDetail != null)
                            {
                                var savedpayments = tenantDbContext.ARAgingDetail.FirstOrDefault();
                                var data = resultAgedReceivableDetail;
                                if (data != null)
                                {
                                    var Account = savedpayments;
                                    if (Account != null)
                                    {
                                        Account.LastUpdate = DateTime.Now;
                                        Account.RawJSON = data;
                                        tenantDbContext.ARAgingDetail.Update(Account);
                                        await tenantDbContext.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        Account = new ARAgingDetail();
                                        Account.LastUpdate = DateTime.Now;
                                        Account.RawJSON = data;
                                        tenantDbContext.ARAgingDetail.Add(Account);
                                        await tenantDbContext.SaveChangesAsync();
                                    }
                                }

                            }
                            result = false;

                            break;

                    }
                    }catch(Exception ex)
                    {
                        errorslogged.Add(ex?.Message+","+ ex.StackTrace);
                    }
                    if (result == true)
                    {
                        page++;
                    }
                    else
                    {
                        hasMorePages = false; // No more data
                    }

                }

            }

            if (errorslogged?.Count > 0)
            {
                throw new Exception(JsonConvert.SerializeObject(errorslogged));
            }
        }
        private List<GeneralLedgerDetail> RowsData(List<(string,int)> cols,JToken? row)
        {
        List < GeneralLedgerDetail > dm=new List<GeneralLedgerDetail> ();
        if (row is JArray ordersArray)
        {
            foreach (JObject order in ordersArray)
            {
                if (order["type"].ToString() == "Section")
                {
                    var rows = order["Rows"];
                    if (rows != null)
                    {
                        var rowx = rows["Row"];
                        if(rowx!= null)
                            dm.AddRange(RowsData(cols, rowx));
                    }
                }
                else if (order["type"].ToString() == "Data")
                {
                    if (order["ColData"] is JArray colsArray)
                    {
                        var indcredit = cols?.FirstOrDefault(p => p.Item1 == "Credit").Item2 ?? -1;
                        var inddebit = cols?.FirstOrDefault(p => p.Item1 == "Debit").Item2 ?? -1;
                        var indDate = cols?.FirstOrDefault(p => p.Item1 == "Date").Item2 ?? -1;
                        var indTx = cols?.FirstOrDefault(p => p.Item1 == "Transaction Type").Item2 ?? -1;
                        var indNum = cols?.FirstOrDefault(p => p.Item1 == "Num").Item2 ?? -1;
                        var indName = cols?.FirstOrDefault(p => p.Item1 == "Name").Item2 ?? -1;
                        var indCustomer = cols?.FirstOrDefault(p => p.Item1 == "Customer").Item2 ?? -1;
                        var indVendor = cols?.FirstOrDefault(p => p.Item1 == "Vendor").Item2 ?? -1;
                        var indEmployee = cols?.FirstOrDefault(p => p.Item1 == "Employee").Item2 ?? -1;
                        var indClass = cols?.FirstOrDefault(p => p.Item1 == "Class").Item2 ?? -1;
                        var indmemo = cols?.FirstOrDefault(p => p.Item1 == "Memo/Description").Item2 ?? -1;
                        var indAccount = cols?.FirstOrDefault(p => p.Item1 == "Account").Item2 ?? -1;
                        var indSplit = cols?.FirstOrDefault(p => p.Item1 == "Split").Item2 ?? -1;
                        var indAmount = cols?.FirstOrDefault(p => p.Item1 == "Amount").Item2 ?? -1;
                        var indBalance = cols?.FirstOrDefault(p => p.Item1 == "Balance").Item2 ?? -1;
                        dm.Add(new GeneralLedgerDetail
                        {
                            credit_amt = indcredit > -1 ? colsArray[indcredit]["value"]?.ToString() : null,
                            debt_amt = inddebit > -1 ? colsArray[inddebit]["value"]?.ToString() : null,
                            tx_date = indDate > -1 ? colsArray[indDate]["value"]?.ToString() : null,
                            txn_type = indTx > -1 ? colsArray[indTx]["value"]?.ToString() : null,
                            doc_num = indNum > -1 ? colsArray[indNum]["value"]?.ToString() : null,
                            name = indName > -1 ? colsArray[indName]["value"]?.ToString() : null,
                            cust_name = indCustomer > -1 ? colsArray[indCustomer]["value"]?.ToString() : null,
                            vend_name = indVendor > -1 ? colsArray[indVendor]["value"]?.ToString() : null,
                            emp_name = indEmployee > -1 ? colsArray[indEmployee]["value"]?.ToString() : null,
                            klass_name = indClass > -1 ? colsArray[indClass]["value"]?.ToString() : null,
                            memo = indmemo > -1 ? colsArray[indmemo]["value"]?.ToString() : null,
                            account_name = indAccount > -1 ? colsArray[indAccount]["value"]?.ToString() : null,
                            split_acc = indSplit > -1 ? colsArray[indSplit]["value"]?.ToString() : null,
                            subt_nat_amount = indAmount > -1 ? colsArray[indAmount]["value"]?.ToString() : null,
                            rbal_nat_amount = indBalance > -1 ? colsArray[indBalance]["value"]?.ToString() : null,
                        });
                    }

                }

            }
        }
        return dm;
    }


        // Method to fetch entities from QuickBooks
        private async Task<List<T>> GetQuickBooksEntities<T>(string query, string realmId, string accessToken) where T : class
        {


            List<T> result = new List<T>();

            try
            {

                // Create the query filter
                var data = await quickBooksDataService.GetQueryResponse<T>(QuickBooksSettings, realmId, accessToken, query);

                // Fetch the result
                foreach (var item in data.Item2)
                {
                    result.Add(item as T);
                }

            }
            catch(Exception ex) 
            {

            }
            return result;
        }

    }



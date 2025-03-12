using Intuit.Ipp.Core;
using Intuit.Ipp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intuit.Ipp.Data;
using Intuit.Ipp.OAuth2PlatformClient;
using Intuit.Ipp.ReportService;
using System.Net.Http.Headers;
namespace ConversationalCFO.Business.Services.QuickBooksData
{
    public class QuickBooksDataService:IQuickBooksDataService
    {
        private readonly IQuickBooksService quickBooksService;
        private const string QuickBooksMinorVersion = "65";

        public (DateTime time, int count) Last = new (DateTime.UtcNow,0);
        public QuickBooksDataService(IQuickBooksService quickBooksService) {
            this.quickBooksService = quickBooksService;
            this.Last= new (DateTime.UtcNow,0);
        }
        public async Task<TokenResponse?> RefreshToken(QuickBooksAuthDTO data, string refresh)
        {
            return await quickBooksService.RefreshToken(data,refresh);
        }
            /// <summary>
            /// Generic method for Add//update and Get to QBO
            /// </summary>
            /// <param name="qBAtuth"></param>
            /// <param name="props"></param>
            /// <param name="token"></param>
            /// <returns></returns>
            private ServiceContext GetServiceContext(QuickBooksAuthDTO qBAtuth, string realmid, string token)
        {
            OAuth2RequestValidator oauthValidator = new OAuth2RequestValidator(token);
            ServiceContext serviceContext = new ServiceContext(realmid, IntuitServicesType.QBO, oauthValidator);
            serviceContext.IppConfiguration.MinorVersion.Qbo = QuickBooksMinorVersion;
            serviceContext.IppConfiguration.BaseUrl.Qbo = (qBAtuth.Environment == "sandbox") ? "https://sandbox-quickbooks.api.intuit.com/" : "https://quickbooks.api.intuit.com/";
            return serviceContext;
        }
        /// <summary>
        /// Generic Implementation for Getting Query Response from QuickBooks
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="qBAtuth"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<Tuple<string, List<T>>> GetQueryResponse<T>(QuickBooksAuthDTO qBAtuth, string realmId, string token, string query)
        {

            SetCount();
            ServiceContext serviceContext = GetServiceContext(qBAtuth, realmId, token);
            Intuit.Ipp.QueryFilter.QueryService<T> CusService = new Intuit.Ipp.QueryFilter.QueryService<T>(serviceContext);
            var result = CusService.ExecuteIdsQuery(query.Replace("%20", " ")).ToList();
            
            return new Tuple<string, List<T>>(query, result);
        }
        public async Task<Report> GetReport(QuickBooksAuthDTO qBAtuth, string realmId, string token,string reportname,IDictionary<string,string> parames)
        {
            // Create ReportService Instance
            ServiceContext serviceContext = GetServiceContext(qBAtuth, realmId, token);
            ReportService reportService = new ReportService(serviceContext);
            reportService.start_date = "2024-01-01";
            reportService.end_date = "2024-12-31";

            #region Optional Parameters
            if (parames.Keys.Any(p=> p== "start_date"))
                reportService.start_date= parames["start_date"];
            if (parames.Keys.Any(p => p == "end_date"))
                reportService.end_date = parames["end_date"];
            if (parames.Keys.Any(p => p == "date_macro"))
                reportService.date_macro = parames["date_macro"];
            if (parames.Keys.Any(p => p == "customer"))
                reportService.customer = parames["customer"];
            if (parames.Keys.Any(p => p == "account"))
                reportService.account = parames["account"];
            if (parames.Keys.Any(p => p == "accounting_method"))
                reportService.accounting_method = parames["accounting_method"];
            if (parames.Keys.Any(p => p == "account_status"))
                reportService.account_status = parames["account_status"];
            if (parames.Keys.Any(p => p == "account_type"))
                reportService.account_type = parames["account_type"];
            if (parames.Keys.Any(p => p == "add_due_date"))
                reportService.add_due_date = parames["add_due_date"];
            if (parames.Keys.Any(p => p == "adjusted_gain_loss"))
                reportService.adjusted_gain_loss = parames["adjusted_gain_loss"];
            if (parames.Keys.Any(p => p == "agency_id"))
                reportService.agency_id = parames["agency_id"];
            if (parames.Keys.Any(p => p == "aging_method"))
                reportService.aging_method = parames["aging_method"];
            if (parames.Keys.Any(p => p == "aging_period"))
                reportService.aging_period = parames["aging_period"];
            if (parames.Keys.Any(p => p == "appaid"))
                reportService.appaid = parames["appaid"];
            if (parames.Keys.Any(p => p == "arpaid"))
                reportService.arpaid = parames["arpaid"];
            if (parames.Keys.Any(p => p == "attachmentType"))
                reportService.attachmentType = parames["attachmentType"];
            if (parames.Keys.Any(p => p == "bothamount"))
                reportService.bothamount = parames["bothamount"];
            if (parames.Keys.Any(p => p == "classid"))
                reportService.classid = parames["classid"];
            if (parames.Keys.Any(p => p == "columns"))
                reportService.columns = parames["columns"];
            if (parames.Keys.Any(p => p == "createdate_macro"))
                reportService.createdate_macro = parames["createdate_macro"];
            if (parames.Keys.Any(p => p == "custom1"))
                reportService.custom1 = parames["custom1"];
            if (parames.Keys.Any(p => p == "custom2"))
                reportService.custom2 = parames["custom2"];
            if (parames.Keys.Any(p => p == "custom3"))
                reportService.custom3 = parames["custom3"];
            if (parames.Keys.Any(p => p == "custom_pp"))
                reportService.custom_pp = parames["custom_pp"];
            if (parames.Keys.Any(p => p == "department"))
                reportService.department = parames["department"];
            if (parames.Keys.Any(p => p == "docnum"))
                reportService.docnum = parames["docnum"];
            if (parames.Keys.Any(p => p == "duedate_macro"))
                reportService.duedate_macro = parames["duedate_macro"];
            if (parames.Keys.Any(p => p == "end_createdate"))
                reportService.end_createdate = parames["end_createdate"];
            if (parames.Keys.Any(p => p == "end_createddate"))
                reportService.end_createddate = parames["end_createddate"];
            if (parames.Keys.Any(p => p == "end_duedate"))
                reportService.end_duedate = parames["end_duedate"];
            if (parames.Keys.Any(p => p == "end_moddate"))
                reportService.end_moddate = parames["end_moddate"];
            if (parames.Keys.Any(p => p == "groupby"))
                reportService.groupby = parames["groupby"];
            if (parames.Keys.Any(p => p == "group_by"))
                reportService.group_by = parames["group_by"];
            if (parames.Keys.Any(p => p == "high_pp_date"))
                reportService.high_pp_date = parames["high_pp_date"];
            if (parames.Keys.Any(p => p == "item"))
                reportService.item = parames["item"];
            if (parames.Keys.Any(p => p == "journal_code"))
                reportService.journal_code = parames["journal_code"];
            if (parames.Keys.Any(p => p == "low_pp_date"))
                reportService.low_pp_date = parames["low_pp_date"];
            if (parames.Keys.Any(p => p == "memo"))
                reportService.memo = parames["memo"];
            if (parames.Keys.Any(p => p == "moddate_macro"))
                reportService.moddate_macro = parames["moddate_macro"];
            if (parames.Keys.Any(p => p == "name"))
                reportService.name = parames["name"];
            if (parames.Keys.Any(p => p == "num_periods"))
                reportService.num_periods = parames["num_periods"];
            if (parames.Keys.Any(p => p == "past_due"))
                reportService.past_due = parames["past_due"];
            if (parames.Keys.Any(p => p == "payment_method"))
                reportService.payment_method = parames["payment_method"];
            if (parames.Keys.Any(p => p == "printed"))
                reportService.printed = parames["printed"];
            if (parames.Keys.Any(p => p == "qzurl"))
                reportService.qzurl = parames["qzurl"];
            if (parames.Keys.Any(p => p == "report_date"))
                reportService.report_date = parames["report_date"];
            if (parames.Keys.Any(p => p == "shipvia"))
                reportService.shipvia = parames["shipvia"];
            if (parames.Keys.Any(p => p == "showrows"))
                reportService.showrows = parames["showrows"];
            if (parames.Keys.Any(p => p == "sort_by"))
                reportService.sort_by = parames["sort_by"];
            if (parames.Keys.Any(p => p == "sort_order"))
                reportService.sort_order = parames["sort_order"];
            if (parames.Keys.Any(p => p == "source_account"))
                reportService.source_account = parames["source_account"];
            if (parames.Keys.Any(p => p == "source_account_type"))
                reportService.source_account_type = parames["source_account_type"];
            if (parames.Keys.Any(p => p == "start_createdate"))
                reportService.start_createdate = parames["start_createdate"];
            if (parames.Keys.Any(p => p == "start_createddate"))
                reportService.start_createddate = parames["start_createddate"];
            if (parames.Keys.Any(p => p == "start_duedate"))
                reportService.start_duedate = parames["start_duedate"];
            if (parames.Keys.Any(p => p == "start_moddate"))
                reportService.start_moddate = parames["start_moddate"];
            if (parames.Keys.Any(p => p == "subcol_pct_exp"))
                reportService.subcol_pct_exp = parames["subcol_pct_exp"];
            if (parames.Keys.Any(p => p == "subcol_pct_inc"))
                reportService.subcol_pct_inc = parames["subcol_pct_inc"];
            if (parames.Keys.Any(p => p == "subcol_pct_ytd"))
                reportService.subcol_pct_ytd = parames["subcol_pct_ytd"];
            if (parames.Keys.Any(p => p == "subcol_pp"))
                reportService.subcol_pp = parames["subcol_pp"];
            if (parames.Keys.Any(p => p == "subcol_pp_chg"))
                reportService.subcol_pp_chg = parames["subcol_pp_chg"];
            if (parames.Keys.Any(p => p == "subcol_pp_pct_chg"))
                reportService.subcol_pp_pct_chg = parames["subcol_pp_pct_chg"];
            if (parames.Keys.Any(p => p == "subcol_py"))
                reportService.subcol_py = parames["subcol_py"];
            if (parames.Keys.Any(p => p == "subcol_py_chg"))
                reportService.subcol_py_chg = parames["subcol_py_chg"];
            if (parames.Keys.Any(p => p == "subcol_py_pct_chg"))
                reportService.subcol_py_pct_chg = parames["subcol_py_pct_chg"];
            if (parames.Keys.Any(p => p == "subcol_ytd"))
                reportService.subcol_ytd = parames["subcol_ytd"];
            if (parames.Keys.Any(p => p == "summarize_column_by"))
                reportService.summarize_column_by = parames["summarize_column_by"];
            if (parames.Keys.Any(p => p == "term"))
                reportService.term = parames["term"];
            if (parames.Keys.Any(p => p == "transaction_type"))
                reportService.transaction_type = parames["transaction_type"];
            if (parames.Keys.Any(p => p == "vendor"))
                reportService.vendor = parames["vendor"];
            #endregion
            // Execute Report Query
            Report report = reportService.ExecuteReport(reportname);
            return report;
        }

        
        public async Task<string> GetQuickBooksReportAsync(QuickBooksAuthDTO qBAtuth,string accessToken, string realmId, string reportName, Dictionary<string, string>? queryParams = null)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var baseurl= (qBAtuth.Environment == "sandbox") ? "https://sandbox-quickbooks.api.intuit.com/" : "https://quickbooks.api.intuit.com/";
                // Base API URL
                StringBuilder urlBuilder = new StringBuilder($"{baseurl}v3/company/{realmId}/reports/{reportName}");

                // Append optional query parameters if provided
                if (queryParams != null && queryParams.Count > 0)
                {
                    urlBuilder.Append("?");
                    foreach (var param in queryParams)
                    {
                        urlBuilder.Append($"{Uri.EscapeDataString(param.Key)}={Uri.EscapeDataString(param.Value)}&");
                    }
                    urlBuilder.Length--; // Remove trailing '&'
                }

                string url = urlBuilder.ToString();

                // Set up the HTTP request
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Change to XML if needed

                // Send the request
                HttpResponseMessage response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throws exception if HTTP status code is not 2xx

                // Read the response as a string
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                return null;
            }
        }
        public async Task<CompanyInfo?> GetCompanyInfoQBO( QuickBooksAuthDTO qBAuthDTO, string realmId, string accessToken)
        {
            return (await GetQueryResponse<CompanyInfo>(qBAuthDTO, realmId , accessToken, "select * from CompanyInfo"))
                ?.Item2?.FirstOrDefault();
        }

        private void SetCount()
        {
            if (this.Last.time - DateTime.UtcNow >= TimeSpan.FromSeconds(5))
            {
                this.Last.count = 0;
            }
            else if (this.Last.count > 5)
            {
                Thread.Sleep(10000);
                this.Last.count = 0;
            }
            else
            {
                this.Last.count++;

            }
        }
    }
}

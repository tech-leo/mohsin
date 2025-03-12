using Intuit.Ipp.Data;
using Intuit.Ipp.OAuth2PlatformClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationalCFO.Business.Services.QuickBooksData
{
    public interface IQuickBooksDataService
    {
        Task<CompanyInfo?> GetCompanyInfoQBO(QuickBooksAuthDTO qBAuthDTO, string realmId, string accessToken);
        Task<Tuple<string, List<T>>> GetQueryResponse<T>(QuickBooksAuthDTO qBAtuth, string realmId, string token, string query);
        Task<string> GetQuickBooksReportAsync(QuickBooksAuthDTO qBAtuth, string accessToken, string realmId, string reportName, Dictionary<string, string>? queryParams = null);
        Task<Report> GetReport(QuickBooksAuthDTO qBAtuth, string realmId, string token, string reportname, IDictionary<string, string> parames);
        Task<TokenResponse?> RefreshToken(QuickBooksAuthDTO data, string refresh);
    }
}

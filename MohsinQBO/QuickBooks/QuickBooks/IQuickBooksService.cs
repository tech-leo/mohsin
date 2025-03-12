using Intuit.Ipp.OAuth2PlatformClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface IQuickBooksService
    {
        Task<QuickBooksTokenPropertiesDTO?> AuthorizeRequest(QuickBooksAuthDTO data, string code, string state, string realmid);
        Task<string> GetAuthuri(QuickBooksAuthDTO data, string key);
        Task<TokenResponse?> RefreshToken(QuickBooksAuthDTO data, string refresh);
        Task<TokenRevocationResponse?> RevokeTokenAsync(QuickBooksAuthDTO data, string refreshToken);
    }


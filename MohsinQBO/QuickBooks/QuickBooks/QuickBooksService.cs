using Intuit.Ipp.OAuth2PlatformClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

    public class QuickBooksService:IQuickBooksService
    {
        public QuickBooksService() { }
        public async Task<string> GetAuthuri(QuickBooksAuthDTO data, string key)
        {
            OAuth2Client oauthClient = GetQuickBooksClient(data);

            //Getting rid of SSL requirement error
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            List<OidcScopes> scopes = [OidcScopes.Accounting, OidcScopes.Payment];
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;

            string? authorizationRequest = await Task.Run(() => oauthClient.GetAuthorizationURL(scopes));
            if (oauthClient.DiscoveryDoc.IsError)
            {
                authorizationRequest = "https://appcenter.intuit.com:443/connect/oauth2" + authorizationRequest;
            }
            UriBuilder builder = new(authorizationRequest);
            string query = builder.Query;
            string[]? arr = query.Split('?')[1].Split('&');
            string? ind = arr.FirstOrDefault(o => o.Contains("state"));
            string? dummyQuery = string.Empty;
            if (ind != null)
            {
                for (int d = 0; d < arr.Length; d++)
                {
                    if (arr[d] == ind)
                    {
                        arr[d] = "state=" + key;
                    }
                    dummyQuery += arr[d] + "&";
                }
                query = dummyQuery.TrimEnd('&');
            }
            else
            {
                query += "state=" + key;
            }
            builder.Query = query;

            authorizationRequest = builder.ToString();
            return authorizationRequest;

        }
        public async Task<QuickBooksTokenPropertiesDTO?> AuthorizeRequest(QuickBooksAuthDTO data, string code, string state, string realmid)
        {
            QuickBooksTokenPropertiesDTO _data = new();
            if (state != null)
            {
                if (code != null)
                {
                    OAuth2Client oauthClient = GetQuickBooksClient(data);
                    TokenResponse? tokenResp = await oauthClient.GetBearerTokenAsync(code);
                    if (tokenResp != null)
                    {
                        _data.AccessToken = tokenResp.AccessToken;
                        _data.RealmId = realmid;
                        _data.RefreshToken = tokenResp.RefreshToken;
                        return _data;
                    }
                }
            }
            return null;
        }
        public async Task<TokenRevocationResponse?> RevokeTokenAsync(QuickBooksAuthDTO data, string refreshToken)
        {
            OAuth2Client oauthClient = GetQuickBooksClient(data);

            TokenRevocationResponse? authorizationRequest = await oauthClient.RevokeTokenAsync(refreshToken);
            return authorizationRequest;
        }

        public async Task<TokenResponse> RefreshToken(QuickBooksAuthDTO data, string refresh)
        {
            if (string.IsNullOrEmpty(refresh))
            {
                throw new Exception("invalid_request");

            }
            //Getting rid of SSL requirement error
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            OAuth2Client oauthClient = GetQuickBooksClient(data);
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            //Refresh token endpoint
            TokenResponse? tokenResp = await oauthClient.RefreshTokenAsync(refresh);
            if (tokenResp!=null && tokenResp?.IsError==true)
                throw new Exception(tokenResp.Error + ((string.IsNullOrEmpty(tokenResp.ErrorDescription)) ? string.Empty : tokenResp.ErrorDescription));
            else
                return tokenResp;


        }

        private  OAuth2Client GetQuickBooksClient(QuickBooksAuthDTO data)
        {
            return new OAuth2Client(data.ClientId, data.ClientSecret, data.RedirectURL, data.Environment);
        }
    }

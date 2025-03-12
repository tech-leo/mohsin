using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IQuickBooksAuthService
{
    Task<int> AuthorizeRequest(string code, string state, string realmid);
    Task<string?> GetAuthURI();
}


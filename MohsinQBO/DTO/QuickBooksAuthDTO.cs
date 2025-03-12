using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class QuickBooksAuthDTO
    {
        public const string QuickBooksSettings = "QuickBooksSettings";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectURL { get; set; }
        public string Environment { get; set; }
        public string DefaultEncryptKey { get; set; }
    }

    public class QuickBooksTokenPropertiesDTO
    {
        public string AccessToken { get; set; }
        public string RealmId { get; set; }
        public string RefreshToken { get; set; }
    }


using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly TenantDbContextFactory tenantDbContextFactory;

        public HomeController(TenantDbContextFactory tenantDbContextFactory, ILogger<HomeController> logger,ApplicationDbContext applicationDbContext)
        {
        this.tenantDbContextFactory = tenantDbContextFactory;
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            string loggedIn = HttpContext?.Session?.GetString("LoggedIn");
            if (string.IsNullOrEmpty(loggedIn))
            {
                return RedirectToAction("Login", "Auth");

            }
            ViewBag.Accounts = applicationDbContext.Accounts.Where(o=> o.ConnectionStatus==true).ToList();
            return View();
        }

        [Route("Details")]
        public IActionResult Details(int Id)
        {
            var account= applicationDbContext.Accounts.FirstOrDefault(o => o.Id == Id);
            if (account == null)
            {
                return RedirectToAction("Index", "Home");

            }
            var context = tenantDbContextFactory.CreateDbContext(account.DatabaseConnectionString);
            ViewBag.GeneralLedger = context.GeneralLedgerDetail.ToList();
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Accounts = context.Accounts.ToList();
            ViewBag.Classes = context.Classes.ToList();
            ViewBag.Vendors = context.Vendors.ToList();
            return View();

        }
    }
}

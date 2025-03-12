using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace WebApplication1.Controllers
{
    [Route("QuickBooks")]
    public class QuickBooksController : Controller
    {
        private readonly IQuickBooksAuthService quickBooksAuthService;
        private readonly IQuickBooksSyncService quickBooksSyncService;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public QuickBooksController(IServiceScopeFactory _serviceScopeFactory, IQuickBooksAuthService quickBooksAuthService,ApplicationDbContext applicationDbContext,IQuickBooksSyncService quickBooksSyncService)
        {
            this._serviceScopeFactory = _serviceScopeFactory;
            this.quickBooksAuthService = quickBooksAuthService;
            this.quickBooksSyncService=quickBooksSyncService;
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var authuri = await quickBooksAuthService.GetAuthURI();
            if( authuri == null ) { 
            return RedirectToAction("Index","Home");
            
            }
            return Redirect(authuri);
        }
        [HttpGet("CallBack")]
        public async Task<IActionResult> CallBack([FromQuery]DTO tO)
        {
            var accid = await quickBooksAuthService.AuthorizeRequest(tO?.code, tO?.state, tO?.realmid);
            if (accid != 0)
            {
                new Task(async () =>
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        // Resolve the scoped service
                        var scopedService = scope.ServiceProvider.GetRequiredService<IQuickBooksSyncService>();
                        await scopedService.SyncAccountEntities(accid);
                    }

                }).Start();
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("Disconnect")]
        public async Task<IActionResult> Disconnect(int Id)
        {
            var account =applicationDbContext.Accounts.FirstOrDefault(a => a.Id == Id);
            account.UpdatedDate=DateTime.Now;
            account.ConnectionStatus = false;
            applicationDbContext.Accounts.Update(account);
            await applicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet("SyncNow")]
        public async Task<IActionResult> SyncNow(int Id)
        {

                // Run the task in a new thread, handling the scoped service
                new Task(async () =>
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        // Resolve the scoped service
                        var scopedService = scope.ServiceProvider.GetRequiredService<IQuickBooksSyncService>();
                    await scopedService.SyncAccountEntities(Id);
                    }
                
                }).Start();
            
            return RedirectToAction("Index", "Home");

        }
    }
        public class DTO
    {
        public string code { get; set; }
        public string state { get; set; }
        public string realmid {  get; set; }
    }
}

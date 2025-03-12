using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IQuickBooksSyncService
{
    Task SyncAccountEntities(int accountid);
    Task SyncEntities();
}


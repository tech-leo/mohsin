using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class TenantDbContext : DbContext
{
    
    public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoicePayment> InvoicePayments { get; set; }
    public DbSet<GeneralLedger> GeneralLedger { get; set; }
    public DbSet<GeneralLedgerDetail> GeneralLedgerDetail { get; set; }
    public DbSet<APAgingDetail> APAgingDetail { get; set; }
    public DbSet<ARAgingDetail> ARAgingDetail { get; set; }
}

// Table: Classes
public class Class
{
    [Key]
    public int Id { get; set; }
    public string QBId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RawJSON { get; set; } = string.Empty;
}

// Table: Vendors
public class Vendor
{
    [Key]
    public int Id { get; set; }
    public string QBId { get; set; }
    public string VendorName { get; set; } = string.Empty;
    public string RawJSON { get; set; } = string.Empty;
}

// Table: Customers
public class Customer
{
    [Key]
    public int Id { get; set; }
    public string QBId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string RawJSON { get; set; } = string.Empty;
}

// Table: Accounts
public class AccountEntity
{
    [Key]
    public int Id { get; set; }
    public string QBId { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public string RawJSON { get; set; } = string.Empty;
}

// Table: Invoices
public class Invoice
{
    [Key]
    public int Id { get; set; }
    public string QBId { get; set; }
    public string RawJSON { get; set; } = string.Empty;
}

// Table: Invoice Payments
public class InvoicePayment
{
    [Key]
    public int Id { get; set; }
    public string QBId { get; set; }
    public string RawJSON { get; set; } = string.Empty;

}

public class GeneralLedger
{
    [Key]
    public int Id { get; set; }
    public DateTime LastUpdate { get; set; }
    public string RawJSON { get; set; } = string.Empty;

}
public class GeneralLedgerDetail
{
    [Key]
    public int Id { get; set; }
    public string tx_date { get; set; }
    public string txn_type { get; set; }
    public string doc_num { get; set; }
    public string name { get; set; }
    public string memo { get; set; }
    public string split_acc { get; set; }
    public string subt_nat_amount { get; set; }
    public string rbal_nat_amount { get; set; }
    public string debt_amt { get; set; }
    public string credit_amt { get; set; }
    public string cust_name { get; set; }
    public string emp_name { get; set; }
    public string account_name { get; set; }
    public string vend_name { get; set; }
    public string klass_name { get; set; }
    public string RawJSON { get; set; } = string.Empty;

}
public class APAgingDetail
{
    [Key]
    public int Id { get; set; }
    public DateTime LastUpdate { get; set; }
    public string RawJSON { get; set; } = string.Empty;

}

public class ARAgingDetail
{
    [Key]
    public int Id { get; set; }
    public DateTime LastUpdate { get; set; }
    public string RawJSON { get; set; } = string.Empty;

}

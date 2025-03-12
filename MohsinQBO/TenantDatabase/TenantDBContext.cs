using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class TenantDbContext : DbContext
{
    
    public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<GeneralLedgerDetail> GeneralLedgerDetail { get; set; }
    public DbSet<APAgingDetail> APAgingDetail { get; set; }
    public DbSet<ARAgingDetail> ARAgingDetail { get; set; }
}

// Table: Classes
public class Class
{
    [Key]
    public int Id { get; set; }
    public string? QBId { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? ParentRef { get; set; } = string.Empty;
}

// Table: Vendors
public class Vendor
{
    [Key]
    public int Id { get; set; }
    public string? QBId { get; set; }
    public string? VendorName { get; set; } = string.Empty;
    public string? Title { get; set; } = string.Empty;
    public string? GivenName { get; set; } = string.Empty;
    public string? MiddleName { get; set; } = string.Empty;
    public string? Suffix { get; set; } = string.Empty;
    public string? FamilyName { get; set; } = string.Empty;
    public string? PrimaryEmailAddr { get; set; } = string.Empty;
    public string? OtherContactInfo { get; set; } = string.Empty;
    public string? APAccountRef { get; set; } = string.Empty;
    public string? TermRef { get; set; } = string.Empty;
    public string? Source { get; set; } = string.Empty;
    public string? GSTIN { get; set; } = string.Empty;
    public bool? T4AEligible { get; set; } = false;
    public string? Fax { get; set; } = string.Empty;
    public string? BusinessNumber { get; set; } = string.Empty;
    public string? CurrencyRef { get; set; } = string.Empty;
    public bool? HasTPAR { get; set; } = false;
    public string? TaxReportingBasis { get; set; } = string.Empty;
    public string? Mobile { get; set; } = string.Empty;
    public string? PrimaryPhone { get; set; } = string.Empty;
    public bool? Active { get; set; } = true;
    public string? AlternatePhone { get; set; } = string.Empty;
    public string? MetaData { get; set; } = string.Empty;
    public bool? Vendor1099 { get; set; } =false;
    public decimal? CostRate { get; set; } = 0;
    public decimal? BillRate { get; set; } = 0;
    public string? WebAddr { get; set; } = string.Empty;
    public bool? T5018Eligible { get; set; } = true;
    public string? CompanyName { get; set; } = string.Empty;
    public string? VendorPaymentBankDetail { get; set; } = string.Empty;
    public string? TaxIdentifier { get; set; } = string.Empty;
    public string? AcctNum { get; set; } = string.Empty;
    public string? GSTRegistrationType { get; set; } = string.Empty;
    public string? PrintOnCheckName { get; set; } = string.Empty;
    public string? BillAddr { get; set; } = string.Empty;
    public string? ShipAddr { get; set; } = string.Empty;
    public decimal? Balance { get; set; } = 0;
}

// Table: Customers
public class Customer
{
    [Key]
    public int Id { get; set; }
    public string? QBId { get; set; }
    public string? CustomerName { get; set; } = string.Empty;
    public string? Title { get; set; } = string.Empty;
    public string? GivenName { get; set; } = string.Empty;
    public string? MiddleName { get; set; } = string.Empty;
    public string? Suffix { get; set; } = string.Empty;
    public string? FamilyName { get; set; } = string.Empty;
    public string? PrimaryEmailAddr { get; set; } = string.Empty;
    public string? ResaleNum { get; set; } = string.Empty;
    public string? SecondaryTaxIdentifier { get; set; } = string.Empty;
    public string? ARAccountRef { get; set; } = string.Empty;
    public string? DefaultTaxCodeRef { get; set; } = string.Empty;
    public string? PreferredDeliveryMethod { get; set; } = string.Empty;
    public string? GSTIN { get; set; } = string.Empty;
    public string? SalesTermRef { get; set; } = string.Empty;
    public string? CustomerTypeRef { get; set; } = string.Empty;
    public string? Fax { get; set; } = string.Empty;
    public string? BusinessNumber { get; set; } = string.Empty;
    public bool? BillWithParent { get; set; } = true;
    public string? CurrencyRef { get; set; } = string.Empty;
    public string? Mobile { get; set; } = string.Empty;
    public bool? Job { get; set; } = false;
    public decimal? BalanceWithJobs { get; set; } = 0;
    public string? PrimaryPhone { get; set; } = string.Empty;
    public DateTime? OpenBalanceDate { get; set; } 
    public bool? Taxable { get; set; } = true;
    public string? AlternatePhone { get; set; } = string.Empty;
    public string? MetaData { get; set; } = string.Empty;
    public string? ParentRef { get; set; } = string.Empty;
    public string? Notes { get; set; } = string.Empty;
    public string? WebAddr { get; set; } = string.Empty;
    public bool? Active { get; set; } = true;
    public string? CompanyName { get; set; } = string.Empty;
    public decimal? Balance { get; set; } = 0;
    public string? ShipAddr { get; set; } = string.Empty;
    public string? PaymentMethodRef { get; set; } = string.Empty;
    public bool? IsProject { get; set; } = false;
    public string? Source { get; set; } = string.Empty;
    public string? PrimaryTaxIdentifier { get; set; } = string.Empty;
    public string? GSTRegistrationType { get; set; } = string.Empty;
    public string? PrintOnCheckName { get; set; } = string.Empty;
    public string? BillAddr { get; set; } = string.Empty;
    public string? FullyQualifiedName { get; set; } = string.Empty;
    public int Level { get; set; } = 0;
    public string? TaxExemptionReasonId { get; set; } = string.Empty;
}

// Table: Accounts
public class AccountEntity
{
    [Key]
    public int Id { get; set; }
    public string? QBId { get; set; }
    public string? AccountName { get; set; } = string.Empty;
    public string? AcctNum { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public bool? Active { get; set; } = true;
    public bool? SubAccount { get; set; } = false;
    public string? ParentRef { get; set; } = string.Empty;
    public string? CurrencyRef { get; set; } = string.Empty;
    public string? MetaData { get; set; } = string.Empty;
    public string? Classification { get; set; } = string.Empty;
    public string? FullyQualifiedName { get; set; } = string.Empty;
    public string? TxnLocationType    { get; set; } = string.Empty;
    public string? AccountType { get; set; } = string.Empty;
    public decimal? CurrentBalanceWithSubAccounts { get; set; } = 0;
    public string? AccountAlias { get; set; } = string.Empty; 
    public string? TaxCodeRef { get; set; } = string.Empty; 
    public string? AccountSubType { get; set; } = string.Empty; 
    public decimal? CurrentBalance { get; set; } = 0; 
}



public class GeneralLedgerDetail
{
    [Key]
    public int Id { get; set; }
    public string? tx_date { get; set; }
    public string? txn_type { get; set; }
    public string? doc_num { get; set; }
    public string? name { get; set; }
    public string? memo { get; set; }
    public string? split_acc { get; set; }
    public string? subt_nat_amount { get; set; }
    public string? rbal_nat_amount { get; set; }
    public string? debt_amt { get; set; }
    public string? credit_amt { get; set; }
    public string? cust_name { get; set; }
    public string? emp_name { get; set; }
    public string? account_name { get; set; }
    public string? vend_name { get; set; }
    public string? klass_name { get; set; }

}
public class APAgingDetail
{
    [Key]
    public int Id { get; set; }
    public string? Vendor { get; set; } = string.Empty;
    public string? Current { get; set; } = string.Empty;
    public string? Col1 { get; set; } = string.Empty;
    public string? Col2 { get; set; } = string.Empty;
    public string? Col3 { get; set; } = string.Empty;
    public string? Col4 { get; set; } = string.Empty;
    public string? Total { get; set; } = string.Empty;

}

public class ARAgingDetail
{
    [Key]
    public int Id { get; set; }
    public string? tx_date { get; set; } = string.Empty;
    public string? txn_type { get; set; } = string.Empty;
    public string? doc_num { get; set; } = string.Empty;
    public string? cust_name { get; set; } = string.Empty;
    public string? due_date { get; set; } = string.Empty;
    public string? subt_amount { get; set; } = string.Empty;
    public string? subt_open_bal { get; set; } = string.Empty;

}

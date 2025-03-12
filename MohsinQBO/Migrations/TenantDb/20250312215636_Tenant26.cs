using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohsinQBO.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class Tenant26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RawJSON",
                table: "Vendors",
                newName: "WebAddr");

            migrationBuilder.RenameColumn(
                name: "RawJSON",
                table: "Customers",
                newName: "WebAddr");

            migrationBuilder.RenameColumn(
                name: "RawJSON",
                table: "Classes",
                newName: "ParentRef");

            migrationBuilder.RenameColumn(
                name: "RawJSON",
                table: "Accounts",
                newName: "TxnLocationType");

            migrationBuilder.AddColumn<string>(
                name: "APAccountRef",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AcctNum",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Vendors",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlternatePhone",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Vendors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillAddr",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "BillRate",
                table: "Vendors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessNumber",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CostRate",
                table: "Vendors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyRef",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GSTIN",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GSTRegistrationType",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GivenName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasTPAR",
                table: "Vendors",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaData",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherContactInfo",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryEmailAddr",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryPhone",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrintOnCheckName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipAddr",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "T4AEligible",
                table: "Vendors",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "T5018Eligible",
                table: "Vendors",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxIdentifier",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxReportingBasis",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TermRef",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Vendor1099",
                table: "Vendors",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorPaymentBankDetail",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARAccountRef",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlternatePhone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceWithJobs",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillAddr",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "BillWithParent",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyRef",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerTypeRef",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultTaxCodeRef",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullyQualifiedName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GSTIN",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GSTRegistrationType",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GivenName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsProject",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Job",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MetaData",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenBalanceDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentRef",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodRef",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredDeliveryMethod",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryEmailAddr",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryPhone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryTaxIdentifier",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrintOnCheckName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResaleNum",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SalesTermRef",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryTaxIdentifier",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipAddr",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxExemptionReasonId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Taxable",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountAlias",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountSubType",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AcctNum",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Accounts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyRef",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalance",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalanceWithSubAccounts",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullyQualifiedName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetaData",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentRef",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "SubAccount",
                table: "Accounts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCodeRef",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APAccountRef",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "AcctNum",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "AlternatePhone",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BillAddr",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BillRate",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BusinessNumber",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CostRate",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CurrencyRef",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "GSTIN",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "GSTRegistrationType",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "GivenName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "HasTPAR",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "MetaData",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "OtherContactInfo",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PrimaryEmailAddr",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PrimaryPhone",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PrintOnCheckName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ShipAddr",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Suffix",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "T4AEligible",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "T5018Eligible",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "TaxIdentifier",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "TaxReportingBasis",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "TermRef",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Vendor1099",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "VendorPaymentBankDetail",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ARAccountRef",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AlternatePhone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BalanceWithJobs",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillAddr",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillWithParent",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CurrencyRef",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerTypeRef",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DefaultTaxCodeRef",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FullyQualifiedName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GSTIN",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GSTRegistrationType",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GivenName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsProject",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MetaData",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OpenBalanceDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ParentRef",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PaymentMethodRef",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PreferredDeliveryMethod",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PrimaryEmailAddr",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PrimaryPhone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PrimaryTaxIdentifier",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PrintOnCheckName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ResaleNum",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SalesTermRef",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SecondaryTaxIdentifier",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipAddr",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Suffix",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TaxExemptionReasonId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Taxable",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountAlias",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountSubType",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AcctNum",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CurrencyRef",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CurrentBalanceWithSubAccounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "FullyQualifiedName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "MetaData",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ParentRef",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "SubAccount",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TaxCodeRef",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "WebAddr",
                table: "Vendors",
                newName: "RawJSON");

            migrationBuilder.RenameColumn(
                name: "WebAddr",
                table: "Customers",
                newName: "RawJSON");

            migrationBuilder.RenameColumn(
                name: "ParentRef",
                table: "Classes",
                newName: "RawJSON");

            migrationBuilder.RenameColumn(
                name: "TxnLocationType",
                table: "Accounts",
                newName: "RawJSON");
        }
    }
}

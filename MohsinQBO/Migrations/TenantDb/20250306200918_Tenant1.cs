using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohsinQBO.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class Tenant1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QBId",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QBId",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QBId",
                table: "InvoicePayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QBId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QBId",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QBId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QBId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "QBId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "QBId",
                table: "InvoicePayments");

            migrationBuilder.DropColumn(
                name: "QBId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "QBId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "QBId",
                table: "Accounts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohsinQBO.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class Tenant_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "txn_type",
                table: "ARAgingDetail",
                newName: "Vendor");

            migrationBuilder.RenameColumn(
                name: "tx_date",
                table: "ARAgingDetail",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "subt_open_bal",
                table: "ARAgingDetail",
                newName: "Current");

            migrationBuilder.RenameColumn(
                name: "subt_amount",
                table: "ARAgingDetail",
                newName: "Col4");

            migrationBuilder.RenameColumn(
                name: "due_date",
                table: "ARAgingDetail",
                newName: "Col3");

            migrationBuilder.RenameColumn(
                name: "doc_num",
                table: "ARAgingDetail",
                newName: "Col2");

            migrationBuilder.RenameColumn(
                name: "cust_name",
                table: "ARAgingDetail",
                newName: "Col1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vendor",
                table: "ARAgingDetail",
                newName: "txn_type");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "ARAgingDetail",
                newName: "tx_date");

            migrationBuilder.RenameColumn(
                name: "Current",
                table: "ARAgingDetail",
                newName: "subt_open_bal");

            migrationBuilder.RenameColumn(
                name: "Col4",
                table: "ARAgingDetail",
                newName: "subt_amount");

            migrationBuilder.RenameColumn(
                name: "Col3",
                table: "ARAgingDetail",
                newName: "due_date");

            migrationBuilder.RenameColumn(
                name: "Col2",
                table: "ARAgingDetail",
                newName: "doc_num");

            migrationBuilder.RenameColumn(
                name: "Col1",
                table: "ARAgingDetail",
                newName: "cust_name");
        }
    }
}

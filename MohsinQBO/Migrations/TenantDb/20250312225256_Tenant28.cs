using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohsinQBO.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class Tenant28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RawJSON",
                table: "GeneralLedgerDetail");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ARAgingDetail");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "APAgingDetail");

            migrationBuilder.RenameColumn(
                name: "RawJSON",
                table: "ARAgingDetail",
                newName: "txn_type");

            migrationBuilder.RenameColumn(
                name: "RawJSON",
                table: "APAgingDetail",
                newName: "Vendor");

            migrationBuilder.AddColumn<string>(
                name: "cust_name",
                table: "ARAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "doc_num",
                table: "ARAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "due_date",
                table: "ARAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subt_amount",
                table: "ARAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subt_open_bal",
                table: "ARAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tx_date",
                table: "ARAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Col1",
                table: "APAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Col2",
                table: "APAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Col3",
                table: "APAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Col4",
                table: "APAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Current",
                table: "APAgingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Total",
                table: "APAgingDetail",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cust_name",
                table: "ARAgingDetail");

            migrationBuilder.DropColumn(
                name: "doc_num",
                table: "ARAgingDetail");

            migrationBuilder.DropColumn(
                name: "due_date",
                table: "ARAgingDetail");

            migrationBuilder.DropColumn(
                name: "subt_amount",
                table: "ARAgingDetail");

            migrationBuilder.DropColumn(
                name: "subt_open_bal",
                table: "ARAgingDetail");

            migrationBuilder.DropColumn(
                name: "tx_date",
                table: "ARAgingDetail");

            migrationBuilder.DropColumn(
                name: "Col1",
                table: "APAgingDetail");

            migrationBuilder.DropColumn(
                name: "Col2",
                table: "APAgingDetail");

            migrationBuilder.DropColumn(
                name: "Col3",
                table: "APAgingDetail");

            migrationBuilder.DropColumn(
                name: "Col4",
                table: "APAgingDetail");

            migrationBuilder.DropColumn(
                name: "Current",
                table: "APAgingDetail");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "APAgingDetail");

            migrationBuilder.RenameColumn(
                name: "txn_type",
                table: "ARAgingDetail",
                newName: "RawJSON");

            migrationBuilder.RenameColumn(
                name: "Vendor",
                table: "APAgingDetail",
                newName: "RawJSON");

            migrationBuilder.AddColumn<string>(
                name: "RawJSON",
                table: "GeneralLedgerDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "ARAgingDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "APAgingDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

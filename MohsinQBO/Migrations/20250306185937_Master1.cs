using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohsinQBO.Migrations
{
    /// <inheritdoc />
    public partial class Master1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SyncStatus",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "Accounts");
        }
    }
}

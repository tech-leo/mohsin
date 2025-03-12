using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohsinQBO.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class Tenant23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralLedgerDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tx_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    txn_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doc_num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    split_acc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subt_nat_amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rbal_nat_amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    debt_amt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    credit_amt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vend_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    klass_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RawJSON = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedgerDetail", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralLedgerDetail");
        }
    }
}

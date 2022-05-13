using Microsoft.EntityFrameworkCore.Migrations;

namespace SISL.Infrastructure.Migrations
{
    public partial class risk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RISK",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RISK",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");
        }
    }
}

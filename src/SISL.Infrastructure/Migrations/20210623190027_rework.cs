using Microsoft.EntityFrameworkCore.Migrations;

namespace SISL.Infrastructure.Migrations
{
    public partial class rework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "REASON_FOR_REWORK",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REASON_FOR_REWORK",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SISL.Infrastructure.Migrations
{
    public partial class NOK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NOK_OTHER_NAMES",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOK_SURNAME",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NOK_OTHER_NAMES",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "NOK_SURNAME",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");
        }
    }
}

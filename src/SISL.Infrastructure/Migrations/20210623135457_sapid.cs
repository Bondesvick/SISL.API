using Microsoft.EntityFrameworkCore.Migrations;

namespace SISL.Infrastructure.Migrations
{
    public partial class sapid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LAST_UPDATED_BY",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LAST_UPDATED_BY",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SISL.Infrastructure.Migrations
{
    public partial class sapid2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LAST_UPDATED_BY",
                schema: "MISUSER",
                table: "SISL_HISTORY",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LAST_UPDATED_BY",
                schema: "MISUSER",
                table: "SISL_HISTORY");
        }
    }
}

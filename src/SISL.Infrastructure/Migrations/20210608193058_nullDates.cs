using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISL.Infrastructure.Migrations
{
    public partial class nullDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NOK_DATE_OF_BIRTH",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MEANS_OF_ID_ISSUE_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MEANS_OF_ID_EXPIRATION_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "INITIATED_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_OF_OFFICE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "APPROVED_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NOK_DATE_OF_BIRTH",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MEANS_OF_ID_ISSUE_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MEANS_OF_ID_EXPIRATION_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "INITIATED_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_OF_OFFICE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "APPROVED_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);
        }
    }
}

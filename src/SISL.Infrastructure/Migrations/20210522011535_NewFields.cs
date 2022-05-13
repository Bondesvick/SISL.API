using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISL.Infrastructure.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AVERAGE_ANNUAL_INCOME",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BVN",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATE_OF_OFFICE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EMPLOYMENT_TYPE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HOME_PHONE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ID_NUMBER",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ID_TYPE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LGA",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MARITAL_STATUS",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MEANS_OF_ID_EXPIRATION_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MEANS_OF_ID_ISSUE_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MOTHERS_MAIDEN_NAME",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOK_CONTACT_ADDRESS",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NOK_DATE_OF_BIRTH",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "TIMESTAMP(7)",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NOK_EMAIL",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOK_GENDER",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOK_NATIONALITY",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOK_PHONE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOK_RELATIONSHIP",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OCCUPATION",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OFFICE_MAIL",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OFFICE_PHONE_NUMBER",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OFFICIAL_ADDRESS",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PEP_WHO",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POLITICALLY_EXPOSED",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POLITICALLY_EXPOSED_PERSON",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POSITION_HELD",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PURPOSE_OF_INVESTMENT",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SOURCE_OF_INVESTMENT",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AVERAGE_ANNUAL_INCOME",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "BVN",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "DATE_OF_OFFICE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "EMPLOYMENT_TYPE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "HOME_PHONE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "ID_NUMBER",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "ID_TYPE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "LGA",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "MARITAL_STATUS",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "MEANS_OF_ID_EXPIRATION_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "MEANS_OF_ID_ISSUE_DATE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "MOTHERS_MAIDEN_NAME",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "NOK_CONTACT_ADDRESS",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "NOK_DATE_OF_BIRTH",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "NOK_EMAIL",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "NOK_GENDER",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "NOK_NATIONALITY",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "NOK_PHONE",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "NOK_RELATIONSHIP",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "OCCUPATION",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "OFFICE_MAIL",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "OFFICE_PHONE_NUMBER",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "OFFICIAL_ADDRESS",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "PEP_WHO",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "POLITICALLY_EXPOSED",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "POLITICALLY_EXPOSED_PERSON",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "POSITION_HELD",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "PURPOSE_OF_INVESTMENT",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "SOURCE_OF_INVESTMENT",
                schema: "MISUSER",
                table: "SISL_CUSTOMER_ACCOUNT");
        }
    }
}

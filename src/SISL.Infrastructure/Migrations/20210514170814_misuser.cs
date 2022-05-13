using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISL.Infrastructure.Migrations
{
    public partial class misuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MISUSER");

            migrationBuilder.CreateTable(
                name: "DRA_AUDIT_LOG",
                schema: "MISUSER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    ACTION_TYPE = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(1500)", maxLength: 1500, nullable: false),
                    ACTION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ACTION_BY = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRA_AUDIT_LOG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SISL_CUSTOMER_ACCOUNT",
                schema: "MISUSER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    SESSION_ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    CUSTOMER_ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    ACCOUNT_TYPE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    TITLE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    SURE_NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    FIRST_NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    OTHER_NAMES = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    COMP_NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    SEX = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PERMANENT_ADDRESS = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    NATIONALITY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    TELEPHONE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    EMAIL_ADDRESS = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    BANK_ACCOUNT_NUMBER = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    BANK_CODE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    NEXT_OF_KIN = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    BANK_NAME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    CITY = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    STATE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    COUNTRY = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    BRANCH_CODE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    STATUS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    IS_NEW_REQUEST = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SOL_ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    INITIATED_BY = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    INITIATED_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    INITIATOR_IP = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    APPROVED_BY = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    APPROVED_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    APPROVER_IP = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISL_CUSTOMER_ACCOUNT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SISL_DOCS",
                schema: "MISUSER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    FILE_NAME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    TITLE = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    CONTENT_OR_PATH = table.Column<string>(type: "CLOB", nullable: false),
                    DOCUMENT_CONTENT_TYPE = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    CUSTOMER_ACCOUNT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISL_DOCS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SISL_DOCS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ACCOUNT_ID,
                        principalSchema: "MISUSER",
                        principalTable: "SISL_CUSTOMER_ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SISL_HISTORY",
                schema: "MISUSER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    CUSTOMER_REQUEST_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    REQUEST_ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    COMMENT = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    COMMENT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    COMMENT_BY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISL_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SISL_HISTORY_ACCOUNT",
                        column: x => x.CUSTOMER_REQUEST_ID,
                        principalSchema: "MISUSER",
                        principalTable: "SISL_CUSTOMER_ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SISL_STATUS",
                schema: "MISUSER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    STATUS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    SISL_HISTORY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISL_STATUS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SISL_HISTORY_STATUS",
                        column: x => x.SISL_HISTORY_ID,
                        principalSchema: "MISUSER",
                        principalTable: "SISL_HISTORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SISL_DOCS_CUSTOMER_ACCOUNT_ID",
                schema: "MISUSER",
                table: "SISL_DOCS",
                column: "CUSTOMER_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SISL_HISTORY_CUSTOMER_REQUEST_ID",
                schema: "MISUSER",
                table: "SISL_HISTORY",
                column: "CUSTOMER_REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SISL_STATUS_SISL_HISTORY_ID",
                schema: "MISUSER",
                table: "SISL_STATUS",
                column: "SISL_HISTORY_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DRA_AUDIT_LOG",
                schema: "MISUSER");

            migrationBuilder.DropTable(
                name: "SISL_DOCS",
                schema: "MISUSER");

            migrationBuilder.DropTable(
                name: "SISL_STATUS",
                schema: "MISUSER");

            migrationBuilder.DropTable(
                name: "SISL_HISTORY",
                schema: "MISUSER");

            migrationBuilder.DropTable(
                name: "SISL_CUSTOMER_ACCOUNT",
                schema: "MISUSER");
        }
    }
}
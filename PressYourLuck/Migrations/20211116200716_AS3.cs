using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PressYourLuck.Migrations
{
    public partial class AS3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditType",
                columns: table => new
                {
                    AuditTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditType", x => x.AuditTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditTypeId = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_Audit_AuditType_AuditTypeId",
                        column: x => x.AuditTypeId,
                        principalTable: "AuditType",
                        principalColumn: "AuditTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuditType",
                columns: new[] { "AuditTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Cash In" },
                    { 2, "Cash Out" },
                    { 3, "Win" },
                    { 4, "Lose" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audit_AuditTypeId",
                table: "Audit",
                column: "AuditTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "AuditType");
        }
    }
}

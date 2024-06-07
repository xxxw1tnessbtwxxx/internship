using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Access_AccessId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AccessId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AccessId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccessId",
                table: "Employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TradePointId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Access_TradePoints_TradePointId",
                        column: x => x.TradePointId,
                        principalTable: "TradePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AccessId",
                table: "Employees",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_Access_TradePointId",
                table: "Access",
                column: "TradePointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Access_AccessId",
                table: "Employees",
                column: "AccessId",
                principalTable: "Access",
                principalColumn: "Id");
        }
    }
}

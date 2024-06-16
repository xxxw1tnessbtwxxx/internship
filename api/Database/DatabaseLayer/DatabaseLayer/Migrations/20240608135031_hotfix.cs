using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class hotfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TradePointID",
                table: "Employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TradePointID",
                table: "Employees",
                column: "TradePointID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_TradePoints_TradePointID",
                table: "Employees",
                column: "TradePointID",
                principalTable: "TradePoints",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TradePoints_TradePointID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TradePointID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TradePointID",
                table: "Employees");
        }
    }
}

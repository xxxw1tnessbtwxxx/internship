using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class hotfixx3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesess_Employees_EmployeeID",
                table: "Accesess");

            migrationBuilder.DropIndex(
                name: "IX_Accesess_EmployeeID",
                table: "Accesess");

            migrationBuilder.AddColumn<Guid>(
                name: "AccessId",
                table: "Employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AccessId",
                table: "Employees",
                column: "AccessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Accesess_AccessId",
                table: "Employees",
                column: "AccessId",
                principalTable: "Accesess",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Accesess_AccessId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AccessId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AccessId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Accesess_EmployeeID",
                table: "Accesess",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accesess_Employees_EmployeeID",
                table: "Accesess",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

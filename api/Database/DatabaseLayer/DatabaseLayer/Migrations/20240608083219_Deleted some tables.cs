using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class Deletedsometables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenedShifts");

            migrationBuilder.DropTable(
                name: "ShiftStories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpenedShifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TradePointId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeClose = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TimeOpen = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenedShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenedShifts_TradePoints_TradePointId",
                        column: x => x.TradePointId,
                        principalTable: "TradePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftStories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TradePointId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WorkStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftStories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftStories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftStories_TradePoints_TradePointId",
                        column: x => x.TradePointId,
                        principalTable: "TradePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenedShifts_TradePointId",
                table: "OpenedShifts",
                column: "TradePointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftStories_EmployeeId",
                table: "ShiftStories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftStories_TradePointId",
                table: "ShiftStories",
                column: "TradePointId");
        }
    }
}

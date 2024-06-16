using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TradePoints",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    PointName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradePoints", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    GenderID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accesess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TradePointID = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accesess_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accesess_TradePoints_TradePointID",
                        column: x => x.TradePointID,
                        principalTable: "TradePoints",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftStories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ComeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TradePointID = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftStories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShiftStories_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftStories_TradePoints_TradePointID",
                        column: x => x.TradePointID,
                        principalTable: "TradePoints",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesess_EmployeeID",
                table: "Accesess",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Accesess_TradePointID",
                table: "Accesess",
                column: "TradePointID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderID",
                table: "Employees",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftStories_EmployeeID",
                table: "ShiftStories",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftStories_TradePointID",
                table: "ShiftStories",
                column: "TradePointID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesess");

            migrationBuilder.DropTable(
                name: "ShiftStories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TradePoints");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}

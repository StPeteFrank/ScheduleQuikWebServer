using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ScheduleQuikWebServer.Migrations
{
    public partial class ShiftsTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InTime = table.Column<DateTime>(nullable: true),
                    OutTime = table.Column<DateTime>(nullable: true),
                    EmployeesTableId = table.Column<int>(nullable: false),
                    PositionsTableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Employees_EmployeesTableId",
                        column: x => x.EmployeesTableId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shifts_Positions_PositionsTableId",
                        column: x => x.PositionsTableId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_EmployeesTableId",
                table: "Shifts",
                column: "EmployeesTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_PositionsTableId",
                table: "Shifts",
                column: "PositionsTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}

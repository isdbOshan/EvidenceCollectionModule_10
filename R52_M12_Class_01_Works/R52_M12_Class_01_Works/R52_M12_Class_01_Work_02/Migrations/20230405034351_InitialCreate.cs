using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R52_M12_Class_01_Work_02.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PayRate = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "EndDate", "Name", "PayRate", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Worker 1", 1050.00m, new DateTime(2021, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, "Worker 2", 1050.00m, new DateTime(2021, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}

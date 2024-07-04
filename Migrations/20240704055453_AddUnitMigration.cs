using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "CreatedOn", "Name", "Symbol", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8618), "Piece", "PCS", new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8621) },
                    { 2L, new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8625), "Yards", "YDS", new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8625) },
                    { 3L, new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8627), "Centimeter", "CM", new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8628) },
                    { 4L, new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8629), "Milimeter", "MM", new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8630) },
                    { 5L, new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8631), "Gauss", "GS", new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8632) },
                    { 6L, new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8633), "Cone", "Cone", new DateTime(2024, 7, 4, 5, 54, 52, 337, DateTimeKind.Utc).AddTicks(8634) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}

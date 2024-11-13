using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore2.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4d3c5b93-6e15-4665-9ec3-9b7993fefd31"), "Sports" },
                    { new Guid("86e0d229-511f-41b5-90d5-347a628713e4"), "Fighting" },
                    { new Guid("8b45bc5a-76d6-42c6-a44f-2594c92f7031"), "Racing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4d3c5b93-6e15-4665-9ec3-9b7993fefd31"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("86e0d229-511f-41b5-90d5-347a628713e4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8b45bc5a-76d6-42c6-a44f-2594c92f7031"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Expect.Bookmuse.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "Id", "MaxNumberOfBooks" },
                values: new object[,]
                {
                    { new Guid("406316a4-7164-4b35-ab11-5d8bc2d4af8d"), 100 },
                    { new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"), 10 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genres", "Name", "NumberOfPages", "Price", "Publisher", "ReleaseDate", "Sells", "ShelfId", "Volume" },
                values: new object[,]
                {
                    { new Guid("2a8b311d-a5fd-4e2c-9a7c-fee27eccf869"), "Author2", new[] { 15, 1 }, "Book2", 400, 120m, "Publisher2", new DateOnly(2023, 7, 28), 0L, new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"), "tome1" },
                    { new Guid("5b96ca09-0242-45cf-9150-067fc34e7f34"), "Author4", new[] { 0, 4 }, "Book4", 800, 150m, "Publisher4", new DateOnly(2023, 7, 28), 0L, new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"), "tome1" },
                    { new Guid("716f5df8-0ae8-404b-99c2-a07ff5e188b6"), "Author5", new[] { 9, 1 }, "Book5", 250, 90m, "Publisher5", new DateOnly(2023, 7, 28), 0L, new Guid("406316a4-7164-4b35-ab11-5d8bc2d4af8d"), "tome1" },
                    { new Guid("843c82ff-02c2-4219-87bd-cfda19a31440"), "Author6", new[] { 3, 15 }, "Book6", 500, 110m, "Publisher6", new DateOnly(2023, 7, 28), 0L, new Guid("406316a4-7164-4b35-ab11-5d8bc2d4af8d"), "tome1" },
                    { new Guid("ed047556-be86-4ee9-b111-7889f7a59db9"), "Author1", new[] { 13, 12, 10 }, "Book1", 650, 100m, "Publisher1", new DateOnly(2023, 7, 28), 0L, new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"), "tome1" },
                    { new Guid("f3110eff-ba3a-421b-b23d-5e2cd642daf9"), "Author3", new[] { 25, 17 }, "Book3", 300, 80m, "Publisher3", new DateOnly(2023, 7, 28), 0L, new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"), "tome1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2a8b311d-a5fd-4e2c-9a7c-fee27eccf869"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5b96ca09-0242-45cf-9150-067fc34e7f34"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("716f5df8-0ae8-404b-99c2-a07ff5e188b6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("843c82ff-02c2-4219-87bd-cfda19a31440"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed047556-be86-4ee9-b111-7889f7a59db9"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f3110eff-ba3a-421b-b23d-5e2cd642daf9"));

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: new Guid("406316a4-7164-4b35-ab11-5d8bc2d4af8d"));

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"));
        }
    }
}

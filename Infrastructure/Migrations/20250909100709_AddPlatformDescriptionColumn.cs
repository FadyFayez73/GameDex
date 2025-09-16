using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatformDescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Platforms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("43b2427b-b32b-4a80-98c2-18b8c6f11934"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Open-source operating system based on Unix", "Linux" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("aff935b7-a122-45bf-b343-fb2b84ecfc47"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Microsoft Windows operating system", "Windows" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformID", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("4f46a6c9-1f94-4a63-9de8-2f85cbe5f05e"), "Microsoft's gaming console platform", "Xbox" },
                    { new Guid("59cfe7d1-6c6e-4d25-95b6-7c9f6b2f9245"), "Apple's operating system for Mac computers", "macOS" },
                    { new Guid("77bba20d-79f2-4a89-9f60-10cc02c0f2cf"), "Nintendo's hybrid gaming console", "Nintendo Switch" },
                    { new Guid("9af20714-09a5-4c83-9f6f-798dc91b1d02"), "Sony's gaming console platform", "PlayStation" },
                    { new Guid("b5b8efb3-7f8d-48a3-88b7-6f1a9d85f5c7"), "Apple's mobile operating system", "iOS" },
                    { new Guid("e15e8ef7-8f6b-4e71-9f51-f8658d7f84d9"), "Google's mobile operating system", "Android" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("4f46a6c9-1f94-4a63-9de8-2f85cbe5f05e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("59cfe7d1-6c6e-4d25-95b6-7c9f6b2f9245"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("77bba20d-79f2-4a89-9f60-10cc02c0f2cf"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("9af20714-09a5-4c83-9f6f-798dc91b1d02"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("b5b8efb3-7f8d-48a3-88b7-6f1a9d85f5c7"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("e15e8ef7-8f6b-4e71-9f51-f8658d7f84d9"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Platforms");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("43b2427b-b32b-4a80-98c2-18b8c6f11934"),
                column: "Name",
                value: "PlayStation 4");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformID",
                keyValue: new Guid("aff935b7-a122-45bf-b343-fb2b84ecfc47"),
                column: "Name",
                value: "PC");
        }
    }
}

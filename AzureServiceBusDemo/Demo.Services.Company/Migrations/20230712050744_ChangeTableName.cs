using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Services.CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("164a84b0-1714-4954-b6f5-482c77f8a1d9"));

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("20859284-7130-4caf-bb96-e8d586555ff5"));

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("5fca7e70-a8d3-4583-94a5-3ed2e0a06029"));

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "CompanyName", "Description", "NumberOfEmployees", "PhoneNumber", "State", "StreetAddress", "WebsiteUrl", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("5108f4f8-2089-44d9-8ad1-06c3614f3cd5"), "San Diego", "Nike", "Just Do It!", 5000, "777-448-8511", "CA", "5684 Middleton Ave", "www.nike.com", "55255" },
                    { new Guid("a6b28790-528f-416d-9061-dee0fb935e22"), "New York", "Adidas", "The Brand With 3 Stripes!", 4000, "548-358-7711", "NY", "6481 Southern Ave", "www.adidas.com", "87246" },
                    { new Guid("bb70a575-4973-4e63-bed4-7caae254364d"), "Phoenix", "ASOS", "We deliver the highest quality clothing for the lowest market price.", 1568, "214-858-4478", "AZ", "618 Eastern St", "www.asos.com", "88452" }
                });
        }
    }
}

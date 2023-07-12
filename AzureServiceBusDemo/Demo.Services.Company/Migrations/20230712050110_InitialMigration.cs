using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Services.CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

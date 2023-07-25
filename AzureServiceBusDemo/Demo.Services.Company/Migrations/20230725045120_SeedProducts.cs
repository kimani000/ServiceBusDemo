using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Services.CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CompanyId", "Description", "Name", "Price", "Style" },
                values: new object[,]
                {
                    { new Guid("1d176097-e2d3-4f5a-9989-5958d5361133"), new Guid("5108f4f8-2089-44d9-8ad1-06c3614f3cd5"), "Satin-style fabric: glossy, drapey and silky-smooth. Main: 97% Cotton, 3% Elastane.", "satin slim shorts in black", 110.0, 3 },
                    { new Guid("61777b2c-964d-4ad7-974c-dc75037e4b89"), new Guid("5108f4f8-2089-44d9-8ad1-06c3614f3cd5"), "Model's height: 188cm / 6' 2'. Model is wearing: Medium", "oversized T-shirt in beige ribbed velour", 32.0, 0 },
                    { new Guid("9135cb05-9652-4717-a4a6-81bf042fb86c"), new Guid("a6b28790-528f-416d-9061-dee0fb935e22"), "Plain-woven fabric. Main: 100% Polyester.", "Nicce renee shorts in beige", 62.0, 3 },
                    { new Guid("99d45d6a-4bb5-46f8-8e8f-f139de57e61d"), new Guid("bb70a575-4973-4e63-bed4-7caae254364d"), "Non-stretch denim: mid-blue wash. Main: 100% Cotton.", "oversized denim jacket in mid wash", 195.0, 4 },
                    { new Guid("9a637913-87c9-4741-b5f3-1b4ff7a98ad9"), new Guid("a6b28790-528f-416d-9061-dee0fb935e22"), "Corduroy: ribbed, velvet-feel texture. Lining: 100% Polyester, Rib: 99% Polyester, 1% Elastane, Shell: 91% Polyester, 9% Nylon, Wadding: 100% Polyester.", "COLLUSION cord jacket in chocolate brown", 86.900000000000006, 4 },
                    { new Guid("af9461b2-b795-4312-94e7-d770a353c961"), new Guid("bb70a575-4973-4e63-bed4-7caae254364d"), "Machine wash according to instructions on care labels", "versized t-shirt in dark khaki with back fruit print", 26.100000000000001, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CompanyId",
                table: "Product",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "City", "CompanyName", "Description", "NumberOfEmployees", "PhoneNumber", "State", "StreetAddress", "WebsiteUrl", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("164a84b0-1714-4954-b6f5-482c77f8a1d9"), "San Diego", "Nike", "Just Do It!", 5000, "777-448-8511", "CA", "5684 Middleton Ave", "www.nike.com", "55255" },
                    { new Guid("20859284-7130-4caf-bb96-e8d586555ff5"), "Phoenix", "ASOS", "We deliver the highest quality clothing for the lowest market price.", 1568, "214-858-4478", "AZ", "618 Eastern St", "www.asos.com", "88452" },
                    { new Guid("5fca7e70-a8d3-4583-94a5-3ed2e0a06029"), "New York", "Adidas", "The Brand With 3 Stripes!", 4000, "548-358-7711", "NY", "6481 Southern Ave", "www.adidas.com", "87246" }
                });
        }
    }
}

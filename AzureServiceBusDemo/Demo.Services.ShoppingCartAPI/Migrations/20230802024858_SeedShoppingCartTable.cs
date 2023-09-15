using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Services.ShoppingCartAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedShoppingCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ShoppingCart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("55bd8681-b566-4286-80a5-7763fa964c88"), new Guid("66b041a3-4ab5-4733-93d9-2c6f343ff490") },
                    { new Guid("890a05e1-e229-4126-989d-b76bd9287dbe"), new Guid("d0faab23-c93c-42dd-b455-af2c6187f3f4") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingCart",
                keyColumn: "Id",
                keyValue: new Guid("55bd8681-b566-4286-80a5-7763fa964c88"));

            migrationBuilder.DeleteData(
                table: "ShoppingCart",
                keyColumn: "Id",
                keyValue: new Guid("890a05e1-e229-4126-989d-b76bd9287dbe"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCart");
        }
    }
}

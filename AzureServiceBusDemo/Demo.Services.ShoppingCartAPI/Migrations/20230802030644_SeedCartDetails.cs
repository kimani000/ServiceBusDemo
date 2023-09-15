using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Services.ShoppingCartAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCartDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartDetailId",
                table: "ShoppingCartDetail",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "ShoppingCartDetail",
                columns: new[] { "Id", "Count", "ProductId", "ShoppingCartId" },
                values: new object[,]
                {
                    { new Guid("00a9eba0-509c-48c6-b9c9-a788eef4008f"), 1, new Guid("61777b2c-964d-4ad7-974c-dc75037e4b89"), new Guid("890a05e1-e229-4126-989d-b76bd9287dbe") },
                    { new Guid("4075409f-2fde-428f-aa8f-2c672697692c"), 4, new Guid("9a637913-87c9-4741-b5f3-1b4ff7a98ad9"), new Guid("55bd8681-b566-4286-80a5-7763fa964c88") },
                    { new Guid("70e98204-c28d-4eb3-aad5-d984202299a7"), 2, new Guid("9135cb05-9652-4717-a4a6-81bf042fb86c"), new Guid("890a05e1-e229-4126-989d-b76bd9287dbe") },
                    { new Guid("750a9e5e-693a-48df-aa65-c3fbac57d5a3"), 3, new Guid("63846c08-4514-4a7b-1213-08db8e4f008f"), new Guid("55bd8681-b566-4286-80a5-7763fa964c88") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingCartDetail",
                keyColumn: "Id",
                keyValue: new Guid("00a9eba0-509c-48c6-b9c9-a788eef4008f"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartDetail",
                keyColumn: "Id",
                keyValue: new Guid("4075409f-2fde-428f-aa8f-2c672697692c"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartDetail",
                keyColumn: "Id",
                keyValue: new Guid("70e98204-c28d-4eb3-aad5-d984202299a7"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartDetail",
                keyColumn: "Id",
                keyValue: new Guid("750a9e5e-693a-48df-aa65-c3fbac57d5a3"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingCartDetail",
                newName: "ShoppingCartDetailId");

            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("55bd8681-b566-4286-80a5-7763fa964c88"), new Guid("66b041a3-4ab5-4733-93d9-2c6f343ff490") },
                    { new Guid("890a05e1-e229-4126-989d-b76bd9287dbe"), new Guid("d0faab23-c93c-42dd-b455-af2c6187f3f4") }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sec.Market.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingAdress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerReviews",
                columns: new[] { "Id", "Comment", "CustomerEmail", "CustomerName", "ProductId" },
                values: new object[,]
                {
                    { 1, "Produit de très bonne qualitée", "jd@test.com", "John Doe", 1 },
                    { 2, "Je recommande ce produit", "ad@test.com", "Anne Doe", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreation", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8693), "Chandail pour femme, taille M", "image1.png", "Chandail femme", 10 },
                    { 2, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8698), "Polo noir homme, taille L", "image2.png", "Polo Homme noir", 20 },
                    { 3, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8701), "T-shirt noir imprimé homme", "image3.png", "T-shirt imprimé noir", 30 },
                    { 4, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8704), "T-shirt gris femme taille M", "image4.png", "T-shirt gris femme", 15 },
                    { 5, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8707), "T-shirt multicolore femme taille M", "image5.png", "T-shirt multicolore femme", 25 },
                    { 6, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8710), "T-shirt Tee Chemise Homme Treillis Bloc", "image6.png", "T-shirt Tee Chemise Homme Treillis Bloc", 35 },
                    { 7, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8713), "T-shirt blanc imprimé homme", "image7.png", "T-shirt imprimé blanc", 5 },
                    { 8, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8716), "T-shirt Tee Femme Graphic Papillon", "image8.png", "T-shirt Tee Femme Graphic Papillon", 10 },
                    { 9, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8719), "T-shirt Tee Femme Chat Graphic 3D du quotidien", "image9.png", "T-shirt Tee Femme Chat Graphic 3D du quotidien", 20 },
                    { 10, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8722), "T-shirt Tee Homme Estampage à chaud Graphic", "image10.png", "T-shirt Tee Homme Estampage à chaud Graphic", 30 },
                    { 11, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8724), "T-shirt Tee Homme Unisexe Estampage", "image11.png", "T-shirt Tee Homme Unisexe Estampage", 25 },
                    { 12, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8727), "T-shirt en tricot côtelé", "image12.png", "T-shirt en tricot côtelé", 15 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreation", "Email", "Nom", "Password", "Role", "Token" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8436), "jd@test.com", "John Doe", "123456", "Admin", "123456789" },
                    { 2, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8485), "ad@test.com", "Anne Doe", "123456", "User", "123456789" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "ExpirationDate", "Number", "Owner", "SecurityCode", "Type", "UserId" },
                values: new object[] { 1, "12/25", "6466675889085456", "John Doe", "123", "Visa", 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Price", "ProductId", "Quantity", "ShippingAdress", "UserId" },
                values: new object[] { 1, new DateTime(2022, 9, 3, 18, 9, 13, 0, DateTimeKind.Local).AddTicks(8782), 10m, 1, 1, "23r Rue Paul, Quebec, QC, G2H537", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CustomerReviews");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

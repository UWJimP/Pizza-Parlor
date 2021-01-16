using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class aspnetnewmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreEntityID = table.Column<long>(type: "bigint", nullable: false),
                    UserEntityID = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Order_Stores_StoreEntityID",
                        column: x => x.StoreEntityID,
                        principalTable: "Stores",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserEntityID",
                        column: x => x.UserEntityID,
                        principalTable: "Users",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustEntityID = table.Column<long>(type: "bigint", nullable: true),
                    SizeEntityID = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderEntityID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Pizza_Crusts_CrustEntityID",
                        column: x => x.CrustEntityID,
                        principalTable: "Crusts",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizza_Order_OrderEntityID",
                        column: x => x.OrderEntityID,
                        principalTable: "Order",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizza_Sizes_SizeEntityID",
                        column: x => x.SizeEntityID,
                        principalTable: "Sizes",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaEntityID = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Toppings_Pizza_PizzaEntityID",
                        column: x => x.PizzaEntityID,
                        principalTable: "Pizza",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "regular", 1.0 },
                    { 2L, "thin", 1.5 },
                    { 3L, "pan", 1.75 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "small", 1.0 },
                    { 2L, "medium", 2.0 },
                    { 3L, "large", 3.0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Name" },
                values: new object[,]
                {
                    { 1L, "Domino's" },
                    { 2L, "Pizza Hut" },
                    { 3L, "Papa John's" },
                    { 4L, "Generic Pizza Place" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityID", "Name" },
                values: new object[] { 1L, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreEntityID",
                table: "Order",
                column: "StoreEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserEntityID",
                table: "Order",
                column: "UserEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CrustEntityID",
                table: "Pizza",
                column: "CrustEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderEntityID",
                table: "Pizza",
                column: "OrderEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeEntityID",
                table: "Pizza",
                column: "SizeEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaEntityID",
                table: "Toppings",
                column: "PizzaEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

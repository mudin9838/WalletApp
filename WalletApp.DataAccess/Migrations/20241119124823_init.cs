using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    AuthorizedUser = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    DateDisplay = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    CardLimit = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "AuthorizedUser", "Date", "DateDisplay", "Description", "Icon", "Status", "TransactionName", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("85a54a2c-72f6-47ec-9e4d-1c76132dcdfd"), 50m, null, new DateTime(2024, 11, 17, 12, 48, 23, 757, DateTimeKind.Utc).AddTicks(2165), "2024-11-19 12:48:23", "Desc about Target", null, "Completed", "Target", "Credit", new Guid("5d5a34ff-1429-44e6-b355-af88f6917149") },
                    { new Guid("9a2c1b2f-ef6c-428c-b7a8-ea596853edb4"), 100m, null, new DateTime(2024, 11, 18, 12, 48, 23, 757, DateTimeKind.Utc).AddTicks(2172), "2024-11-19 12:48:23", "Refueling the car", null, "Pending", "Fuel", "Payment", new Guid("5d5a34ff-1429-44e6-b355-af88f6917149") },
                    { new Guid("f705611e-f346-4f5f-a4a8-ff09232b37d6"), 20m, null, new DateTime(2024, 11, 14, 12, 48, 23, 757, DateTimeKind.Utc).AddTicks(2151), "2024-11-19 12:48:23", "Desc about IKEA", null, "Completed", "IKEA", "Payment", new Guid("5d5a34ff-1429-44e6-b355-af88f6917149") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5d5a34ff-1429-44e6-b355-af88f6917149"), "John Doe" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "CardLimit", "UserId" },
                values: new object[] { new Guid("5d283f96-430a-49a7-adf9-7fcb0c275152"), 100m, 1500m, new Guid("5d5a34ff-1429-44e6-b355-af88f6917149") });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

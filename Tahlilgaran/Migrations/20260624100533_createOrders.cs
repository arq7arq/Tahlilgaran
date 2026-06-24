using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tahlilgaran.Migrations
{
    public partial class createOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Device = table.Column<string>(type: "TEXT", nullable: false),
                    Problems = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "Password",
                value: "PBKDF2-SHA256$210000$hYpMk61F5f1XqgdSHu8pKA==$xJrlKpL6tb0HUgukp0vlmhFP9iYazT+txDfsVl60kJc=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "Password",
                value: "PBKDF2-SHA256$210000$W+Avk6IhdReCnp1Pq6sZ+w==$7UmvX+XMjmhv/oIt5G3qAx6i0v7BwNPKUuPTcDlpntM=");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tahlilgaran.Migrations
{
    public partial class addPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "OrderPrices",
                columns: table => new
                {
                    OrderPriceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPrices", x => x.OrderPriceID);
                    table.ForeignKey(
                        name: "FK_OrderPrices_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "Password",
                value: "PBKDF2-SHA256$210000$IuHEN9Md9rjUuyAKy29bSg==$2JBQ8bNfNUvQEeLOv955KBDA9mt17aRkhIWCdbAqy2s=");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPrices_OrderID",
                table: "OrderPrices",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPrices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "Password",
                value: "PBKDF2-SHA256$210000$/Npa/VbNAnBaFfFf0uVT8g==$mOgQxRmFXi1uu/AH68yIlj1NXYcTbykdIn611Wumi5M=");
        }
    }
}

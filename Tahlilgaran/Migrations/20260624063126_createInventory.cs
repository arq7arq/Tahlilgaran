using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tahlilgaran.Migrations
{
    public partial class createInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "Password",
                value: "PBKDF2-SHA256$210000$W+Avk6IhdReCnp1Pq6sZ+w==$7UmvX+XMjmhv/oIt5G3qAx6i0v7BwNPKUuPTcDlpntM=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "Password",
                value: "PBKDF2-SHA256$210000$Eacy+aiNebR/YNY0V3gwNg==$ClM5SDUXnEplRrLILfTPJvKTEx7ngH04HVM1PF2fCp4=");
        }
    }
}

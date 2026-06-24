using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tahlilgaran.Migrations
{
    public partial class editAdminname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Admins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "AdminID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "AdminID");
        }
    }
}

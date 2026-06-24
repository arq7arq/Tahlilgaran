using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tahlilgaran.Migrations
{
    public partial class addadminseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminID", "Password", "Username" },
                values: new object[] { 1, "PBKDF2-SHA256$210000$Eacy+aiNebR/YNY0V3gwNg==$ClM5SDUXnEplRrLILfTPJvKTEx7ngH04HVM1PF2fCp4=", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1);
        }
    }
}

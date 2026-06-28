using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tahlilgaran.Migrations
{
    public partial class reminderDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reminder",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "Password",
                value: "PBKDF2-SHA256$210000$+6f2DNeeHyQEOlv5bqazqA==$XNrZo15j/fxd3fHox2x944oTK7pxDD37kL0VEc6fGOE=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reminder",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "Password",
                value: "PBKDF2-SHA256$210000$IuHEN9Md9rjUuyAKy29bSg==$2JBQ8bNfNUvQEeLOv955KBDA9mt17aRkhIWCdbAqy2s=");
        }
    }
}

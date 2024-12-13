using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class contacttableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OpenHours",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "Contacts",
                newName: "SenderName");

            migrationBuilder.AddColumn<string>(
                name: "ContentMessage",
                table: "Contacts",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderMail",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Contacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentMessage",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SenderMail",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "Contacts",
                newName: "TelephoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenHours",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneProjesi.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "user");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Admins");
        }
    }
}

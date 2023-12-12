using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneProjesi.Migrations
{
    /// <inheritdoc />
    public partial class deneme5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Clinics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneProjesi.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Admins_LoginAdminID",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "LoginAdminID",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Admins_LoginAdminID",
                table: "Patients",
                column: "LoginAdminID",
                principalTable: "Admins",
                principalColumn: "AdminID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Admins_LoginAdminID",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "LoginAdminID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Admins_LoginAdminID",
                table: "Patients",
                column: "LoginAdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

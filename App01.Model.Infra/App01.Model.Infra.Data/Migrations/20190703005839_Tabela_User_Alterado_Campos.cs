using Microsoft.EntityFrameworkCore.Migrations;

namespace App01.Model.Infra.Data.Migrations
{
    public partial class Tabela_User_Alterado_Campos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Username",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "User_Password",
                table: "User",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "User_Username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "User_Password");
        }
    }
}

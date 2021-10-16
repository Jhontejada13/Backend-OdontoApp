using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendOdontoApp.API.Migrations
{
    public partial class EditProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Procedures_Description",
                table: "Procedures");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Procedures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_Name",
                table: "Procedures",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Procedures_Name",
                table: "Procedures");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Procedures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_Description",
                table: "Procedures",
                column: "Description",
                unique: true);
        }
    }
}

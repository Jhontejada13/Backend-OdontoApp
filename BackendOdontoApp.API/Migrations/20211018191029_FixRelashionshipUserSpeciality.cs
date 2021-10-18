using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendOdontoApp.API.Migrations
{
    public partial class FixRelashionshipUserSpeciality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specialities_SpecialityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SpecialityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Specialities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcedureAppoinmentId",
                table: "Procedures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CancellationReasonId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DentalClinicId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcedureAppoinmentId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LaborPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureAppoinments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureAppoinments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedurePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedurePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedurePhotos_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_UserId",
                table: "Specialities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ProcedureAppoinmentId",
                table: "Procedures",
                column: "ProcedureAppoinmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CancellationReasonId",
                table: "Appointments",
                column: "CancellationReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DentalClinicId",
                table: "Appointments",
                column: "DentalClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProcedureAppoinmentId",
                table: "Appointments",
                column: "ProcedureAppoinmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProcedureId",
                table: "Details",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedurePhotos_ProcedureId",
                table: "ProcedurePhotos",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_CancellationReasons_CancellationReasonId",
                table: "Appointments",
                column: "CancellationReasonId",
                principalTable: "CancellationReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DentalClinics_DentalClinicId",
                table: "Appointments",
                column: "DentalClinicId",
                principalTable: "DentalClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ProcedureAppoinments_ProcedureAppoinmentId",
                table: "Appointments",
                column: "ProcedureAppoinmentId",
                principalTable: "ProcedureAppoinments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_ProcedureAppoinments_ProcedureAppoinmentId",
                table: "Procedures",
                column: "ProcedureAppoinmentId",
                principalTable: "ProcedureAppoinments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_AspNetUsers_UserId",
                table: "Specialities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_CancellationReasons_CancellationReasonId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DentalClinics_DentalClinicId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ProcedureAppoinments_ProcedureAppoinmentId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_ProcedureAppoinments_ProcedureAppoinmentId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_AspNetUsers_UserId",
                table: "Specialities");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "ProcedureAppoinments");

            migrationBuilder.DropTable(
                name: "ProcedurePhotos");

            migrationBuilder.DropIndex(
                name: "IX_Specialities_UserId",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_ProcedureAppoinmentId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CancellationReasonId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DentalClinicId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ProcedureAppoinmentId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "ProcedureAppoinmentId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "CancellationReasonId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DentalClinicId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ProcedureAppoinmentId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecialityId",
                table: "AspNetUsers",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specialities_SpecialityId",
                table: "AspNetUsers",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

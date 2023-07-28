using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfredHospital.DataAccess.Migrations
{
    public partial class PatientHistoryDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PhysicianId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historys_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historys_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Historys_Physicians_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Physicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historys_AppointmentId",
                table: "Historys",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Historys_PatientId",
                table: "Historys",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Historys_PhysicianId",
                table: "Historys",
                column: "PhysicianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historys");
        }
    }
}

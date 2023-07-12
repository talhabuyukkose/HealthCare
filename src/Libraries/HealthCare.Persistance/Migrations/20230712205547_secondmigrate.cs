using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class secondmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "Doctor",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DiseaseDoctor",
                columns: table => new
                {
                    DiseasesId = table.Column<int>(type: "integer", nullable: false),
                    DoctorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseDoctor", x => new { x.DiseasesId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_DiseaseDoctor_Disease_DiseasesId",
                        column: x => x.DiseasesId,
                        principalTable: "Disease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseDoctor_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalMedicalUnit",
                columns: table => new
                {
                    HospitalsId = table.Column<int>(type: "integer", nullable: false),
                    MedicalUnitsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalMedicalUnit", x => new { x.HospitalsId, x.MedicalUnitsId });
                    table.ForeignKey(
                        name: "FK_HospitalMedicalUnit_Hospital_HospitalsId",
                        column: x => x.HospitalsId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalMedicalUnit_MedicalUnit_MedicalUnitsId",
                        column: x => x.MedicalUnitsId,
                        principalTable: "MedicalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_HospitalID",
                table: "Doctor",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseDoctor_DoctorsId",
                table: "DiseaseDoctor",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalMedicalUnit_MedicalUnitsId",
                table: "HospitalMedicalUnit",
                column: "MedicalUnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Hospital_HospitalID",
                table: "Doctor",
                column: "HospitalID",
                principalTable: "Hospital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Hospital_HospitalID",
                table: "Doctor");

            migrationBuilder.DropTable(
                name: "DiseaseDoctor");

            migrationBuilder.DropTable(
                name: "HospitalMedicalUnit");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_HospitalID",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Doctor");
        }
    }
}

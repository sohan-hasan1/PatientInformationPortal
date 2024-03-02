using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatientInformationPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergiesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergiesName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergiesID);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInformation",
                columns: table => new
                {
                    DiseaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformation", x => x.DiseaseID);
                });

            migrationBuilder.CreateTable(
                name: "NCD",
                columns: table => new
                {
                    NCDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCDName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD", x => x.NCDID);
                });

            migrationBuilder.CreateTable(
                name: "PatientsInformation",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DiseaseID = table.Column<int>(type: "int", nullable: false),
                    EpilepsyStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsInformation", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_PatientsInformation_DiseaseInformation_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "DiseaseInformation",
                        principalColumn: "DiseaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies_Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    AllergiesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Allergies_Details_Allergies_AllergiesID",
                        column: x => x.AllergiesID,
                        principalTable: "Allergies",
                        principalColumn: "AllergiesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allergies_Details_PatientsInformation_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientsInformation",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NCD_Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    NCDID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NCD_Details_NCD_NCDID",
                        column: x => x.NCDID,
                        principalTable: "NCD",
                        principalColumn: "NCDID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCD_Details_PatientsInformation_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientsInformation",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "AllergiesID", "AllergiesName" },
                values: new object[,]
                {
                    { 1, "Peanuts" },
                    { 2, "Shellfish" },
                    { 3, "Fish" },
                    { 4, "Oniments" },
                    { 5, "Eggs" },
                    { 6, "Tree nuts" },
                    { 7, "Others" },
                    { 8, "No Allergies" }
                });

            migrationBuilder.InsertData(
                table: "DiseaseInformation",
                columns: new[] { "DiseaseID", "DiseaseName" },
                values: new object[,]
                {
                    { 1, "Dengue Fever" },
                    { 2, "Malaria" },
                    { 3, "Typhoid fever" },
                    { 4, "COVID-19" }
                });

            migrationBuilder.InsertData(
                table: "NCD",
                columns: new[] { "NCDID", "NCDName" },
                values: new object[,]
                {
                    { 1, "Diabetes" },
                    { 2, "Hypertension" },
                    { 3, "Obesity" },
                    { 4, "Asthma" },
                    { 5, "Heart Disease" },
                    { 6, "Cancer" },
                    { 7, "Stroke" },
                    { 8, "Chronic Kidney Disease" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_AllergiesID",
                table: "Allergies_Details",
                column: "AllergiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_PatientID",
                table: "Allergies_Details",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_NCDID",
                table: "NCD_Details",
                column: "NCDID");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_PatientID",
                table: "NCD_Details",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsInformation_DiseaseID",
                table: "PatientsInformation",
                column: "DiseaseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies_Details");

            migrationBuilder.DropTable(
                name: "NCD_Details");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "NCD");

            migrationBuilder.DropTable(
                name: "PatientsInformation");

            migrationBuilder.DropTable(
                name: "DiseaseInformation");
        }
    }
}

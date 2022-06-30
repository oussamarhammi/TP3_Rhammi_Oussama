using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class ajoutBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CertificationCenter = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvent_Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Speciality_Id = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainer_Speciality_Speciality_Id",
                        column: x => x.Speciality_Id,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingEquipment",
                columns: table => new
                {
                    Training_Id = table.Column<int>(type: "int", nullable: false),
                    Equipment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingEquipment", x => new { x.Training_Id, x.Equipment_Id });
                    table.ForeignKey(
                        name: "FK_TrainingEquipment_Equipment_Equipment_Id",
                        column: x => x.Equipment_Id,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingEquipment_Training_Training_Id",
                        column: x => x.Training_Id,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartWeight = table.Column<double>(type: "float", nullable: true),
                    Trainer_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Trainer_Trainer_Id",
                        column: x => x.Trainer_Id,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCertification",
                columns: table => new
                {
                    Trainer_Id = table.Column<int>(type: "int", nullable: false),
                    Certification_Id = table.Column<int>(type: "int", nullable: false),
                    DateCertification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCertification", x => new { x.Trainer_Id, x.Certification_Id });
                    table.ForeignKey(
                        name: "FK_TrainerCertification_Certifications_Certification_Id",
                        column: x => x.Certification_Id,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerCertification_Trainer_Trainer_Id",
                        column: x => x.Trainer_Id,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LostWeight = table.Column<double>(type: "float", nullable: true),
                    DistanceKm = table.Column<double>(type: "float", nullable: true),
                    AchievedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objective_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMin = table.Column<int>(type: "int", nullable: false),
                    WithTrainer = table.Column<bool>(type: "bit", nullable: true),
                    Complete = table.Column<bool>(type: "bit", nullable: true),
                    Training_Id = table.Column<int>(type: "int", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledSession_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduledSession_Training_Training_Id",
                        column: x => x.Training_Id,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Compétition" },
                    { 2, "Certification" },
                    { 3, "Levée de fonds" }
                });

            migrationBuilder.InsertData(
                table: "Certifications",
                columns: new[] { "Id", "CertificationCenter", "Title" },
                values: new object[,]
                {
                    { 1, null, "Niveau Bronze" },
                    { 2, null, "Niveau Argent" },
                    { 3, null, "Niveau Or" },
                    { 4, null, "Niveau Élite" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Ballon d'exercice" },
                    { 7, "Elastiques" },
                    { 5, "Ensemble barre altère" },
                    { 6, "Bloc yoga" },
                    { 3, "Tapis" },
                    { 2, "Ensemble dumbels" },
                    { 1, "Vélo" },
                    { 4, "Step" }
                });

            migrationBuilder.InsertData(
                table: "Speciality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Perte de poids" },
                    { 2, "Course" },
                    { 3, "Althérophilie" },
                    { 4, "Réhabilitation" }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 6, "Musculaire", "Spinning" },
                    { 1, "Cardio", "Step" },
                    { 2, "Étirement", "Yoga" },
                    { 3, "Musculaire", "CrossFit" },
                    { 4, "Cardio", "Course" },
                    { 5, "Cardio", "Zumba" },
                    { 7, "Étirement", "Taichi" }
                });

            migrationBuilder.InsertData(
                table: "CalendarEvent",
                columns: new[] { "Id", "Category_Id", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deux semaines sous le soleil des Bahamas avec 2 entrainements de CrossFit par jour et accès à toutes les activités du site.", "Cross Fit  Bahamas" },
                    { 4, 1, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Épreuve  sportive constituée de trois épreuves d'endurance enchaînées dans l'ordre suivant : natation, cyclisme et course à pied.", "Triathlon" },
                    { 1, 2, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Évaluation sur plusieurs angles vous permettant d'atteindre le niveau bronze dans la joie et le bonheur.", "Niveau Bronze" },
                    { 5, 2, new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Évaluation sur plusieurs angles vous permettant d'atteindre le niveau argent dans la joie et le bonheur. Vous devez avoir le niveau bronze pour participer.", "Niveau Argent" },
                    { 3, 3, new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amusez-vous tout en ramassant des fonds pour une bonne cause: 3 heures de zumba avec nos entraineurs et des invités surprises.", "Zumba-Thon" }
                });

            migrationBuilder.InsertData(
                table: "Trainer",
                columns: new[] { "Id", "Active", "Biography", "Email", "FirstName", "LastName", "Photo", "Speciality_Id" },
                values: new object[,]
                {
                    { 4, true, null, "JC.Bastien@juliepro.ca", "Jean-Claude", "Bastien", "d7bcc6d9-0599-42aa-8305-3c1ae5a4505c.png", 4 },
                    { 5, true, null, "JinLee.godette@juliepro.ca", "Jin Lee", "Godette", "E3Rcc6d9-0599-42aa-8305-3c1ae5a4512v.png", 3 },
                    { 6, true, null, "Karine.Lachance@juliepro.ca", "Karine", "Lachance", "b333bae3-e6bb-40f0-84cf-e4b11627ba1c.png", 2 },
                    { 7, false, null, "Ramone.Esteban@juliepro.ca", "Ramone", "Esteban", "waqd9532-1395-42a2-8ae6-56f0e2ab49e9.png", 3 },
                    { 3, false, null, "Frank.StJohn@juliepro.ca", "François", "Saint-John", "aedd9532-1395-42a2-8ae6-56f0e2ab49b5.png", 1 },
                    { 1, true, null, "Chrystal.lapierre@juliepro.ca", "Chrysal", "Lappierre", "8624af64-2685-459a-a1cc-816c0695d760.png", 1 },
                    { 2, true, null, "Felix.trudeau@juliePro.ca", "Félix", "Trudeau", "a202bae3-e6bb-40f0-84cf-e4b11627ba1c.png", 2 }
                });

            migrationBuilder.InsertData(
                table: "TrainingEquipment",
                columns: new[] { "Equipment_Id", "Training_Id" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 4, 1 },
                    { 7, 1 },
                    { 3, 2 },
                    { 6, 2 },
                    { 8, 2 },
                    { 2, 3 },
                    { 5, 3 },
                    { 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "Photo", "StartWeight", "Trainer_Id" },
                values: new object[,]
                {
                    { 4, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "berthaLaroche@gmail.com", "Bertha", "Laroche", "", null, 1 },
                    { 1, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "arthurLaroche@gmail.com", "Arthur", "Laroche", "", null, 3 },
                    { 3, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "fredcaillou@gmail.com", "Fred", "Caillou", "", null, 3 },
                    { 2, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "DelimaCaillou@gmail.com", "Délima", "Caillou", "", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Objective",
                columns: new[] { "Id", "AchievedDate", "Customer_Id", "DistanceKm", "LostWeight", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 5.0, "" },
                    { 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 5.0, "" },
                    { 3, null, 1, 0.0, 5.0, "" },
                    { 4, new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.0, 10.0, "" },
                    { 5, null, 2, 0.0, 5.0, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_Category_Id",
                table: "CalendarEvent",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Trainer_Id",
                table: "Customer",
                column: "Trainer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_Customer_Id",
                table: "Objective",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSession_Customer_Id",
                table: "ScheduledSession",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSession_Training_Id",
                table: "ScheduledSession",
                column: "Training_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_Speciality_Id",
                table: "Trainer",
                column: "Speciality_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCertification_Certification_Id",
                table: "TrainerCertification",
                column: "Certification_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingEquipment_Equipment_Id",
                table: "TrainingEquipment",
                column: "Equipment_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarEvent");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "ScheduledSession");

            migrationBuilder.DropTable(
                name: "TrainerCertification");

            migrationBuilder.DropTable(
                name: "TrainingEquipment");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "Speciality");
        }
    }
}

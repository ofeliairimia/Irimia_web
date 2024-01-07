using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irimia_web.Migrations
{
    public partial class migrare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Localitate = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specialitate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeSpecialitate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialitate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titlu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MedicID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    OrarID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serviciu_Medic_MedicID",
                        column: x => x.MedicID,
                        principalTable: "Medic",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviciu_Orar_OrarID",
                        column: x => x.OrarID,
                        principalTable: "Orar",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientID = table.Column<int>(type: "int", nullable: true),
                    ServiciuID = table.Column<int>(type: "int", nullable: true),
                    DataProgramare = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programare_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SpecialitateServiciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiciuID = table.Column<int>(type: "int", nullable: false),
                    SpecialitateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialitateServiciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpecialitateServiciu_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialitateServiciu_Specialitate_SpecialitateID",
                        column: x => x.SpecialitateID,
                        principalTable: "Specialitate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_PacientID",
                table: "Programare",
                column: "PacientID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ServiciuID",
                table: "Programare",
                column: "ServiciuID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_MedicID",
                table: "Serviciu",
                column: "MedicID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_OrarID",
                table: "Serviciu",
                column: "OrarID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialitateServiciu_ServiciuID",
                table: "SpecialitateServiciu",
                column: "ServiciuID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialitateServiciu_SpecialitateID",
                table: "SpecialitateServiciu",
                column: "SpecialitateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "SpecialitateServiciu");

            migrationBuilder.DropTable(
                name: "Pacient");

            migrationBuilder.DropTable(
                name: "Serviciu");

            migrationBuilder.DropTable(
                name: "Specialitate");

            migrationBuilder.DropTable(
                name: "Medic");

            migrationBuilder.DropTable(
                name: "Orar");
        }
    }
}

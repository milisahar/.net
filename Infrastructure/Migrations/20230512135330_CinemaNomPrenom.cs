using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CinemaNomPrenom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.CinemaId);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duree = table.Column<double>(type: "float", nullable: false),
                    DateRealisation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    TypeFilm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    IdSalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    NbPlaces = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.IdSalle);
                    table.ForeignKey(
                        name: "FK_Salle_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "CinemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projection",
                columns: table => new
                {
                    DateProjection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmFk = table.Column<int>(type: "int", nullable: false),
                    SalleFk = table.Column<int>(type: "int", nullable: false),
                    TypeProjection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MySalleIdSalle = table.Column<int>(type: "int", nullable: false),
                    MyFilmFilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projection", x => new { x.FilmFk, x.SalleFk, x.DateProjection });
                    table.ForeignKey(
                        name: "FK_Projection_Film_MyFilmFilmId",
                        column: x => x.MyFilmFilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projection_Salle_MySalleIdSalle",
                        column: x => x.MySalleIdSalle,
                        principalTable: "Salle",
                        principalColumn: "IdSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projection_MyFilmFilmId",
                table: "Projection",
                column: "MyFilmFilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Projection_MySalleIdSalle",
                table: "Projection",
                column: "MySalleIdSalle");

            migrationBuilder.CreateIndex(
                name: "IX_Salle_CinemaId",
                table: "Salle",
                column: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projection");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Salle");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}

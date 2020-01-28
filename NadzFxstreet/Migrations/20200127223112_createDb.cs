using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NadzFxstreet.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    YellowCards = table.Column<int>(nullable: false),
                    RedCards = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    YellowCards = table.Column<int>(nullable: false),
                    RedCards = table.Column<int>(nullable: false),
                    MinutesPlayed = table.Column<int>(nullable: false),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refrees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MinutesPlayed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    HouseTeamManagerId = table.Column<int>(nullable: true),
                    AwayTeamManagerId = table.Column<int>(nullable: true),
                    RefereeId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Managers_AwayTeamManagerId",
                        column: x => x.AwayTeamManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Managers_HouseTeamManagerId",
                        column: x => x.HouseTeamManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Refrees_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Refrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersOfMatch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlayerId = table.Column<int>(nullable: true),
                    Home = table.Column<bool>(nullable: false),
                    MatchId = table.Column<int>(nullable: true),
                    MatchId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersOfMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersOfMatch_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersOfMatch_Matches_MatchId1",
                        column: x => x.MatchId1,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersOfMatch_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamManagerId",
                table: "Matches",
                column: "AwayTeamManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HouseTeamManagerId",
                table: "Matches",
                column: "HouseTeamManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeId",
                table: "Matches",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersOfMatch_MatchId",
                table: "PlayersOfMatch",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersOfMatch_MatchId1",
                table: "PlayersOfMatch",
                column: "MatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersOfMatch_PlayerId",
                table: "PlayersOfMatch",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersOfMatch");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Refrees");
        }
    }
}

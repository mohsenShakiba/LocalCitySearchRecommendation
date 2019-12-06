using Microsoft.EntityFrameworkCore.Migrations;

namespace LCSR.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceCityId = table.Column<long>(nullable: false),
                    DestinationCityId = table.Column<long>(nullable: false),
                    CityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_history_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_history_cities_DestinationCityId",
                        column: x => x.DestinationCityId,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_history_cities_SourceCityId",
                        column: x => x.SourceCityId,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_history_CityId",
                table: "history",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_history_DestinationCityId",
                table: "history",
                column: "DestinationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_history_SourceCityId",
                table: "history",
                column: "SourceCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}

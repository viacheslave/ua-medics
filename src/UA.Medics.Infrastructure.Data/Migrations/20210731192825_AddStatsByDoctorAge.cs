using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UA.Medics.Infrastructure.Data.Migrations
{
    public partial class AddStatsByDoctorAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatsByDoctorAge",
                columns: table => new
                {
                    StatsDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LegalEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartyTempId = table.Column<int>(type: "integer", nullable: false),
                    PersonAgeGroup = table.Column<string>(type: "text", nullable: false),
                    CountDeclarations = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsByDoctorAge", x => new { x.StatsDate, x.LegalEntityId, x.PartyTempId, x.PersonAgeGroup });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatsByDoctorAge");
        }
    }
}

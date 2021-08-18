using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UA.Medics.Infrastructure.Data.Migrations
{
    public partial class AddDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    LegalEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartyTempId = table.Column<int>(type: "integer", nullable: false),
                    LegalEntityDivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeSpeciality = table.Column<string>(type: "text", nullable: true),
                    PartyName = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => new { x.PartyTempId, x.LegalEntityId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}

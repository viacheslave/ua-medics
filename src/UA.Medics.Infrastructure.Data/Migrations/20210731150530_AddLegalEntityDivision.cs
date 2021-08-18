using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UA.Medics.Infrastructure.Data.Migrations
{
    public partial class AddLegalEntityDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Lng",
                table: "LegalEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Lat",
                table: "LegalEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "LegalEntityDivision",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LegalEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ResidenceArea = table.Column<string>(type: "text", nullable: true),
                    ResidenceRegion = table.Column<string>(type: "text", nullable: true),
                    ResidenceSettlement = table.Column<string>(type: "text", nullable: true),
                    ResidenceSettlementType = table.Column<string>(type: "text", nullable: true),
                    ResidenceAddresses = table.Column<string>(type: "text", nullable: true),
                    ResidenceSettlementKoatuu = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Lat = table.Column<string>(type: "text", nullable: true),
                    Lng = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntityDivision", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalEntityDivision");

            migrationBuilder.AlterColumn<string>(
                name: "Lng",
                table: "LegalEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lat",
                table: "LegalEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}

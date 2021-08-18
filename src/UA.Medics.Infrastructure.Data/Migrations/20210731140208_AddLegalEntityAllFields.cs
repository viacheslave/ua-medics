using Microsoft.EntityFrameworkCore.Migrations;

namespace UA.Medics.Infrastructure.Data.Migrations
{
    public partial class AddLegalEntityAllFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CareType",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Edrpou",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lng",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyType",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationAddresses",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationArea",
                table: "LegalEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationSettlement",
                table: "LegalEntity",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareType",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "Edrpou",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "RegistrationAddresses",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "RegistrationArea",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "RegistrationSettlement",
                table: "LegalEntity");
        }
    }
}

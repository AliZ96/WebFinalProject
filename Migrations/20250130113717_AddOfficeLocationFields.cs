using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class AddOfficeLocationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Offices",
                newName: "Address");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Offices",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Offices",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Offices");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Offices",
                newName: "City");
        }
    }
}

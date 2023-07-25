using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fungoodMVC.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddBonusToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bonus",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CumulativeConsumption",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bonus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CumulativeConsumption",
                table: "AspNetUsers");
        }
    }
}

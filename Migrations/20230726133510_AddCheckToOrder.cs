using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fungoodMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Check",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Check",
                table: "orders");
        }
    }
}

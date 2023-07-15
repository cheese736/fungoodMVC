using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fungoodMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderNumberToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumer",
                table: "tables",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderNumer",
                value: null);

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderNumer",
                value: null);

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderNumer",
                value: null);

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderNumer",
                value: null);

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderNumer",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumer",
                table: "tables");
        }
    }
}

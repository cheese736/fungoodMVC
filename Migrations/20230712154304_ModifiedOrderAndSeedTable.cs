using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fungoodMVC.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedOrderAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_table",
                table: "table");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "table",
                newName: "tables");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "tables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tables",
                table: "tables",
                column: "Id");

            migrationBuilder.InsertData(
                table: "tables",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, null },
                    { 2, null },
                    { 3, null },
                    { 4, null },
                    { 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_TableId",
                table: "orders",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_tables_TableId",
                table: "orders",
                column: "TableId",
                principalTable: "tables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_tables_TableId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_TableId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tables",
                table: "tables");

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "tables",
                newName: "table");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "table",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_table",
                table: "table",
                column: "Id");
        }
    }
}

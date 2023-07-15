using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fungoodMVC.Migrations
{
    /// <inheritdoc />
    public partial class AutoGenerateTimeStampsForOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_tables_TableId",
                table: "orders");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "orders",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inserted",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "orders",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldRowVersion: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inserted",
                table: "orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_tables_TableId",
                table: "orders",
                column: "TableId",
                principalTable: "tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

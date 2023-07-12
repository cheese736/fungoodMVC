using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fungoodMVC.Migrations
{
    /// <inheritdoc />
    public partial class addOrderFoodItemrelationship : Migration
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_FoodItemId",
                table: "orders",
                column: "FoodItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_food_items_FoodItemId",
                table: "orders",
                column: "FoodItemId",
                principalTable: "food_items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_tables_TableId",
                table: "orders",
                column: "TableId",
                principalTable: "tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_food_items_FoodItemId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_tables_TableId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_FoodItemId",
                table: "orders");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_tables_TableId",
                table: "orders",
                column: "TableId",
                principalTable: "tables",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fungoodMVC.Migrations
{
    /// <inheritdoc />
    public partial class addFoodItemCategoryrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.RenameTable(
                name: "Table",
                newName: "table");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_table",
                table: "table",
                column: "Id");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "飯" },
                    { 2, "麵" },
                    { 3, "私房拿手菜" },
                    { 4, "小菜" },
                    { 5, "湯" }
                });

            migrationBuilder.InsertData(
                table: "food_items",
                columns: new[] { "Id", "CategoryId", "HasSpiciness", "ImageSrc", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, true, "~/images/FoodItem/炒飯.jpg", "蒜味香腸炒飯", 80 },
                    { 2, 2, true, "~/images/FoodItem/刀削麵.jpg", "沙茶牛炒刀削麵", 120 },
                    { 3, 3, true, "~/images/FoodItem/獅子頭.jpg", "香蔥獅子頭", 200 },
                    { 4, 4, false, "~/images/FoodItem/小黃瓜.png", "涼拌小黃瓜", 40 },
                    { 5, 5, false, "~/images/FoodItem/人蔘雞湯.jpg", "枸杞人蔘雞湯", 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_food_items_CategoryId",
                table: "food_items",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_food_items_categories_CategoryId",
                table: "food_items",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_food_items_categories_CategoryId",
                table: "food_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_table",
                table: "table");

            migrationBuilder.DropIndex(
                name: "IX_food_items_CategoryId",
                table: "food_items");

            migrationBuilder.DeleteData(
                table: "food_items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "food_items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "food_items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "food_items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "food_items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "table",
                newName: "Table");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "Id");
        }
    }
}

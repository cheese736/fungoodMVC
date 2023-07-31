using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fungoodMVC.Migrations
{
    /// <inheritdoc />
    public partial class ReSeedFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fungoodMVC.Migrations
{
	/// <inheritdoc />
	public partial class adjustmodels : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "HasSpiciness",
				table: "food_items",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<string>(
				name: "ImageSrc",
				table: "food_items",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<DateTime>(
				name: "Inserted",
				table: "food_items",
				type: "datetime2",
				nullable: false,
				defaultValueSql: "GETDATE()");

			migrationBuilder.AddColumn<DateTime>(
				name: "LastUpdated",
				table: "food_items",
				type: "datetime2",
				rowVersion: true,
				nullable: false,
				defaultValueSql: "GETDATE()");

			migrationBuilder.CreateTable(
				name: "categories",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_categories", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "orders",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					OrderNumber = table.Column<int>(type: "int", nullable: false),
					TableNumber = table.Column<int>(type: "int", nullable: false),
					FoodItemId = table.Column<int>(type: "int", nullable: false),
					UserId = table.Column<int>(type: "int", nullable: false),
					Spiciness = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Inserted = table.Column<DateTime>(type: "datetime2", nullable: false),
					LastUpdated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_orders", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "table",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Table", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "users",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
					PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
					PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
					Rewards = table.Column<int>(type: "int", nullable: false),
					Inserted = table.Column<DateTime>(type: "datetime2", nullable: false),
					LastUpdated = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_users", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "categories");

			migrationBuilder.DropTable(
				name: "orders");

			migrationBuilder.DropTable(
				name: "Table");

			migrationBuilder.DropTable(
				name: "users");

			migrationBuilder.DropColumn(
				name: "HasSpiciness",
				table: "food_items");

			migrationBuilder.DropColumn(
				name: "ImageSrc",
				table: "food_items");

			migrationBuilder.DropColumn(
				name: "Inserted",
				table: "food_items");

			migrationBuilder.DropColumn(
				name: "LastUpdated",
				table: "food_items");
		}
	}
}

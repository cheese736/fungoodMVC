using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace fungoodMVC.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> option) : base(option)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<FoodItem>()
			.Property(e => e.Inserted)
			.HasDefaultValueSql("GETDATE()");

			builder.Entity<FoodItem>()
			.Property(e => e.LastUpdated)
			.HasDefaultValueSql("GETDATE()")
			.ValueGeneratedOnAddOrUpdate();

			builder.Entity<Order>()
			.Property(e => e.Spiciness)
			.HasConversion<string>();

			builder.Entity<Table>()
	  .Property(e => e.Status)
	  .HasConversion<string>();

			builder.Entity<FoodItem>()
			.HasData(
			  new FoodItem { Id = 1, Name = "蒜味香腸炒飯", Price = 80, CategoryId = 1, ImageSrc = "~/images/FoodItem/炒飯.jpg", HasSpiciness = true },
			  new FoodItem { Id = 2, Name = "沙茶牛炒刀削麵", Price = 120, CategoryId = 2, ImageSrc = "~/images/FoodItem/刀削麵.jpg", HasSpiciness = true },
			  new FoodItem { Id = 3, Name = "香蔥獅子頭", Price = 200, CategoryId = 3, ImageSrc = "~/images/FoodItem/獅子頭.jpg", HasSpiciness = true },
			  new FoodItem { Id = 4, Name = "涼拌小黃瓜", Price = 40, CategoryId = 4, ImageSrc = "~/images/FoodItem/小黃瓜.png", HasSpiciness = false },
			  new FoodItem { Id = 5, Name = "枸杞人蔘雞湯", Price = 150, CategoryId = 5, ImageSrc = "~/images/FoodItem/人蔘雞湯.jpg", HasSpiciness = false }
			);

			builder.Entity<Category>()
			.HasData(
			  new Category { Id = 1, Name = "飯" },
			  new Category { Id = 2, Name = "麵" },
			  new Category { Id = 3, Name = "私房拿手菜" },
			  new Category { Id = 4, Name = "小菜" },
			  new Category { Id = 5, Name = "湯" }
			);

			builder.Entity<Table>()
			.HasData(
			  new Table { Id = 1 },
			  new Table { Id = 2 },
			  new Table { Id = 3 },
			  new Table { Id = 4 },
			  new Table { Id = 5 }
			);
		}

		public DbSet<FoodItem> food_items => Set<FoodItem>();
		public DbSet<Order> orders => Set<Order>();
		public DbSet<Category> categories => Set<Category>();
		public DbSet<User> users => Set<User>();
		public DbSet<Table> tables => Set<Table>();

	}
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fungoodMVC.Data;

#nullable disable

namespace fungoodMVC.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fungoodMVC.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "飯"
                        },
                        new
                        {
                            Id = 2,
                            Name = "麵"
                        },
                        new
                        {
                            Id = 3,
                            Name = "私房拿手菜"
                        },
                        new
                        {
                            Id = 4,
                            Name = "小菜"
                        },
                        new
                        {
                            Id = 5,
                            Name = "湯"
                        });
                });

            modelBuilder.Entity("fungoodMVC.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("HasSpiciness")
                        .HasColumnType("bit");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("food_items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            HasSpiciness = true,
                            ImageSrc = "~/images/FoodItem/炒飯.jpg",
                            Inserted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "蒜味香腸炒飯",
                            Price = 80
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            HasSpiciness = true,
                            ImageSrc = "~/images/FoodItem/刀削麵.jpg",
                            Inserted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "沙茶牛炒刀削麵",
                            Price = 120
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            HasSpiciness = true,
                            ImageSrc = "~/images/FoodItem/獅子頭.jpg",
                            Inserted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "香蔥獅子頭",
                            Price = 200
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            HasSpiciness = false,
                            ImageSrc = "~/images/FoodItem/小黃瓜.png",
                            Inserted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "涼拌小黃瓜",
                            Price = 40
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            HasSpiciness = false,
                            ImageSrc = "~/images/FoodItem/人蔘雞湯.jpg",
                            Inserted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "枸杞人蔘雞湯",
                            Price = 150
                        });
                });

            modelBuilder.Entity("fungoodMVC.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Check")
                        .HasColumnType("bit");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("Spiciness")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("TableId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("fungoodMVC.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderNumer")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tables");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        },
                        new
                        {
                            Id = 3
                        },
                        new
                        {
                            Id = 4
                        },
                        new
                        {
                            Id = 5
                        });
                });

            modelBuilder.Entity("fungoodMVC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Rewards")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("fungoodMVC.Models.FoodItem", b =>
                {
                    b.HasOne("fungoodMVC.Models.Category", "category")
                        .WithMany("FoodItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("fungoodMVC.Models.Order", b =>
                {
                    b.HasOne("fungoodMVC.Models.FoodItem", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("fungoodMVC.Models.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId");

                    b.Navigation("FoodItem");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("fungoodMVC.Models.Category", b =>
                {
                    b.Navigation("FoodItems");
                });
#pragma warning restore 612, 618
        }
    }
}

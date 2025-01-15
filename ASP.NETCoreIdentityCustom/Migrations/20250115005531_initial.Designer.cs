﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyIceDream.Areas.Identity.Data;

#nullable disable

namespace MyIceDream.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250115005531_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MyIceDream.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MyIceDream.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("MyIceDream.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("MyIceDream.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lækre desserter",
                            Name = "Dessert"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Forfriskende hjemmelavet is",
                            Name = "Is"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Varme drikke for enhver smag",
                            Name = "Varm drikke"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Kolde og opkvikkende drikke",
                            Name = "Kolde drikke"
                        });
                });

            modelBuilder.Entity("MyIceDream.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyIceDream.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("MyIceDream.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Dubai chokolade - Lille (80g)",
                            Price = 60m
                        },
                        new
                        {
                            Id = 2,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Dubai chokolade - Mellem (200g)",
                            Price = 125m
                        },
                        new
                        {
                            Id = 3,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Dubai chokolade - Store (450g)",
                            Price = 225m
                        },
                        new
                        {
                            Id = 4,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Kunafa med kashta",
                            Price = 50m
                        },
                        new
                        {
                            Id = 5,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Kunafa nabelssia med ost",
                            Price = 50m
                        },
                        new
                        {
                            Id = 6,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Tyrkisk baklava",
                            Price = 50m
                        },
                        new
                        {
                            Id = 7,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Tyrkisk baklava med is",
                            Price = 70m
                        },
                        new
                        {
                            Id = 8,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Baklava mix",
                            Price = 50m
                        },
                        new
                        {
                            Id = 9,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Bubble waffle med nutella",
                            Price = 50m
                        },
                        new
                        {
                            Id = 10,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Bubble waffle med nutella og frugt",
                            Price = 65m
                        },
                        new
                        {
                            Id = 11,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Bubble waffle med nutella og is",
                            Price = 65m
                        },
                        new
                        {
                            Id = 12,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Bubble waffle med nutella, is og frugt",
                            Price = 80m
                        },
                        new
                        {
                            Id = 13,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Belgisk waffle",
                            Price = 50m
                        },
                        new
                        {
                            Id = 14,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Belgisk waffle med nutella og frugt",
                            Price = 50m
                        },
                        new
                        {
                            Id = 15,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Belgisk waffle med nutella og is",
                            Price = 60m
                        },
                        new
                        {
                            Id = 16,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Belgisk waffle med nutella, is og frugt",
                            Price = 70m
                        },
                        new
                        {
                            Id = 17,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Pandekager med nutella",
                            Price = 65m
                        },
                        new
                        {
                            Id = 18,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Pandekager med nutella og frugt",
                            Price = 75m
                        },
                        new
                        {
                            Id = 19,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Pandekager med nutella og is",
                            Price = 80m
                        },
                        new
                        {
                            Id = 20,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Pandekager med nutella, is og frugt",
                            Price = 85m
                        },
                        new
                        {
                            Id = 21,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Churros med nutella",
                            Price = 65m
                        },
                        new
                        {
                            Id = 22,
                            Availability = true,
                            CategoryId = 1,
                            Name = "Churros med nutella og is",
                            Price = 75m
                        },
                        new
                        {
                            Id = 23,
                            Availability = true,
                            CategoryId = 2,
                            Name = "Is box - 0.75 liter (3 smage)",
                            Price = 115m
                        },
                        new
                        {
                            Id = 24,
                            Availability = true,
                            CategoryId = 2,
                            Name = "Is box - 1 liter (4 smage)",
                            Price = 145m
                        },
                        new
                        {
                            Id = 25,
                            Availability = true,
                            CategoryId = 2,
                            Name = "Is box - 1.5 liter (5 smage)",
                            Price = 190m
                        },
                        new
                        {
                            Id = 26,
                            Availability = true,
                            CategoryId = 2,
                            Name = "Isrulle",
                            Price = 50m
                        },
                        new
                        {
                            Id = 27,
                            Availability = true,
                            CategoryId = 2,
                            Name = "Is kugle - 1 kugle",
                            Price = 32m
                        },
                        new
                        {
                            Id = 28,
                            Availability = true,
                            CategoryId = 2,
                            Name = "Is kugle - 2 kugler",
                            Price = 42m
                        },
                        new
                        {
                            Id = 29,
                            Availability = true,
                            CategoryId = 2,
                            Name = "Is kugle - 3 kugler",
                            Price = 52m
                        },
                        new
                        {
                            Id = 30,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Americano",
                            Price = 30m
                        },
                        new
                        {
                            Id = 31,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Espresso",
                            Price = 25m
                        },
                        new
                        {
                            Id = 32,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Cappuccino",
                            Price = 45m
                        },
                        new
                        {
                            Id = 33,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Kaffe latte",
                            Price = 45m
                        },
                        new
                        {
                            Id = 34,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Chai latte",
                            Price = 45m
                        },
                        new
                        {
                            Id = 35,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Matcha latte",
                            Price = 50m
                        },
                        new
                        {
                            Id = 36,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Te",
                            Price = 25m
                        },
                        new
                        {
                            Id = 37,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Arabisk kaffe",
                            Price = 45m
                        },
                        new
                        {
                            Id = 38,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Varm kakao",
                            Price = 35m
                        },
                        new
                        {
                            Id = 39,
                            Availability = true,
                            CategoryId = 3,
                            Name = "Macchiato",
                            Price = 40m
                        },
                        new
                        {
                            Id = 40,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Bubble tea med frugt",
                            Price = 55m
                        },
                        new
                        {
                            Id = 41,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Bubble tea med mælk tapioka",
                            Price = 60m
                        },
                        new
                        {
                            Id = 42,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Milkshake",
                            Price = 55m
                        },
                        new
                        {
                            Id = 43,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Mojito",
                            Price = 50m
                        },
                        new
                        {
                            Id = 44,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Matcha",
                            Price = 50m
                        },
                        new
                        {
                            Id = 45,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Lemonade",
                            Price = 45m
                        },
                        new
                        {
                            Id = 46,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Iskaffe",
                            Price = 40m
                        },
                        new
                        {
                            Id = 47,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Sodavand",
                            Price = 20m
                        },
                        new
                        {
                            Id = 48,
                            Availability = true,
                            CategoryId = 4,
                            Name = "Vand",
                            Price = 15m
                        });
                });

            modelBuilder.Entity("MyIceDream.Models.VwUser", b =>
                {
                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailConfirmed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToView("VwUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyIceDream.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyIceDream.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyIceDream.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyIceDream.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyIceDream.Models.CartItem", b =>
                {
                    b.HasOne("MyIceDream.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyIceDream.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyIceDream.Models.OrderItem", b =>
                {
                    b.HasOne("MyIceDream.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyIceDream.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyIceDream.Models.Product", b =>
                {
                    b.HasOne("MyIceDream.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyIceDream.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("MyIceDream.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MyIceDream.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}

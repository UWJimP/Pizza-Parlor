﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxContext))]
    [Migration("20210115172509_aspnet new migration")]
    partial class aspnetnewmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Crusts");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "regular",
                            Price = 1.0
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "thin",
                            Price = 1.5
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "pan",
                            Price = 1.75
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("StoreEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("StoreEntityID");

                    b.HasIndex("UserEntityID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CrustEntityID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderEntityID")
                        .HasColumnType("bigint");

                    b.Property<long?>("SizeEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("CrustEntityID");

                    b.HasIndex("OrderEntityID");

                    b.HasIndex("SizeEntityID");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "small",
                            Price = 1.0
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "medium",
                            Price = 2.0
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "large",
                            Price = 3.0
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Domino's"
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Pizza Hut"
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "Papa John's"
                        },
                        new
                        {
                            EntityID = 4L,
                            Name = "Generic Pizza Place"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PizzaEntityID")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.HasIndex("PizzaEntityID");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.User", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Store", null)
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustEntityID");

                    b.HasOne("PizzaBox.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderEntityID");

                    b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeEntityID");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Pizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("PizzaEntityID");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

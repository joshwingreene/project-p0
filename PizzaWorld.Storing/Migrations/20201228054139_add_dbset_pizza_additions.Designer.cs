﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaWorld.Storing;

namespace PizzaWorld.Storing.Migrations
{
    [DbContext(typeof(PizzaWorldContext))]
    [Migration("20201228054139_add_dbset_pizza_additions")]
    partial class add_dbset_pizza_additions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PizzaWorld.Domain.Abstracts.APizzaModel", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CrustEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SizeEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("EntityId");

                    b.HasIndex("CrustEntityId");

                    b.HasIndex("OrderEntityId");

                    b.HasIndex("SizeEntityId");

                    b.ToTable("APizzaModel");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Crust", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Crusts");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("StoreEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("EntityId");

                    b.HasIndex("StoreEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Size", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("Inches")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Store", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "First Store"
                        },
                        new
                        {
                            EntityId = 2L,
                            Name = "Second Store"
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Topping", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("APizzaModelEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.HasIndex("APizzaModelEntityId");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.User", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("SelectedStoreEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("EntityId");

                    b.HasIndex("SelectedStoreEntityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Abstracts.APizzaModel", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustEntityId");

                    b.HasOne("PizzaWorld.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderEntityId");

                    b.HasOne("PizzaWorld.Domain.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeEntityId");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Store", null)
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityId");

                    b.HasOne("PizzaWorld.Domain.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Topping", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Abstracts.APizzaModel", null)
                        .WithMany("Toppings")
                        .HasForeignKey("APizzaModelEntityId");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.User", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Store", "SelectedStore")
                        .WithMany()
                        .HasForeignKey("SelectedStoreEntityId");

                    b.Navigation("SelectedStore");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Abstracts.APizzaModel", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Store", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

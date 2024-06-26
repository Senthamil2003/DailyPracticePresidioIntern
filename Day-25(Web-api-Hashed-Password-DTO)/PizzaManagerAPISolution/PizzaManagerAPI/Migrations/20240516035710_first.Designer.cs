﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaManagerAPI.Context;

#nullable disable

namespace PizzaManagerAPI.Migrations
{
    [DbContext(typeof(PizzaManagerContext))]
    [Migration("20240516035710_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PizzaManagerAPI.Model.Customer", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaManagerAPI.Model.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaId"), 1L, 1);

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaId = 100,
                            PizzaName = "Chicken Pizza",
                            Price = 250,
                            Quantity = 10,
                            Size = "M"
                        },
                        new
                        {
                            PizzaId = 101,
                            PizzaName = "Cheese Pizza",
                            Price = 150,
                            Quantity = 10,
                            Size = "L"
                        },
                        new
                        {
                            PizzaId = 102,
                            PizzaName = "Veggie Pizza",
                            Price = 150,
                            Quantity = 10,
                            Size = "S"
                        },
                        new
                        {
                            PizzaId = 103,
                            PizzaName = "Pepperoni Pizza",
                            Price = 250,
                            Quantity = 10,
                            Size = "M"
                        });
                });

            modelBuilder.Entity("PizzaManagerAPI.Model.UserCredential", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserName");

                    b.HasIndex("UserId");

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("PizzaManagerAPI.Model.UserCredential", b =>
                {
                    b.HasOne("PizzaManagerAPI.Model.Customer", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

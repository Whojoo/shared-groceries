﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SharedGrocery.Repositories.DBContexts;
using System;

namespace SharedGrocery.Migrations
{
    [DbContext(typeof(GroceryDataContext))]
    partial class GroceryDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("SharedGrocery.Models.Grocery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GroceryListId");

                    b.Property<int?>("ItemId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("GroceryListId");

                    b.HasIndex("ItemId");

                    b.ToTable("Groceries");
                });

            modelBuilder.Entity("SharedGrocery.Models.GroceryList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("GroceryLists");
                });

            modelBuilder.Entity("SharedGrocery.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Barcode");

                    b.Property<string>("Brand");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SharedGrocery.Models.Grocery", b =>
                {
                    b.HasOne("SharedGrocery.Models.GroceryList")
                        .WithMany("Groceries")
                        .HasForeignKey("GroceryListId");

                    b.HasOne("SharedGrocery.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");
                });
#pragma warning restore 612, 618
        }
    }
}

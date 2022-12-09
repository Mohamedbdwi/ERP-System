﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Small_ERP.Models;

#nullable disable

namespace Small_ERP.Migrations
{
    [DbContext(typeof(ERPDbContext))]
    [Migration("20221101123637_supplierStatement2")]
    partial class supplierStatement2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Small_ERP.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Small_ERP.Models.InvoiceDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("InvoiceHeader_Id")
                        .HasColumnType("int");

                    b.Property<int>("Item_Cost")
                        .HasColumnType("int");

                    b.Property<int?>("Item_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceHeader_Id");

                    b.HasIndex("Item_Id");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("Small_ERP.Models.InvoiceHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Paid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Remainder")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total_Cost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("InvoiceHeaders");
                });

            modelBuilder.Entity("Small_ERP.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Purchasing_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Selling_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Start_Period_Balance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Small_ERP.Models.PurchasesBillDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Item_Cost")
                        .HasColumnType("int");

                    b.Property<int?>("Item_Id")
                        .HasColumnType("int");

                    b.Property<int?>("PurchasesBillHeader_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Item_Id");

                    b.HasIndex("PurchasesBillHeader_Id");

                    b.ToTable("PurchasesBillDetails");
                });

            modelBuilder.Entity("Small_ERP.Models.PurchasesBillHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Paid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Remainder")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Supplier_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Total_Cost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Supplier_Id");

                    b.ToTable("PurchasesBillHeaders");
                });

            modelBuilder.Entity("Small_ERP.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Item_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Item_Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Small_ERP.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Small_ERP.Models.SupplierAccountStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Paid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Remainder")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Supplier_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Total_Cost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Supplier_Id");

                    b.ToTable("SupplierAccountStatements");
                });

            modelBuilder.Entity("Small_ERP.Models.InvoiceDetails", b =>
                {
                    b.HasOne("Small_ERP.Models.InvoiceHeader", "InvoiceHeader")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceHeader_Id");

                    b.HasOne("Small_ERP.Models.Item", "Item")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("Item_Id");

                    b.Navigation("InvoiceHeader");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Small_ERP.Models.InvoiceHeader", b =>
                {
                    b.HasOne("Small_ERP.Models.Customer", "Customer")
                        .WithMany("InvoiceHeader")
                        .HasForeignKey("Customer_Id");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Small_ERP.Models.PurchasesBillDetails", b =>
                {
                    b.HasOne("Small_ERP.Models.Item", "Item")
                        .WithMany("PurchasesBillDetails")
                        .HasForeignKey("Item_Id");

                    b.HasOne("Small_ERP.Models.PurchasesBillHeader", "PurchasesBillHeader")
                        .WithMany("PurchasesBillDetails")
                        .HasForeignKey("PurchasesBillHeader_Id");

                    b.Navigation("Item");

                    b.Navigation("PurchasesBillHeader");
                });

            modelBuilder.Entity("Small_ERP.Models.PurchasesBillHeader", b =>
                {
                    b.HasOne("Small_ERP.Models.Supplier", "Supplier")
                        .WithMany("PurchasesBillHeader")
                        .HasForeignKey("Supplier_Id");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Small_ERP.Models.Store", b =>
                {
                    b.HasOne("Small_ERP.Models.Item", "Item")
                        .WithMany("Store")
                        .HasForeignKey("Item_Id");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Small_ERP.Models.SupplierAccountStatement", b =>
                {
                    b.HasOne("Small_ERP.Models.Customer", null)
                        .WithMany("SupplierAccountStatement")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Small_ERP.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("Supplier_Id");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Small_ERP.Models.Customer", b =>
                {
                    b.Navigation("InvoiceHeader");

                    b.Navigation("SupplierAccountStatement");
                });

            modelBuilder.Entity("Small_ERP.Models.InvoiceHeader", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("Small_ERP.Models.Item", b =>
                {
                    b.Navigation("InvoiceDetails");

                    b.Navigation("PurchasesBillDetails");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Small_ERP.Models.PurchasesBillHeader", b =>
                {
                    b.Navigation("PurchasesBillDetails");
                });

            modelBuilder.Entity("Small_ERP.Models.Supplier", b =>
                {
                    b.Navigation("PurchasesBillHeader");
                });
#pragma warning restore 612, 618
        }
    }
}

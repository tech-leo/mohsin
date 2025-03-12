﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MohsinQBO.Migrations.TenantDb
{
    [DbContext(typeof(TenantDbContext))]
    [Migration("20250312210232_Tenant24")]
    partial class Tenant24
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APAgingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RawJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("APAgingDetail");
                });

            modelBuilder.Entity("ARAgingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RawJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ARAgingDetail");
                });

            modelBuilder.Entity("AccountEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RawJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RawJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RawJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GeneralLedgerDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RawJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("account_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("credit_amt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cust_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("debt_amt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doc_num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("klass_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("memo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rbal_nat_amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("split_acc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subt_nat_amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tx_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txn_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vend_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneralLedgerDetail");
                });

            modelBuilder.Entity("Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RawJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectAsp.Models;

#nullable disable

namespace ProjectAsp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231018201803_addTables")]
    partial class addTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectAsp.Models.branch.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Branch_Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Branch_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Comp_Id")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("companyComp_Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("companyComp_Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("ProjectAsp.Models.company.Company", b =>
                {
                    b.Property<int>("Comp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Comp_Id"));

                    b.Property<string>("Comp_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Date_Establishment")
                        .HasColumnType("date");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Comp_Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ProjectAsp.Models.operation.Operation", b =>
                {
                    b.Property<int>("Branch_Id")
                        .HasColumnType("integer");

                    b.Property<int>("Prouduct_Id")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<int>("branchId")
                        .HasColumnType("integer");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.HasKey("Branch_Id", "Prouduct_Id");

                    b.HasIndex("branchId");

                    b.HasIndex("productId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("ProjectAsp.Models.product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Product_Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Product_Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProjectAsp.Models.branch.Branch", b =>
                {
                    b.HasOne("ProjectAsp.Models.company.Company", "company")
                        .WithMany()
                        .HasForeignKey("companyComp_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");
                });

            modelBuilder.Entity("ProjectAsp.Models.operation.Operation", b =>
                {
                    b.HasOne("ProjectAsp.Models.branch.Branch", "branch")
                        .WithMany()
                        .HasForeignKey("branchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectAsp.Models.product.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("branch");

                    b.Navigation("product");
                });
#pragma warning restore 612, 618
        }
    }
}

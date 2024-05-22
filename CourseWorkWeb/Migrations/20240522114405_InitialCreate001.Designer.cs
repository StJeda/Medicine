﻿// <auto-generated />
using System;
using CourseWorkWeb.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseWorkWeb.Migrations
{
    [DbContext(typeof(MedicineDataContext))]
    [Migration("20240522114405_InitialCreate001")]
    partial class InitialCreate001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Auth.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PasswordId")
                        .HasColumnType("bigint");

                    b.Property<long>("Password_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<long>("Photo_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserPhotoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verify")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PasswordId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserPhotoId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Auth.Password", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Account_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("PasswordValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Auth.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Auth.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Diseases.Disease", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Diseases.Symptom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Disease_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Medicines.Medicine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Articules")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<long>("MedicinePhoto_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PharmacyId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("Substance_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Medicines.Substance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Mass")
                        .HasColumnType("float");

                    b.Property<long>("Medicine_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Substances");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Orders.DeadLine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DeadLines");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("DeadLineId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PharmacyId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("DeadLineId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Pharmacist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Account_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Grade_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Pharmacy_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Salary_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Pharmacists");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Pharmacy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneHotline")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Photos.MedicinePhoto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Medicine_Id")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicinePhotos");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Photos.UserPhoto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Medicine_Id")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("UserPhotos");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Relations.MedicinesOrders", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Medicine_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Order_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MedicinesOrders");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Relations.MedicinesSubstances", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Medicine_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Substance_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MedicinesSubstances");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Relations.PharmaciesMedicines", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Medicine_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Pharmacy_Id")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PharmaciesMedicines");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Relations.RolesPermissions", b =>
                {
                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("PermissionId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolesPermissions");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Relations.SubstancesSymptoms", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Substance_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Symptom_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SubstancesSymptoms");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Relations.SymptomsDiseases", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Disease_Id")
                        .HasColumnType("int");

                    b.Property<int>("Symptom_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SymptomsDiseases");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Relations.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("userRoles");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Auth.Account", b =>
                {
                    b.HasOne("CourseWorkWeb.Models.Entity.Auth.Password", "Password")
                        .WithMany()
                        .HasForeignKey("PasswordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWorkWeb.Models.Entity.Auth.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWorkWeb.Models.Entity.Photos.UserPhoto", "UserPhoto")
                        .WithMany()
                        .HasForeignKey("UserPhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Password");

                    b.Navigation("Role");

                    b.Navigation("UserPhoto");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Medicines.Medicine", b =>
                {
                    b.HasOne("CourseWorkWeb.Models.Entity.Pharmacy", null)
                        .WithMany("Medicines")
                        .HasForeignKey("PharmacyId");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Orders.Order", b =>
                {
                    b.HasOne("CourseWorkWeb.Models.Entity.Auth.Account", null)
                        .WithMany("Orders")
                        .HasForeignKey("AccountId");

                    b.HasOne("CourseWorkWeb.Models.Entity.Orders.DeadLine", "DeadLine")
                        .WithMany()
                        .HasForeignKey("DeadLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWorkWeb.Models.Entity.Pharmacy", null)
                        .WithMany("Orders")
                        .HasForeignKey("PharmacyId");

                    b.Navigation("DeadLine");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Relations.RolesPermissions", b =>
                {
                    b.HasOne("CourseWorkWeb.Models.Entity.Auth.Permission", "Permission")
                        .WithMany("RolesPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWorkWeb.Models.Entity.Auth.Role", "Role")
                        .WithMany("RolesPermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Auth.Account", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Auth.Permission", b =>
                {
                    b.Navigation("RolesPermissions");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Auth.Role", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("RolesPermissions");
                });

            modelBuilder.Entity("CourseWorkWeb.Models.Entity.Pharmacy", b =>
                {
                    b.Navigation("Medicines");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
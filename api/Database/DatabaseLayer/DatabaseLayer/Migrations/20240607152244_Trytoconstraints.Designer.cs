﻿// <auto-generated />
using System;
using DatabaseLayer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseLayer.Migrations
{
    [DbContext(typeof(TimeControllerContext))]
    [Migration("20240607152244_Trytoconstraints")]
    partial class Trytoconstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DatabaseLayer.Database.Models.Access", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TradePointId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TradePointId");

                    b.ToTable("Access");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AccessId")
                        .HasColumnType("uuid");

                    b.Property<int>("GenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TradePointId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("GenderId");

                    b.HasIndex("TradePointId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.TradePoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TradePoints");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.Access", b =>
                {
                    b.HasOne("DatabaseLayer.Database.Models.TradePoint", "TradePoint")
                        .WithMany()
                        .HasForeignKey("TradePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TradePoint");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.Employee", b =>
                {
                    b.HasOne("DatabaseLayer.Database.Models.Access", "Access")
                        .WithMany("Employees")
                        .HasForeignKey("AccessId");

                    b.HasOne("DatabaseLayer.Database.Models.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.Database.Models.TradePoint", "TradePoint")
                        .WithMany("Employees")
                        .HasForeignKey("TradePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Access");

                    b.Navigation("Gender");

                    b.Navigation("TradePoint");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.Access", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.Gender", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.TradePoint", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

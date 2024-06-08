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
    [Migration("20240607182330_new tables")]
    partial class newtables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DatabaseLayer.Database.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("GenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<Guid?>("TradePointId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

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

            modelBuilder.Entity("DatabaseLayer.Database.Models.OpenedShifts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("TimeClose")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TimeOpen")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TradePointId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TradePointId")
                        .IsUnique();

                    b.ToTable("OpenedShifts");
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

            modelBuilder.Entity("DatabaseLayer.Database.Models.Employee", b =>
                {
                    b.HasOne("DatabaseLayer.Database.Models.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId");

                    b.HasOne("DatabaseLayer.Database.Models.TradePoint", "TradePoint")
                        .WithMany("Employees")
                        .HasForeignKey("TradePointId");

                    b.Navigation("Gender");

                    b.Navigation("TradePoint");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.OpenedShifts", b =>
                {
                    b.HasOne("DatabaseLayer.Database.Models.TradePoint", "TradePoint")
                        .WithOne("OpenedShift")
                        .HasForeignKey("DatabaseLayer.Database.Models.OpenedShifts", "TradePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TradePoint");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.Gender", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.TradePoint", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("OpenedShift");
                });
#pragma warning restore 612, 618
        }
    }
}
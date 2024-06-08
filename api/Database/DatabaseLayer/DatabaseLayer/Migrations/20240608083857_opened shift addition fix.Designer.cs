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
    [Migration("20240608083857_opened shift addition fix")]
    partial class openedshiftadditionfix
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

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AccessId")
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

            modelBuilder.Entity("DatabaseLayer.Database.Models.OpenedShift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TradePointId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TradePointId");

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
                    b.HasOne("DatabaseLayer.Database.Models.Access", null)
                        .WithMany("Employees")
                        .HasForeignKey("AccessId");

                    b.HasOne("DatabaseLayer.Database.Models.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId");

                    b.HasOne("DatabaseLayer.Database.Models.TradePoint", "TradePoint")
                        .WithMany("Employees")
                        .HasForeignKey("TradePointId");

                    b.Navigation("Gender");

                    b.Navigation("TradePoint");
                });

            modelBuilder.Entity("DatabaseLayer.Database.Models.OpenedShift", b =>
                {
                    b.HasOne("DatabaseLayer.Database.Models.TradePoint", "TradePoint")
                        .WithMany()
                        .HasForeignKey("TradePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

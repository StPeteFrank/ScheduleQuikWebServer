﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ScheduleQuikWebServer;

namespace ScheduleQuikWebServer.Migrations
{
    [DbContext(typeof(ScheduleQuikDbContext))]
    [Migration("20190110000016_AddedNewTables")]
    partial class AddedNewTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ScheduleQuikWebServer.Models.EmployeesTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ScheduleQuikWebServer.Models.PositionsTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PositionName");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("ScheduleQuikWebServer.Models.ShiftsTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeesTableId");

                    b.Property<DateTime>("InTime");

                    b.Property<DateTime>("OutTime");

                    b.Property<int>("PositionsTableId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesTableId");

                    b.HasIndex("PositionsTableId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("ScheduleQuikWebServer.Models.ShiftsTable", b =>
                {
                    b.HasOne("ScheduleQuikWebServer.Models.EmployeesTable", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesTableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ScheduleQuikWebServer.Models.PositionsTable", "Positions")
                        .WithMany()
                        .HasForeignKey("PositionsTableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
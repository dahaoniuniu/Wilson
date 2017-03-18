﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Wilson.Scheduler.Data;
using Wilson.Scheduler.Core.Enumerations;

namespace Wilson.Scheduler.Data.Migrations
{
    [DbContext(typeof(SchedulerDbContext))]
    partial class SchedulerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("Scheduler")
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wilson.Scheduler.Core.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeePosition");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<Guid>("PayRateId");

                    b.HasKey("Id");

                    b.HasIndex("PayRateId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Wilson.Scheduler.Core.Entities.Paycheck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("EmployeeId");

                    b.Property<int>("ExtraHours");

                    b.Property<DateTime>("From");

                    b.Property<int>("HourOnHolidays");

                    b.Property<int>("Hours");

                    b.Property<int>("PaidDaysOff");

                    b.Property<decimal>("PayForExtraHours")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("PayForHolidayHours")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("PayForHours")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("PayForPayedDaysOff")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("SickDaysOff");

                    b.Property<DateTime>("To");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("UnpaidDaysOff");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Paychecks");
                });

            modelBuilder.Entity("Wilson.Scheduler.Core.Entities.PayRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ExtraHour")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("HoidayHour");

                    b.Property<decimal>("Hour")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("PayRates");
                });

            modelBuilder.Entity("Wilson.Scheduler.Core.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(900);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Wilson.Scheduler.Core.Entities.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("EmployeeId");

                    b.Property<int>("ExtraWorkHours");

                    b.Property<bool>("IsHoliday");

                    b.Property<bool>("IsPaidDayOff");

                    b.Property<bool>("IsSickDayOff");

                    b.Property<bool>("IsUnpaidDayOff");

                    b.Property<Guid>("ProjectId");

                    b.Property<int>("WorkHours");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Wilson.Scheduler.Core.Entities.Employee", b =>
                {
                    b.HasOne("Wilson.Scheduler.Core.Entities.PayRate", "PayRate")
                        .WithMany()
                        .HasForeignKey("PayRateId");
                });

            modelBuilder.Entity("Wilson.Scheduler.Core.Entities.Paycheck", b =>
                {
                    b.HasOne("Wilson.Scheduler.Core.Entities.Employee", "Employee")
                        .WithMany("Paychecks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wilson.Scheduler.Core.Entities.Schedule", b =>
                {
                    b.HasOne("Wilson.Scheduler.Core.Entities.Employee", "Employee")
                        .WithMany("Schedules")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Wilson.Scheduler.Core.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });
        }
    }
}
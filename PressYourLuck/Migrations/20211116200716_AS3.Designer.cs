﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PressYourLuck.Data;

namespace PressYourLuck.Migrations
{
    [DbContext(typeof(AuditContext))]
    [Migration("20211116200716_AS3")]
    partial class AS3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PressYourLuck.Models.Audit", b =>
                {
                    b.Property<int>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("AuditTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditId");

                    b.HasIndex("AuditTypeId");

                    b.ToTable("Audit");
                });

            modelBuilder.Entity("PressYourLuck.Models.AuditType", b =>
                {
                    b.Property<int>("AuditTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditTypeId");

                    b.ToTable("AuditType");

                    b.HasData(
                        new
                        {
                            AuditTypeId = 1,
                            Name = "Cash In"
                        },
                        new
                        {
                            AuditTypeId = 2,
                            Name = "Cash Out"
                        },
                        new
                        {
                            AuditTypeId = 3,
                            Name = "Win"
                        },
                        new
                        {
                            AuditTypeId = 4,
                            Name = "Lose"
                        });
                });

            modelBuilder.Entity("PressYourLuck.Models.Audit", b =>
                {
                    b.HasOne("PressYourLuck.Models.AuditType", "AuditType")
                        .WithMany()
                        .HasForeignKey("AuditTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditType");
                });
#pragma warning restore 612, 618
        }
    }
}
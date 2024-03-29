﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UtilityLibrary.Data.SWContext;

namespace UtilityLibrary.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211206214028_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UnitWeapon", b =>
                {
                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponsId")
                        .HasColumnType("int");

                    b.HasKey("UnitsId", "WeaponsId");

                    b.HasIndex("WeaponsId");

                    b.ToTable("UnitWeapon");
                });

            modelBuilder.Entity("UtilityLibrary.Models.AttackDie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeaponId");

                    b.ToTable("AttackDie");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Keyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AbilityValue")
                        .HasColumnType("int");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Keyword");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArmyId")
                        .HasColumnType("int");

                    b.Property<int>("AttackSurge")
                        .HasColumnType("int");

                    b.Property<int>("Courage")
                        .HasColumnType("int");

                    b.Property<int>("Faction")
                        .HasColumnType("int");

                    b.Property<bool>("IsDefenseRed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefenseSurge")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnique")
                        .HasColumnType("bit");

                    b.Property<int>("MinisInUnit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointCost")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitType")
                        .HasColumnType("int");

                    b.Property<int>("WoundThreshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("UtilityLibrary.Models.UpgradeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("UpgradeCategory");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaxRange")
                        .HasColumnType("int");

                    b.Property<int>("MinRange")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangeType")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpgradeCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UpgradeCategoryId");

                    b.ToTable("Weapon");
                });

            modelBuilder.Entity("UnitWeapon", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UtilityLibrary.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UtilityLibrary.Models.AttackDie", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Weapon", null)
                        .WithMany("AttackDie")
                        .HasForeignKey("WeaponId");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Keyword", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Unit", null)
                        .WithMany("Keywords")
                        .HasForeignKey("UnitId");

                    b.HasOne("UtilityLibrary.Models.Weapon", null)
                        .WithMany("Keywords")
                        .HasForeignKey("WeaponId");
                });

            modelBuilder.Entity("UtilityLibrary.Models.UpgradeCategory", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Unit", null)
                        .WithMany("UpgradeCategories")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Weapon", b =>
                {
                    b.HasOne("UtilityLibrary.Models.UpgradeCategory", "UpgradeCategory")
                        .WithMany()
                        .HasForeignKey("UpgradeCategoryId");

                    b.Navigation("UpgradeCategory");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Unit", b =>
                {
                    b.Navigation("Keywords");

                    b.Navigation("UpgradeCategories");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Weapon", b =>
                {
                    b.Navigation("AttackDie");

                    b.Navigation("Keywords");
                });
#pragma warning restore 612, 618
        }
    }
}

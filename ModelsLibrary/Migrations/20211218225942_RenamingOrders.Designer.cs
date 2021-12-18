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
    [Migration("20211218225942_RenamingOrders")]
    partial class RenamingOrders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KeywordUnit", b =>
                {
                    b.Property<int>("KeywordsId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("KeywordsId", "UnitsId");

                    b.HasIndex("UnitsId");

                    b.ToTable("KeywordUnit");
                });

            modelBuilder.Entity("KeywordUpgrade", b =>
                {
                    b.Property<int>("KeywordsId")
                        .HasColumnType("int");

                    b.Property<int>("UpgradesId")
                        .HasColumnType("int");

                    b.HasKey("KeywordsId", "UpgradesId");

                    b.HasIndex("UpgradesId");

                    b.ToTable("KeywordUpgrade");
                });

            modelBuilder.Entity("KeywordWeapon", b =>
                {
                    b.Property<int>("KeywordsId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponsId")
                        .HasColumnType("int");

                    b.HasKey("KeywordsId", "WeaponsId");

                    b.HasIndex("WeaponsId");

                    b.ToTable("KeywordWeapon");
                });

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

            modelBuilder.Entity("UtilityLibrary.Models.Army", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Faction")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("PointLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Armies");
                });

            modelBuilder.Entity("UtilityLibrary.Models.AttackValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlackDie")
                        .HasColumnType("int");

                    b.Property<int>("RedDie")
                        .HasColumnType("int");

                    b.Property<int>("WhiteDie")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AttackValue");
                });

            modelBuilder.Entity("UtilityLibrary.Models.ChosenCommand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArmyId")
                        .HasColumnType("int");

                    b.Property<int>("CommandId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmyId");

                    b.HasIndex("CommandId");

                    b.ToTable("ChosenCommand");
                });

            modelBuilder.Entity("UtilityLibrary.Models.ChosenUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArmyId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmyId");

                    b.HasIndex("UnitId");

                    b.ToTable("ChosenUnit");
                });

            modelBuilder.Entity("UtilityLibrary.Models.ChosenUpgrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChosenUnitId")
                        .HasColumnType("int");

                    b.Property<int>("UpgradeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChosenUnitId");

                    b.HasIndex("UpgradeId");

                    b.ToTable("ChosenUpgrade");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orders")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pips")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Commands");
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

                    b.HasKey("Id");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("UtilityLibrary.Models.Upgrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsExhaustable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFreeAction")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnique")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointCost")
                        .HasColumnType("int");

                    b.Property<int?>("ReconfigureId")
                        .HasColumnType("int");

                    b.Property<string>("Restriction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpgradeType")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.Property<int?>("WoundThreshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReconfigureId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Upgrades");
                });

            modelBuilder.Entity("UtilityLibrary.Models.UpgradeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("UpgradeType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("UpgradeOption");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttackSurge")
                        .HasColumnType("int");

                    b.Property<int?>("AttackValueId")
                        .HasColumnType("int");

                    b.Property<int?>("MaxRange")
                        .HasColumnType("int");

                    b.Property<int?>("MinRange")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangeType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttackValueId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("KeywordUnit", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Keyword", null)
                        .WithMany()
                        .HasForeignKey("KeywordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UtilityLibrary.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KeywordUpgrade", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Keyword", null)
                        .WithMany()
                        .HasForeignKey("KeywordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UtilityLibrary.Models.Upgrade", null)
                        .WithMany()
                        .HasForeignKey("UpgradesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KeywordWeapon", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Keyword", null)
                        .WithMany()
                        .HasForeignKey("KeywordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UtilityLibrary.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("UtilityLibrary.Models.Army", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Player", "Player")
                        .WithMany("Armies")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("UtilityLibrary.Models.ChosenCommand", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Army", null)
                        .WithMany("ChosenCommands")
                        .HasForeignKey("ArmyId");

                    b.HasOne("UtilityLibrary.Models.Command", "Command")
                        .WithMany()
                        .HasForeignKey("CommandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Command");
                });

            modelBuilder.Entity("UtilityLibrary.Models.ChosenUnit", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Army", null)
                        .WithMany("ChosenUnits")
                        .HasForeignKey("ArmyId");

                    b.HasOne("UtilityLibrary.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("UtilityLibrary.Models.ChosenUpgrade", b =>
                {
                    b.HasOne("UtilityLibrary.Models.ChosenUnit", null)
                        .WithMany("ChosenUpgrades")
                        .HasForeignKey("ChosenUnitId");

                    b.HasOne("UtilityLibrary.Models.Upgrade", "Upgrade")
                        .WithMany()
                        .HasForeignKey("UpgradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Upgrade");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Command", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Upgrade", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Upgrade", "Reconfigure")
                        .WithMany()
                        .HasForeignKey("ReconfigureId");

                    b.HasOne("UtilityLibrary.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Reconfigure");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("UtilityLibrary.Models.UpgradeOption", b =>
                {
                    b.HasOne("UtilityLibrary.Models.Unit", null)
                        .WithMany("UpgradeOptions")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UtilityLibrary.Models.Weapon", b =>
                {
                    b.HasOne("UtilityLibrary.Models.AttackValue", "AttackValue")
                        .WithMany()
                        .HasForeignKey("AttackValueId");

                    b.Navigation("AttackValue");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Army", b =>
                {
                    b.Navigation("ChosenCommands");

                    b.Navigation("ChosenUnits");
                });

            modelBuilder.Entity("UtilityLibrary.Models.ChosenUnit", b =>
                {
                    b.Navigation("ChosenUpgrades");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Player", b =>
                {
                    b.Navigation("Armies");
                });

            modelBuilder.Entity("UtilityLibrary.Models.Unit", b =>
                {
                    b.Navigation("UpgradeOptions");
                });
#pragma warning restore 612, 618
        }
    }
}

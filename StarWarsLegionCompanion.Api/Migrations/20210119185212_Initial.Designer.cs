﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWarsLegionCompanion.Api.Models;

namespace StarWarsLegionCompanion.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210119185212_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

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

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.AttackDie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AttackDie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "White",
                            Value = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "White",
                            Value = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "White",
                            Value = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "White",
                            Value = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "White",
                            Value = 5
                        },
                        new
                        {
                            Id = 6,
                            Name = "White",
                            Value = 6
                        },
                        new
                        {
                            Id = 11,
                            Name = "Black",
                            Value = 1
                        },
                        new
                        {
                            Id = 12,
                            Name = "Black",
                            Value = 2
                        },
                        new
                        {
                            Id = 13,
                            Name = "Black",
                            Value = 3
                        },
                        new
                        {
                            Id = 14,
                            Name = "Black",
                            Value = 4
                        },
                        new
                        {
                            Id = 15,
                            Name = "Black",
                            Value = 5
                        },
                        new
                        {
                            Id = 16,
                            Name = "Black",
                            Value = 6
                        },
                        new
                        {
                            Id = 21,
                            Name = "Red",
                            Value = 1
                        },
                        new
                        {
                            Id = 22,
                            Name = "Red",
                            Value = 2
                        },
                        new
                        {
                            Id = 23,
                            Name = "Red",
                            Value = 3
                        },
                        new
                        {
                            Id = 24,
                            Name = "Red",
                            Value = 4
                        },
                        new
                        {
                            Id = 25,
                            Name = "Red",
                            Value = 5
                        },
                        new
                        {
                            Id = 26,
                            Name = "Red",
                            Value = 6
                        });
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.AttackSurge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AttackSurge");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "None"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hit"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Critical"
                        });
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faction");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Neutral"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rebel Alliance"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Galactic Empire"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Separatist Alliance"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Galactic Republic"
                        });
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.Keyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AbilityValue")
                        .HasColumnType("int");

                    b.Property<bool>("IsCardAction")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFreeAction")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Keywords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbilityValue = 1,
                            IsCardAction = true,
                            IsFreeAction = false,
                            Name = "Jump",
                            Text = "Perform a move during which you ignore terrain that is height 1 or lower. This is treated as a move action."
                        },
                        new
                        {
                            Id = 2,
                            IsCardAction = false,
                            IsFreeAction = false,
                            Name = "Charge",
                            Text = "After you perform a move action, you may perform a free melee attack action."
                        },
                        new
                        {
                            Id = 3,
                            IsCardAction = false,
                            IsFreeAction = false,
                            Name = "Deflect",
                            Text = "After While defending, if you spend a dodge token, you gain “Surge: Block”: if it’s a ranged attack, the attacker suffers 1 wound for each Surge rolled."
                        },
                        new
                        {
                            Id = 4,
                            IsCardAction = false,
                            IsFreeAction = false,
                            Name = "Immune: Pierce",
                            Text = "Pierce cannot be used against you."
                        },
                        new
                        {
                            Id = 5,
                            AbilityValue = 2,
                            IsCardAction = false,
                            IsFreeAction = false,
                            Name = "Impact",
                            Text = "While attacking a unit that has Armor, change up to X Dice Hit.png result(s) to Dice Crit.png result(s)."
                        },
                        new
                        {
                            Id = 6,
                            AbilityValue = 2,
                            IsCardAction = false,
                            IsFreeAction = false,
                            Name = "Pierce",
                            Text = "When attacking, ignore up to 2 block results."
                        },
                        new
                        {
                            Id = 7,
                            AbilityValue = 1,
                            IsCardAction = false,
                            IsFreeAction = false,
                            Name = "Precise 1",
                            Text = "When you spend an aim token, reroll up to 1 additional die."
                        });
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.RangeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RangeType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Melee"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ranged"
                        });
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rank");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Commander"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Operative"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Corps"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Special Forces"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Support"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Heavy"
                        });
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AttackSurgeId")
                        .HasColumnType("int");

                    b.Property<int>("Courage")
                        .HasColumnType("int");

                    b.Property<int>("FactionId")
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

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitTypeId")
                        .HasColumnType("int");

                    b.Property<int>("WoundThreshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttackSurgeId");

                    b.HasIndex("FactionId");

                    b.HasIndex("RankId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AttackSurgeId = 3,
                            Courage = 3,
                            FactionId = 2,
                            IsDefenseRed = true,
                            IsDefenseSurge = false,
                            IsUnique = true,
                            MinisInUnit = 1,
                            Name = "Luke Skywalker",
                            PointCost = 160,
                            RankId = 1,
                            Speed = 2,
                            SurName = "HERO OF THE REBELLION",
                            UnitTypeId = 1,
                            WoundThreshold = 6
                        });
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Trooper"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Repulsor Vehicle"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ground Vehicle"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Emplacement Trooper"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Creature Tropper"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Wookie Tropper"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Droid Trooper"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Clone Trooper"
                        });
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AttackValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaxRange")
                        .HasColumnType("int");

                    b.Property<int?>("MinRange")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangeTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RangeTypeId");

                    b.ToTable("Weapons");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            MaxRange = 2,
                            MinRange = 1,
                            Name = "Luke's DL-44 Blaster Pistol",
                            RangeTypeId = 2
                        },
                        new
                        {
                            Id = 1,
                            Name = "Anakin's Lightsaber",
                            RangeTypeId = 1
                        });
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

            modelBuilder.Entity("KeywordUnit", b =>
                {
                    b.HasOne("StarWarsLegionCompanion.Api.Models.Keyword", null)
                        .WithMany()
                        .HasForeignKey("KeywordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsLegionCompanion.Api.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KeywordWeapon", b =>
                {
                    b.HasOne("StarWarsLegionCompanion.Api.Models.Keyword", null)
                        .WithMany()
                        .HasForeignKey("KeywordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsLegionCompanion.Api.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.Unit", b =>
                {
                    b.HasOne("StarWarsLegionCompanion.Api.Models.AttackSurge", "AttackSurge")
                        .WithMany()
                        .HasForeignKey("AttackSurgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsLegionCompanion.Api.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsLegionCompanion.Api.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsLegionCompanion.Api.Models.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttackSurge");

                    b.Navigation("Faction");

                    b.Navigation("Rank");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("StarWarsLegionCompanion.Api.Models.Weapon", b =>
                {
                    b.HasOne("StarWarsLegionCompanion.Api.Models.RangeType", "RangeType")
                        .WithMany()
                        .HasForeignKey("RangeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RangeType");
                });

            modelBuilder.Entity("UnitWeapon", b =>
                {
                    b.HasOne("StarWarsLegionCompanion.Api.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsLegionCompanion.Api.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

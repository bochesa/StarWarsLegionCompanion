using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace StarWarsLegionCompanion.Api.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            #region Seed AttackDies
            //premade object for Attack die
            builder.Entity<AttackDie>().HasData(
                new AttackDie() { Id = 1, Name = "White", Value = 1 },
                new AttackDie() { Id = 2, Name = "White", Value = 2 },
                new AttackDie() { Id = 3, Name = "White", Value = 3 },
                new AttackDie() { Id = 4, Name = "White", Value = 4 },
                new AttackDie() { Id = 5, Name = "White", Value = 5 },
                new AttackDie() { Id = 6, Name = "White", Value = 6 },

                new AttackDie() { Id = 11, Name = "Black", Value = 1 },
                new AttackDie() { Id = 12, Name = "Black", Value = 2 },
                new AttackDie() { Id = 13, Name = "Black", Value = 3 },
                new AttackDie() { Id = 14, Name = "Black", Value = 4 },
                new AttackDie() { Id = 15, Name = "Black", Value = 5 },
                new AttackDie() { Id = 16, Name = "Black", Value = 6 },

                new AttackDie() { Id = 21, Name = "Red", Value = 1 },
                new AttackDie() { Id = 22, Name = "Red", Value = 2 },
                new AttackDie() { Id = 23, Name = "Red", Value = 3 },
                new AttackDie() { Id = 24, Name = "Red", Value = 4 },
                new AttackDie() { Id = 25, Name = "Red", Value = 5 },
                new AttackDie() { Id = 26, Name = "Red", Value = 6 }
            );
            #endregion

            #region Seed UpgradeCategories
            //premade objects for upgradecategories

            builder.Entity<UpgradeCategory>().HasData(

            new UpgradeCategory { Id = 1, Name = "Armament" },
            new UpgradeCategory { Id = 4, Name = "Command" },
            new UpgradeCategory { Id = 7, Name = "Comms" },
            new UpgradeCategory { Id = 10, Name = "Crew" },
            new UpgradeCategory { Id = 13, Name = "Force" },
            new UpgradeCategory { Id = 16, Name = "Gear" },
            new UpgradeCategory { Id = 19, Name = "Generator" },
            new UpgradeCategory { Id = 22, Name = "Grenades" },
            new UpgradeCategory { Id = 25, Name = "Hardpoint" },
            new UpgradeCategory { Id = 28, Name = "Heavy Weapon" },
            new UpgradeCategory { Id = 31, Name = "Ordnance" },
            new UpgradeCategory { Id = 34, Name = "Personnel" },
            new UpgradeCategory { Id = 37, Name = "Pilot" },
            new UpgradeCategory { Id = 40, Name = "Training" },

            new UpgradeCategory { Id = 2, Name = "Armament" },
            new UpgradeCategory { Id = 5, Name = "Command" },
            new UpgradeCategory { Id = 8, Name = "Comms" },
            new UpgradeCategory { Id = 11, Name = "Crew" },
            new UpgradeCategory { Id = 14, Name = "Force" },
            new UpgradeCategory { Id = 17, Name = "Gear" },
             new UpgradeCategory { Id = 20, Name = "Generator" },
            new UpgradeCategory { Id = 23, Name = "Grenades" },
             new UpgradeCategory { Id = 26, Name = "Hardpoint" },
             new UpgradeCategory { Id = 29, Name = "Heavy Weapon" },
            new UpgradeCategory { Id = 32, Name = "Ordnance" },
             new UpgradeCategory { Id = 35, Name = "Personnel" },
            new UpgradeCategory { Id = 38, Name = "Pilot" },
             new UpgradeCategory { Id = 41, Name = "Training" },

             new UpgradeCategory { Id = 3, Name = "Armament" },
            new UpgradeCategory { Id = 6, Name = "Command" },
            new UpgradeCategory { Id = 9, Name = "Comms" },
             new UpgradeCategory { Id = 12, Name = "Crew" },
             new UpgradeCategory { Id = 15, Name = "Force" },
             new UpgradeCategory { Id = 18, Name = "Gear" },
             new UpgradeCategory { Id = 21, Name = "Generator" },
            new UpgradeCategory { Id = 24, Name = "Grenades" },
             new UpgradeCategory { Id = 27, Name = "Hardpoint" },
             new UpgradeCategory { Id = 30, Name = "Heavy Weapon" },
            new UpgradeCategory { Id = 33, Name = "Ordnance" },
             new UpgradeCategory { Id = 36, Name = "Personnel" },
             new UpgradeCategory { Id = 39, Name = "Pilot" },
             new UpgradeCategory { Id = 42, Name = "Training" }
            );
            #endregion

            #region Seed RangeTypes
            //premade Rangetypes
            var melee = new RangeType { Id = 1, Name = "Melee" };
            var ranged = new RangeType { Id = 2, Name = "Ranged" };

            builder.Entity<RangeType>(d =>
            {
                d.HasData(melee);
                d.HasData(ranged);
            });
            #endregion

            #region Seed Factions
            //Premade Factions
            var rebel = new Faction { Id = 1, Name = "Rebel Alliance" };
            var empire = new Faction { Id = 2, Name = "Galactic Empire" };
            var separaist = new Faction { Id = 3, Name = "Separatist Alliance" };
            var clone = new Faction { Id = 4, Name = "Galactic Republic" };
            var neutral = new Faction { Id = 20, Name = "Neutral" };

            builder.Entity<Faction>(f =>
            {
                f.HasData(rebel);
                f.HasData(empire);
                f.HasData(separaist);
                f.HasData(clone);
                f.HasData(neutral);

            });
            #endregion

            #region Seed AttackSurges
            //Premade AttackSurgeOptions
            var none = new AttackSurge { Id = 1, Name = "None" };
            var hit = new AttackSurge { Id = 2, Name = "Hit" };
            var crit = new AttackSurge { Id = 3, Name = "Critical" };

            builder.Entity<AttackSurge>(d =>
            {
                d.HasData(none);
                d.HasData(hit);
                d.HasData(crit);
            });
            #endregion

            #region Seed UnitTypes
            //Premade TrooperOptions
            var trooper = new UnitType { Id = 1, Name = "Trooper" };
            var repulsorVehicle = new UnitType { Id = 2, Name = "Repulsor Vehicle" };
            var groundVehicle = new UnitType { Id = 3, Name = "Ground Vehicle" };
            var emplacementTrooper = new UnitType { Id = 4, Name = "Emplacement Trooper" };
            var creatureTropper = new UnitType { Id = 5, Name = "Creature Tropper" };
            var wookieTropper = new UnitType { Id = 6, Name = "Wookie Tropper" };
            var droidTrooper = new UnitType { Id = 7, Name = "Droid Trooper" };
            var cloneTrooper = new UnitType { Id = 8, Name = "Clone Trooper" };

            builder.Entity<UnitType>(f =>
            {
                f.HasData(trooper);
                f.HasData(repulsorVehicle);
                f.HasData(groundVehicle);
                f.HasData(emplacementTrooper);
                f.HasData(creatureTropper);
                f.HasData(wookieTropper);
                f.HasData(droidTrooper);
                f.HasData(cloneTrooper);
            });
            #endregion

            #region Seed Rank
            //Premade RankOptions
            var commander = new Rank { Id = 1, Name = "Commander" };
            var operative = new Rank { Id = 2, Name = "Operative" };
            var corps = new Rank { Id = 3, Name = "Corps" };
            var specialForces = new Rank { Id = 4, Name = "Special Forces" };
            var support = new Rank { Id = 5, Name = "Support" };
            var heavy = new Rank { Id = 6, Name = "Heavy" };

            builder.Entity<Rank>(f =>
            {
                f.HasData(commander);
                f.HasData(operative);
                f.HasData(corps);
                f.HasData(specialForces);
                f.HasData(support);
                f.HasData(heavy);
            });

            #endregion

            #region Seed Player
            //Premade Players
            var player1 = new Player { Id = 1, Name = "Henrik" };
            var player2 = new Player { Id = 2, Name = "Kenneth" };

            builder.Entity<Player>(p =>
            {
                p.HasData(player1);
                p.HasData(player2);
            });

            #endregion

            #region Seed ArmyList
            //Premade ArmyList

            var armylist1 = new Army { Id = 1, Name = "Holy Molys", FactionId = 1, PlayerId = 1, PointLimit = 800 };
            var armylist2 = new Army { Id = 2, Name = "City Bois", FactionId = 2, PlayerId = 2, PointLimit = 800 };

            builder.Entity<Army>(d =>
            {
                d.HasData(armylist1);
                d.HasData(armylist2);
            });
            #endregion

            #region Seed Keyword Database
            //Premade keywords:
            builder.Entity<Keyword>().HasData(

            new Keyword
            {
                Id = 1,
                Name = "Jump",
                AbilityValue = 1,
                Text = "Perform a move during which you ignore terrain that is height 1 or lower. This is treated as a move action.",
                IsCardAction = true,
            },
            new Keyword
            {
                Id = 2,
                Name = "Charge",
                Text = "After you perform a move action, you may perform a free melee attack action.",
            },
            new Keyword
            {
                Id = 3,
                Name = "Deflect",
                Text = "After While defending, if you spend a dodge token, you gain “Surge: Block”: if it’s a ranged attack, the attacker suffers 1 wound for each Surge rolled.",
            },
            new Keyword
            {
                Id = 4,
                Name = "Immune: Pierce",
                Text = "Pierce cannot be used against you.",
            },
            new Keyword
            {
                Id = 5,
                Name = "Impact",
                Text = "While attacking a unit that has Armor, change up to X Dice Hit.png result(s) to Dice Crit.png result(s).",
                AbilityValue = 2
            },
            new Keyword
            {
                Id = 6,
                Name = "Pierce",
                Text = "When attacking, ignore up to 2 block results.",
                AbilityValue = 2,
            },
            new Keyword
            {
                Id = 7,
                Name = "Precise 1",
                Text = "When you spend an aim token, reroll up to 1 additional die.",
                AbilityValue = 1,
            },
            new Keyword
            {
                Id = 8,
                Name = "Impact",
                Text = "While attacking a unit that has Armor, change up to X Dice Hit.png result(s) to Dice Crit.png result(s).",
                AbilityValue = 3
            },
            new Keyword
            {
                Id = 9,
                Name = "Pierce",
                Text = "When attacking, ignore up to 2 block results.",
                AbilityValue = 3,
            }

            );
            #endregion

            #region Seed Weapons Database
            //Premade weapons for Luke
            builder.Entity<Weapon>().HasData(

            new Weapon
            {
                Id = 1,
                Name = "Anakin's Lightsaber",
                RangeTypeId = 1,
            },
            new Weapon
            {
                Id = 2,
                Name = "Luke's DL-44 Blaster Pistol",
                RangeTypeId = 2,
                MinRange = 1,
                MaxRange = 2,
            },
            new Weapon
            {
                Id = 3,
                Name = "Vader's Lightsaber",
                RangeTypeId = 1
            }
            );

            #endregion

            #region Seed Upgrade Database
            //upgrades:
            builder.Entity<Upgrade>().HasData(

            new Upgrade
            {
                Id = 1,
                Name = "Force Push",
                Text = "Choose an enemy trooper unit at range 1. Perform a speed-1 move with that unit, even if it is engaged.",
                IsExhaustable = true,
                IsFreeAction = true,
                PointCost = 10,
                UpgradeCategoryId = 5
            },
            new Upgrade
            {
                Id = 2,
                Name = "Force Choke",
                Text = "Choose a non-commander, non-operative enemy trooper mini at range 1. It suffers 1 wound.",
                IsExhaustable = true,
                IsFreeAction = true,
                PointCost = 5,
                UpgradeCategoryId = 5
            },
            new Upgrade
            {
                Id = 3,
                Name = "Battle Meditation",
                Text = "While you are issuing orders using a command card, you may issue 1 of those orders to any friendly unit on the battlefield, instead of a unit indicated on the command card.",
                PointCost = 10,
                UpgradeCategoryId = 5
            },
            new Upgrade
            {
                Id = 4,
                Name = "Targeting Scopes",
                Text = "You gain Precise 1",
                PointCost = 6,
                UpgradeCategoryId = 6
            });

            #endregion

            #region Seed Unit Database
            //units:
            var lukeSkywalker = new Unit
            {
                Id = 1,
                Name = "Luke Skywalker",
                SurName = "HERO OF THE REBELLION",
                AttackSurgeId = 3,
                IsDefenseRed = true,
                Courage = 3,
                FactionId = 1,
                IsUnique = true,
                PointCost = 160,
                RankId = 1,
                WoundThreshold = 6,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var leiaOrgana = new Unit
            {
                Id = 2,
                Name = "Leia Organa",
                SurName = "FEARLESS AND INVENTIVE",
                AttackSurgeId = 3,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = true,
                PointCost = 90,
                RankId = 1,
                WoundThreshold = 6,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var rebeltrooper = new Unit
            {
                Id = 3,
                Name = "Rebel Troopers",
                AttackSurgeId = 1,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 1,
                FactionId = 1,
                IsUnique = false,
                PointCost = 40,
                RankId = 3,
                WoundThreshold = 1,
                Speed = 2,
                MinisInUnit = 4,
                UnitTypeId = 1,
            };
            var fleettrooper = new Unit
            {
                Id = 4,
                Name = "Fleet Troopers",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 1,
                FactionId = 1,
                IsUnique = false,
                PointCost = 44,
                RankId = 3,
                WoundThreshold = 1,
                Speed = 2,
                MinisInUnit = 4,
                UnitTypeId = 1,
            };
            var t47airspeeder = new Unit
            {
                Id = 5,
                Name = "T-47 Airspeeder",
                AttackSurgeId = 3,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 5,
                FactionId = 1,
                IsUnique = false,
                PointCost = 175,
                RankId = 6,
                WoundThreshold = 7,
                Speed = 3,
                MinisInUnit = 1,
                UnitTypeId = 2,
            };
            var rebelatrt = new Unit
            {
                Id = 6,
                Name = "AT-RT",
                AttackSurgeId = 3,
                IsDefenseSurge = false,
                IsDefenseRed = false,
                Courage = 4,
                FactionId = 1,
                IsUnique = false,
                PointCost = 55,
                RankId = 5,
                WoundThreshold = 6,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 3,
            };
            var rebelcommandos = new Unit
            {
                Id = 7,
                Name = "Rebel Commandos",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 60,
                RankId = 4,
                WoundThreshold = 1,
                Speed = 2,
                MinisInUnit = 4,
                UnitTypeId = 1,
            };
            var rebelcommandos2 = new Unit
            {
                Id = 8,
                Name = "Rebel Commandos",
                SurName = "Strike Team",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 16,
                RankId = 4,
                WoundThreshold = 1,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var hansolo = new Unit
            {
                Id = 9,
                Name = "Han Solo",
                SurName = "Unorthodox general",
                AttackSurgeId = 3,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = true,
                PointCost = 120,
                RankId = 1,
                WoundThreshold = 6,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var fdlasercannonteam = new Unit
            {
                Id = 10,
                Name = "1.4 FD Laser Cannon Team",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 70,
                RankId = 5,
                WoundThreshold = 6,
                Speed = 0,
                MinisInUnit = 1,
                UnitTypeId = 4,
            };
            var rebelofficer = new Unit
            {
                Id = 11,
                Name = "Rebel Officer",
                SurName = "Resolute Commander",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 50,
                RankId = 1,
                WoundThreshold = 4,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var wookiewarrior = new Unit
            {
                Id = 12,
                Name = "Wookie Warriors",
                AttackSurgeId = 2,
                IsDefenseSurge = false,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 75,
                RankId = 4,
                WoundThreshold = 3,
                Speed = 2,
                MinisInUnit = 3,
                UnitTypeId = 6,
            };
            var chewbacca = new Unit
            {
                Id = 13,
                Name = "Chewbacca",
                SurName = "walking Carpet",
                AttackSurgeId = 3,
                IsDefenseSurge = false,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = true,
                PointCost = 110,
                RankId = 2,
                WoundThreshold = 9,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 6,
            };
            var jynerso = new Unit
            {
                Id = 14,
                Name = "Jyn Erso",
                SurName = "Stardust",
                AttackSurgeId = 3,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 3,
                FactionId = 1,
                IsUnique = true,
                PointCost = 130,
                RankId = 1,
                WoundThreshold = 6,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var rebelpathfinders = new Unit
            {
                Id = 15,
                Name = "Rebel Pathfinders",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 68,
                RankId = 4,
                WoundThreshold = 1,
                Speed = 2,
                MinisInUnit = 4,
                UnitTypeId = 1,
            };
            var landspeeder = new Unit
            {
                Id = 16,
                Name = "X-34 Landspeeder",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 4,
                FactionId = 1,
                IsUnique = false,
                PointCost = 75,
                RankId = 6,
                WoundThreshold = 6,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 2,
            };
            var sabinewren = new Unit
            {
                Id = 17,
                Name = "Sabine Wren",
                SurName = "Explosive Artist",
                AttackSurgeId = 3,
                IsDefenseSurge = true,
                IsDefenseRed = true,
                Courage = 2,
                FactionId = 1,
                IsUnique = true,
                PointCost = 125,
                RankId = 2,
                WoundThreshold = 5,
                Speed = 3,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var tauntaunriders = new Unit
            {
                Id = 18,
                Name = "Tauntaun Riders",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 90,
                RankId = 5,
                WoundThreshold = 4,
                Speed = 3,
                MinisInUnit = 2,
                UnitTypeId = 5,
            };
            var rebelveterans = new Unit
            {
                Id = 19,
                Name = "Rebel Veterans",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 1,
                FactionId = 1,
                IsUnique = false,
                PointCost = 44,
                RankId = 3,
                WoundThreshold = 1,
                Speed = 2,
                MinisInUnit = 4,
                UnitTypeId = 1,
            };
            var mediumblastertrooper = new Unit
            {
                Id = 20,
                Name = "Mark II Medium Blaster Trooper",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 38,
                RankId = 3,
                WoundThreshold = 4,
                Speed = 1,
                MinisInUnit = 1,
                UnitTypeId = 4,
            };
            var lukeSkywalkeroperative = new Unit
            {
                Id = 21,
                Name = "Luke Skywalker",
                SurName = "Jedi Knight",
                AttackSurgeId = 3,
                IsDefenseRed = true,
                Courage = 4,
                FactionId = 1,
                IsUnique = true,
                PointCost = 200,
                RankId = 2,
                WoundThreshold = 7,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var r2d2 = new Unit
            {
                Id = 22,
                Name = "R2-D2",
                SurName = "Hero of Thousands Devices",
                AttackSurgeId = 2,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = true,
                PointCost = 35,
                RankId = 2,
                WoundThreshold = 4,
                Speed = 1,
                MinisInUnit = 1,
                UnitTypeId = 7,
            };
            var casisianandor = new Unit
            {
                Id = 23,
                Name = "Casisian Andor",
                SurName = "Capable Intelligence Agent",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = true,
                PointCost = 90,
                RankId = 1,
                WoundThreshold = 6,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var k2so = new Unit
            {
                Id = 24,
                Name = "K-2SO",
                SurName = "Sardonic Security Droid",
                AttackSurgeId = 3,
                IsDefenseRed = true,
                Courage = 2,
                FactionId = 1,
                IsUnique = true,
                PointCost = 70,
                RankId = 2,
                WoundThreshold = 5,
                Speed = 1,
                MinisInUnit = 1,
                UnitTypeId = 7,
            };
            var mandalorianresistance = new Unit
            {
                Id = 25,
                Name = "Mandalorian Resistance",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = true,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 72,
                RankId = 4,
                WoundThreshold = 1,
                Speed = 3,
                MinisInUnit = 3,
                UnitTypeId = 1,
            };
            var mandalorianresistanceClanWren = new Unit
            {
                Id = 26,
                Name = "Mandalorian Resistance",
                SurName = "Clan Wren",
                AttackSurgeId = 2,
                IsDefenseSurge = true,
                IsDefenseRed = true,
                Courage = 2,
                FactionId = 1,
                IsUnique = false,
                PointCost = 34,
                RankId = 4,
                WoundThreshold = 2,
                Speed = 3,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };
            var lando = new Unit
            {
                Id = 27,
                Name = "Lando Calrissian",
                SurName = "Smooth Operator",
                AttackSurgeId = 3,
                IsDefenseSurge = true,
                IsDefenseRed = false,
                Courage = 2,
                FactionId = 1,
                IsUnique = true,
                PointCost = 105,
                RankId = 1,
                WoundThreshold = 6,
                Speed = 2,
                MinisInUnit = 1,
                UnitTypeId = 1,
            };


            builder.Entity<Unit>(u =>
            {
                u.HasData(lukeSkywalker);
                u.HasData(leiaOrgana);
                u.HasData(rebeltrooper);
                u.HasData(fleettrooper);
                u.HasData(t47airspeeder);
                u.HasData(rebelatrt);
                u.HasData(rebelcommandos);
                u.HasData(rebelcommandos2);
                u.HasData(hansolo);
                u.HasData(fdlasercannonteam);
                u.HasData(rebelofficer);
                u.HasData(wookiewarrior);
                u.HasData(chewbacca);
                u.HasData(jynerso);
                u.HasData(rebelpathfinders);
                u.HasData(landspeeder);
                u.HasData(sabinewren);
                u.HasData(tauntaunriders);
                u.HasData(rebelveterans);
                u.HasData(mediumblastertrooper);
                u.HasData(lukeSkywalkeroperative);
                u.HasData(r2d2);
                u.HasData(casisianandor);
                u.HasData(k2so);
                u.HasData(mandalorianresistance);
                u.HasData(mandalorianresistanceClanWren);
                u.HasData(lando);



            });

            // SEED Imperial Units
            builder.Entity<Unit>().HasData(
               new Unit
               {
                   Id = 50,
                   Name = "Darth Vader",
                   SurName = "DARK LORD OF THE SITH",
                   AttackSurgeId = 1,
                   IsDefenseRed = false,
                   Courage = 0,
                   FactionId = 2,
                   IsUnique = true,
                   PointCost = 200,
                   RankId = 1,
                   WoundThreshold = 8,
                   Speed = 1,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 51,
                   Name = "Storm Trooper",
                   AttackSurgeId = 2,
                   IsDefenseRed = true,
                   Courage = 1,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 44,
                   RankId = 3,
                   WoundThreshold = 1,
                   Speed = 2,
                   MinisInUnit = 4,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 52,
                   Name = "General Veers",
                   SurName = "Master Tactician",
                   AttackSurgeId = 3,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = true,
                   PointCost = 80,
                   RankId = 1,
                   WoundThreshold = 5,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 53,
                   Name = "AT-ST",
                   AttackSurgeId = 1,
                   IsDefenseSurge = true,
                   IsDefenseRed = false,
                   Courage = 8,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 195,
                   RankId = 6,
                   WoundThreshold = 11,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 3,
               },
               new Unit
               {
                   Id = 54,
                   Name = "74-Z Speeder Bikes",
                   AttackSurgeId = 2,
                   IsDefenseSurge = false,
                   IsDefenseRed = false,
                   Courage = 0,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 90,
                   RankId = 5,
                   WoundThreshold = 3,
                   Speed = 3,
                   MinisInUnit = 2,
                   UnitTypeId = 2,
               },
               new Unit
               {
                   Id = 55,
                   Name = "E-Web Heavy Blaster Team",
                   AttackSurgeId = 3,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 55,
                   RankId = 5,
                   WoundThreshold = 4,
                   Speed = 1,
                   MinisInUnit = 1,
                   UnitTypeId = 4,
               },
               new Unit
               {
                   Id = 56,
                   Name = "Imperial Royal Guards",
                   AttackSurgeId = 1,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 1,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 44,
                   RankId = 3,
                   WoundThreshold = 1,
                   Speed = 2,
                   MinisInUnit = 4,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 57,
                   Name = "Scout Trooper",
                   SurName = "Strike Team",
                   AttackSurgeId = 1,
                   IsDefenseSurge = true,
                   IsDefenseRed = false,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 16,
                   RankId = 4,
                   WoundThreshold = 1,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 58,
                   Name = "Scout Trooper",
                   AttackSurgeId = 1,
                   IsDefenseSurge = true,
                   IsDefenseRed = false,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 60,
                   RankId = 4,
                   WoundThreshold = 1,
                   Speed = 2,
                   MinisInUnit = 4,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 59,
                   Name = "Director Orson Krennic",
                   AttackSurgeId = 3,
                   IsDefenseSurge = true,
                   IsDefenseRed = false,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = true,
                   PointCost = 90,
                   RankId = 1,
                   WoundThreshold = 6,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 60,
                   Name = "Imperial Death Trooper",
                   AttackSurgeId = 2,
                   IsDefenseSurge = true,
                   IsDefenseRed = true,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 76,
                   RankId = 3,
                   WoundThreshold = 1,
                   Speed = 2,
                   MinisInUnit = 4,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 61,
                   Name = "Bossk",
                   AttackSurgeId = 3,
                   IsDefenseSurge = false,
                   IsDefenseRed = false,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = true,
                   PointCost = 115,
                   RankId = 2,
                   WoundThreshold = 7,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 62,
                   Name = "Emperor Palpatine",
                   SurName = "Ruler of The Galactic Empire",
                   AttackSurgeId = 3,
                   IsDefenseSurge = true,
                   IsDefenseRed = true,
                   Courage = 4,
                   FactionId = 2,
                   IsUnique = true,
                   PointCost = 210,
                   RankId = 1,
                   WoundThreshold = 5,
                   Speed = 1,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 74,
                   Name = "Imperial Officer",
                   AttackSurgeId = 2,
                   IsDefenseSurge = true,
                   IsDefenseRed = false,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 50,
                   RankId = 1,
                   WoundThreshold = 4,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 63,
                   Name = "Snowtrooper",
                   AttackSurgeId = 2,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 1,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 48,
                   RankId = 3,
                   WoundThreshold = 1,
                   Speed = 1,
                   MinisInUnit = 4,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 64,
                   Name = "TX-225 GAVw Occupier Combat Assault Tank",
                   AttackSurgeId = 1,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 6,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 155,
                   RankId = 6,
                   WoundThreshold = 8,
                   Speed = 1,
                   MinisInUnit = 1,
                   UnitTypeId = 3,
               },
               new Unit
               {
                   Id = 65,
                   Name = "Shoretrooper",
                   AttackSurgeId = 1,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 1,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 52,
                   RankId = 3,
                   WoundThreshold = 1,
                   Speed = 2,
                   MinisInUnit = 4,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 66,
                   Name = "Iden Versio",
                   AttackSurgeId = 2,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 3,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 100,
                   RankId = 1,
                   WoundThreshold = 6,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 67,
                   Name = "Dewback Rider",
                   AttackSurgeId = 2,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 90,
                   RankId = 5,
                   WoundThreshold = 6,
                   Speed = 1,
                   MinisInUnit = 1,
                   UnitTypeId = 5,
               },
               new Unit
               {
                   Id = 68,
                   Name = "DF-90 Mortar Trooper",
                   AttackSurgeId = 1,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 36,
                   RankId = 3,
                   WoundThreshold = 3,
                   Speed = 1,
                   MinisInUnit = 1,
                   UnitTypeId = 4,
               },
               new Unit
               {
                   Id = 69,
                   Name = "Imperial Special Forces",
                   AttackSurgeId = 2,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 68,
                   RankId = 3,
                   WoundThreshold = 1,
                   Speed = 2,
                   MinisInUnit = 4,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 70,
                   Name = "Imperial Special Forces",
                   SurName = "Inferno Squad",
                   AttackSurgeId = 2,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = false,
                   PointCost = 34,
                   RankId = 3,
                   WoundThreshold = 2,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 71,
                   Name = "Boba Fett",
                   SurName = "Infamous Bounty Hunter",
                   AttackSurgeId = 3,
                   IsDefenseSurge = true,
                   IsDefenseRed = true,
                   Courage = 3,
                   FactionId = 2,
                   IsUnique = true,
                   PointCost = 140,
                   RankId = 2,
                   WoundThreshold = 5,
                   Speed = 3,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 72,
                   Name = "Darth Vader",
                   SurName = "The Emperor's Apprentice",
                   AttackSurgeId = 1,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 3,
                   FactionId = 2,
                   IsUnique = true,
                   PointCost = 170,
                   RankId = 2,
                   WoundThreshold = 6,
                   Speed = 1,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               },
               new Unit
               {
                   Id = 73,
                   Name = "Agent Kallus",
                   AttackSurgeId = 3,
                   IsDefenseSurge = false,
                   IsDefenseRed = true,
                   Courage = 2,
                   FactionId = 2,
                   IsUnique = true,
                   PointCost = 90,
                   RankId = 1,
                   WoundThreshold = 6,
                   Speed = 2,
                   MinisInUnit = 1,
                   UnitTypeId = 1,
               });
            #endregion

            #region Seed Chosen Units
            builder.Entity<ChosenUnit>().HasData(
                new ChosenUnit { Id = 10, ArmyId = 1, UnitId = 1, UnitRankId = 1 },
                new ChosenUnit { Id = 11, ArmyId = 1, UnitId = 3, UnitRankId = 3 },
                new ChosenUnit { Id = 12, ArmyId = 1, UnitId = 3, UnitRankId = 3 },
                new ChosenUnit { Id = 13, ArmyId = 2, UnitId = 50, UnitRankId = 1 }
            );
            #endregion

            #region Seed Chosen Upgrades
            builder.Entity<ChosenUpgrade>().HasData(
                new ChosenUpgrade { Id = 20, UpgradeId = 1, ChosenUnitId = 10 },
                new ChosenUpgrade { Id = 21, UpgradeId = 3, ChosenUnitId = 10 },
                new ChosenUpgrade { Id = 22, UpgradeId = 4, ChosenUnitId = 11 },
                new ChosenUpgrade { Id = 24, UpgradeId = 2, ChosenUnitId = 13 }
            );
            #endregion

            #region Many to Many Relations
            //Seed M2M units keywords - Add keywords to units
            builder
                .Entity<Unit>()
                .HasMany(p => p.Keywords)
                .WithMany(p => p.Units)
                .UsingEntity(j =>
                {
                    j.HasData(new { UnitsId = 1, KeywordsId = 1 }); //jump
                    j.HasData(new { UnitsId = 1, KeywordsId = 2 }); //Charge
                    j.HasData(new { UnitsId = 1, KeywordsId = 3 }); //Deflect
                    j.HasData(new { UnitsId = 1, KeywordsId = 4 }); //ImmunePierce

                    j.HasData(new { UnitsId = 50, KeywordsId = 3 }); //Deflect
                    j.HasData(new { UnitsId = 50, KeywordsId = 4 }); //ImmunePierce
                });

            //Seed M2M Units Weapons - Add weapons to units
            builder
                .Entity<Unit>()
                .HasMany(u => u.Weapons)
                .WithMany(w => w.Units)
                .UsingEntity(j =>
                {
                    j.HasData(new { UnitsId = 1, WeaponsId = 1 }); //luke - lukes saber
                    j.HasData(new { UnitsId = 1, WeaponsId = 2 }); //luke - lukes blaster

                    j.HasData(new { UnitsId = 50, WeaponsId = 3 }); //luke - lukes saber
                });

            //Seed M2M Units UpgradeCategories - Add Upgradecategories to Units
            builder
                .Entity<Unit>()
                .HasMany(u => u.UpgradeCategories)
                .WithMany(uc => uc.Units)
                .UsingEntity(j =>
                {
                    j.HasData(new { UnitsId = 1, UpgradeCategoriesId = 13 }); //luke - Force1
                    j.HasData(new { UnitsId = 1, UpgradeCategoriesId = 14 }); //luke - Force2
                    j.HasData(new { UnitsId = 1, UpgradeCategoriesId = 16 }); //luke - Gear1

                    j.HasData(new { UnitsId = 50, UpgradeCategoriesId = 13 }); //vader - Force1
                    j.HasData(new { UnitsId = 50, UpgradeCategoriesId = 14 }); //vader - Force2
                    j.HasData(new { UnitsId = 50, UpgradeCategoriesId = 15 }); //vader - Force3
                });

            //Seed M2M Weapons AttackDie - Add Attackdie to Weapons
            builder
                .Entity<Weapon>()
                .HasMany(w => w.AttackDie)
                .WithMany(a => a.Weapons)
                .UsingEntity(j =>
                {
                    j.HasData(new { WeaponsId = 1, AttackDieId = 16 }); //lukes saber - 6_Black
                    j.HasData(new { WeaponsId = 2, AttackDieId = 22 }); //lukes saber - 2_Red

                    j.HasData(new { WeaponsId = 3, AttackDieId = 26 }); //vader saber - 6_Red

                });

            //Seed M2M Weapons Keywords - Add keywords to Weapons
            builder
                .Entity<Weapon>()
                .HasMany(w => w.Keywords)
                .WithMany(u => u.Weapons)
                .UsingEntity(j =>
                {
                    j.HasData(new { WeaponsId = 1, KeywordsId = 6 }); //lukes saber - pierce2
                    j.HasData(new { WeaponsId = 1, KeywordsId = 5 }); //lukes saber - impact2
                    j.HasData(new { WeaponsId = 2, KeywordsId = 6 }); //lukes blaster - impact2

                    j.HasData(new { WeaponsId = 3, KeywordsId = 8 }); //vaders saber - pierce3
                    j.HasData(new { WeaponsId = 3, KeywordsId = 9 }); //vaders saber - impact3
                });

            //Seed M2M Upgrades Keywords - Add keywords to Upgrades
            builder
                .Entity<Upgrade>()
                .HasMany(u => u.Keywords)
                .WithMany(k => k.Upgrades)
                .UsingEntity(j =>
                {
                    j.HasData(new { UpgradesId = 4, KeywordsId = 7 }); //Targeting Scopes - Precise 1

                });



            #endregion
        }
    }
}

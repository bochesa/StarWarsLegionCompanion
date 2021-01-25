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
            var wd1 = new AttackDie() { Id = 1, Name = "White", Value = 1 };
            var wd2 = new AttackDie() { Id = 2, Name = "White", Value = 2 };
            var wd3 = new AttackDie() { Id = 3, Name = "White", Value = 3 };
            var wd4 = new AttackDie() { Id = 4, Name = "White", Value = 4 };
            var wd5 = new AttackDie() { Id = 5, Name = "White", Value = 5 };
            var wd6 = new AttackDie() { Id = 6, Name = "White", Value = 6 };

            var bd1 = new AttackDie() { Id = 11, Name = "Black", Value = 1 };
            var bd2 = new AttackDie() { Id = 12, Name = "Black", Value = 2 };
            var bd3 = new AttackDie() { Id = 13, Name = "Black", Value = 3 };
            var bd4 = new AttackDie() { Id = 14, Name = "Black", Value = 4 };
            var bd5 = new AttackDie() { Id = 15, Name = "Black", Value = 5 };
            var bd6 = new AttackDie() { Id = 16, Name = "Black", Value = 6 };

            var rd1 = new AttackDie() { Id = 21, Name = "Red", Value = 1 };
            var rd2 = new AttackDie() { Id = 22, Name = "Red", Value = 2 };
            var rd3 = new AttackDie() { Id = 23, Name = "Red", Value = 3 };
            var rd4 = new AttackDie() { Id = 24, Name = "Red", Value = 4 };
            var rd5 = new AttackDie() { Id = 25, Name = "Red", Value = 5 };
            var rd6 = new AttackDie() { Id = 26, Name = "Red", Value = 6 };

        builder.Entity<AttackDie>(d =>
            {
                d.HasData(wd1);
                d.HasData(wd2);
                d.HasData(wd3);
                d.HasData(wd4);
                d.HasData(wd5);
                d.HasData(wd6);

                d.HasData(bd1);
                d.HasData(bd2);
                d.HasData(bd3);
                d.HasData(bd4);
                d.HasData(bd5);
                d.HasData(bd6);

                d.HasData(rd1);
                d.HasData(rd2);
                d.HasData(rd3);
                d.HasData(rd4);
                d.HasData(rd5);
                d.HasData(rd6);
            });
            #endregion

           

            #region Seed UpgradeCategories
            //            //premade objects for upgradecategories
            //            var armament = new UpgradeCategory { Id = 1, Name = "Armament" };
            //    var command = new UpgradeCategory { Id = 2, Name = "Command" };
            //    var comms = new UpgradeCategory { Id = 3, Name = "Comms" };
            //    var crew = new UpgradeCategory { Id = 4, Name = "Crew" };
            //    var force = new UpgradeCategory { Id = 5, Name = "Force" };
            //    var gear = new UpgradeCategory { Id = 6, Name = "Gear" };
            //    var generator = new UpgradeCategory { Id = 7, Name = "Generator" };
            //    var grenades = new UpgradeCategory { Id = 8, Name = "Grenades" };
            //    var hardpoint = new UpgradeCategory { Id = 9, Name = "Hardpoint" };
            //    var heavyWeapon = new UpgradeCategory { Id = 10, Name = "Heavy Weapon" };
            //    var ordnance = new UpgradeCategory { Id = 11, Name = "Ordnance" };
            //    var personnel = new UpgradeCategory { Id = 12, Name = "Personnel" };
            //    var pilot = new UpgradeCategory { Id = 13, Name = "Pilot" };
            //    var training = new UpgradeCategory { Id = 14, Name = "Training" };

            //    var armament2 = new UpgradeCategory { Id = 15, Name = "Armament" };
            //    var command2 = new UpgradeCategory { Id = 16, Name = "Command" };
            //    var comms2 = new UpgradeCategory { Id = 17, Name = "Comms" };
            //    var crew2 = new UpgradeCategory { Id = 18, Name = "Crew" };
            //    var force2 = new UpgradeCategory { Id = 19, Name = "Force" };
            //    var gear2 = new UpgradeCategory { Id = 20, Name = "Gear" };
            //    var generator2 = new UpgradeCategory { Id = 21, Name = "Generator" };
            //    var grenades2 = new UpgradeCategory { Id = 22, Name = "Grenades" };
            //    var hardpoint2 = new UpgradeCategory { Id = 23, Name = "Hardpoint" };
            //    var heavyWeapon2 = new UpgradeCategory { Id = 24, Name = "Heavy Weapon" };
            //    var ordnance2 = new UpgradeCategory { Id = 25, Name = "Ordnance" };
            //    var personnel2 = new UpgradeCategory { Id = 26, Name = "Personnel" };
            //    var pilot2 = new UpgradeCategory { Id = 27, Name = "Pilot" };
            //    var training2 = new UpgradeCategory { Id = 28, Name = "Training" };

            //    var armament3 = new UpgradeCategory { Id = 29, Name = "Armament" };
            //    var command3 = new UpgradeCategory { Id = 30, Name = "Command" };
            //    var comms3 = new UpgradeCategory { Id = 31, Name = "Comms" };
            //    var crew3 = new UpgradeCategory { Id = 32, Name = "Crew" };
            //    var force3 = new UpgradeCategory { Id = 33, Name = "Force" };
            //    var gear3 = new UpgradeCategory { Id = 34, Name = "Gear" };
            //    var generator3 = new UpgradeCategory { Id = 35, Name = "Generator" };
            //    var grenades3 = new UpgradeCategory { Id = 36, Name = "Grenades" };
            //    var hardpoint3 = new UpgradeCategory { Id = 37, Name = "Hardpoint" };
            //    var heavyWeapon3 = new UpgradeCategory { Id = 38, Name = "Heavy Weapon" };
            //    var ordnance3 = new UpgradeCategory { Id = 39, Name = "Ordnance" };
            //    var personnel3 = new UpgradeCategory { Id = 40, Name = "Personnel" };
            //    var pilot3 = new UpgradeCategory { Id = 41, Name = "Pilot" };
            //    var training3 = new UpgradeCategory { Id = 42, Name = "Training" };

            //    builder.Entity<UpgradeCategory>(u =>
            //            {
            //                u.HasData(armament);
            //                u.HasData(command);
            //                u.HasData(comms);
            //                u.HasData(crew);
            //                u.HasData(force);
            //                u.HasData(gear);
            //                u.HasData(generator);
            //                u.HasData(grenades);
            //                u.HasData(hardpoint);
            //                u.HasData(heavyWeapon);
            //                u.HasData(ordnance);
            //                u.HasData(personnel);
            //                u.HasData(pilot);
            //                u.HasData(training);
            //                u.HasData(armament2);
            //                u.HasData(command2);
            //                u.HasData(comms2);
            //                u.HasData(crew2);
            //                u.HasData(force2);
            //                u.HasData(gear2);
            //                u.HasData(generator2);
            //                u.HasData(grenades2);
            //                u.HasData(hardpoint2);
            //                u.HasData(heavyWeapon2);
            //                u.HasData(ordnance2);
            //                u.HasData(personnel2);
            //                u.HasData(pilot2);
            //                u.HasData(training2);
            //                u.HasData(armament3);
            //                u.HasData(command3);
            //                u.HasData(comms3);
            //                u.HasData(crew3);
            //                u.HasData(force3);
            //                u.HasData(gear3);
            //                u.HasData(generator3);
            //                u.HasData(grenades3);
            //                u.HasData(hardpoint3);
            //                u.HasData(heavyWeapon3);
            //                u.HasData(ordnance3);
            //                u.HasData(personnel3);
            //                u.HasData(pilot3);
            //                u.HasData(training3);
            //            });
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

            //DefenseDie is Obsolete - may come back
            #region Seed DefenseDie
            //premade DefenseDie
            //var defWhite = new DefenseDie { Id = 1, Name = "White" };
            //var defRed = new DefenseDie { Id = 2, Name = "Red" };

            //builder.Entity<DefenseDie>(d =>
            //{
            //    d.HasData(defWhite);
            //    d.HasData(defRed);
            //});
            #endregion

            #region Seed Factions
            //Premade Factions
            var neutral = new Faction { Id = 1, Name = "Neutral" };
            var rebel = new Faction { Id = 2, Name = "Rebel Alliance" };
            var empire = new Faction { Id = 3, Name = "Galactic Empire" };
            var separaist = new Faction { Id = 4, Name = "Separatist Alliance" };
            var clone = new Faction { Id = 5, Name = "Galactic Republic" };

            builder.Entity<Faction>(f =>
            {
                f.HasData(neutral);
                f.HasData(rebel);
                f.HasData(empire);
                f.HasData(separaist);
                f.HasData(clone);

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

            #region Seed Trooper
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

            var armylist1 = new Army { Id = 1, Name = "Holy Molys", FactionId = 2, PlayerId = 1, PointLimit = 800 };
            var armylist2 = new Army { Id = 2, Name = "City Bois", FactionId = 3, PlayerId = 2, PointLimit = 800 };

            builder.Entity<Army>(d =>
            {
                d.HasData(armylist1);
                d.HasData(armylist2);
            });
            #endregion

            #region Seed Keyword Database
            //Premade keywords:
            var jump1 = new Keyword
            {
                Id = 1,
                Name = "Jump",
                AbilityValue = 1,
                Text = "Perform a move during which you ignore terrain that is height 1 or lower. This is treated as a move action.",
                IsCardAction = true,
            };
            var charge = new Keyword
            {
                Id = 2,
                Name = "Charge",
                Text = "After you perform a move action, you may perform a free melee attack action.",
            };
            var deflect = new Keyword
            {
                Id = 3,
                Name = "Deflect",
                Text = "After While defending, if you spend a dodge token, you gain “Surge: Block”: if it’s a ranged attack, the attacker suffers 1 wound for each Surge rolled.",
            };
            var immunePierce = new Keyword
            {
                Id = 4,
                Name = "Immune: Pierce",
                Text = "Pierce cannot be used against you.",
            };
            var impact2 = new Keyword
            {
                Id = 5,
                Name = "Impact",
                Text = "While attacking a unit that has Armor, change up to X Dice Hit.png result(s) to Dice Crit.png result(s).",
                AbilityValue = 2
            };
            var pierce2 = new Keyword
            {
                Id = 6,
                Name = "Pierce",
                Text = "When attacking, ignore up to 2 block results.",
                AbilityValue = 2,
            };
            var precise1 = new Keyword
            {
                Id = 7,
                Name = "Precise 1",
                Text = "When you spend an aim token, reroll up to 1 additional die.",
                AbilityValue = 1,
            };

            builder.Entity<Keyword>(k =>
            {
                k.HasData(jump1);
                k.HasData(charge);
                k.HasData(deflect);
                k.HasData(immunePierce);
                k.HasData(impact2);
                k.HasData(pierce2);
                k.HasData(precise1);
            });
            #endregion

            #region Seed Weapons Database
            //Premade weapons for Luke
            var lukeSaber = new Weapon
            {
                Id = 1,
                Name = "Anakin's Lightsaber",
                RangeTypeId = 1,
            };
            var lukesBlaster = new Weapon
            {
                Id = 2,
                Name = "Luke's DL-44 Blaster Pistol",
                RangeTypeId = 2,
                MinRange = 1,
                MaxRange = 2,
            };

            builder.Entity<Weapon>(w =>
            {
                w.HasData(lukesBlaster);
                w.HasData(lukeSaber);
            });

            #endregion

            //#region Seed Upgrade Database
            ////upgrades:
            //var forcepush = new Upgrade
            //{
            //    Id = 1,
            //    Name = "Force Push",
            //    Text = "Choose an enemy trooper unit at range 1. Perform a speed-1 move with that unit, even if it is engaged.",
            //    IsExhausable = true,
            //    IsFreeAction = true,
            //    PointCost = 10,
            //    UpgradeCategoryId = 5
            //};
            //var forceChoke = new Upgrade
            //{
            //    Id = 2,
            //    Name = "Force Choke",
            //    Text = "Choose a non-commander, non-operative enemy trooper mini at range 1. It suffers 1 wound.",
            //    IsExhausable = true,
            //    IsFreeAction = true,
            //    PointCost = 5,
            //    //Factions = { empire, separaist },
            //    UpgradeCategoryId = 5
            //};
            //var battleMeditation = new Upgrade
            //{
            //    Id = 3,
            //    Name = "Battle Meditation",
            //    Text = "While you are issuing orders using a command card, you may issue 1 of those orders to any friendly unit on the battlefield, instead of a unit indicated on the command card.",
            //    PointCost = 10,
            //    UpgradeCategoryId = 5
            //};
            //var targetingScopes = new Upgrade
            //{
            //    Id = 4,
            //    Name = "Targeting Scopes",
            //    Text = "You gain Precise 1",
            //    //Keywords = new List<Keyword>() { precise1 },
            //    PointCost = 6,
            //    UpgradeCategoryId = 6
            //};
            //builder.Entity<Upgrade>(u =>
            //{
            //    u.HasData(forcepush);
            //    u.HasData(battleMeditation);
            //    u.HasData(targetingScopes);
            //});

            //#endregion
            
            //units:
            var lukeSkywalker = new Unit
            {
                Id = 1,
                Name = "Luke Skywalker",
                SurName = "HERO OF THE REBELLION",
                AttackSurgeId = 3,
                IsDefenseRed = true,
                Courage = 3,
                FactionId = 2,
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
                FactionId = 2,
                IsUnique = true,
                PointCost = 90,
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
            });

            //     modelBuilder.Entity<Category>().HasData(
            //    new Category { Id = 1, Name = "Active Wear - Men" },
            //    new Category { Id = 2, Name = "Active Wear - Women" },
            //    new Category { Id = 3, Name = "Mineral Water" },
            //    new Category { Id = 4, Name = "Publications" },
            //    new Category { Id = 5, Name = "Supplements" });

            //modelBuilder.Entity<Product>().HasData(
            //    new Product { Id = 1, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68, IsAvailable = true },
            //    new Product { Id = 2, CategoryId = 1, Name = "Polo Shirt", Sku = "AWMPS", Price = 35, IsAvailable = true },
        }
    }
}

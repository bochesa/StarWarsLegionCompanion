using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Application.Handlers;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Services
{
    public class DTOServices : IDTOServices
    {
        private readonly IUnitOfWork _uow;

        public DTOServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ICollection<OutUpgradeOptionDTO> CreateListOfOutUpgradeOptionsDTO(ICollection<UpgradeOption> unitUpgradeOptions)
        {
            var upgradeoptions = new List<OutUpgradeOptionDTO>();
            foreach (var upgradeOption in unitUpgradeOptions)
            {
                var dto = new OutUpgradeOptionDTO
                {
                    UpgradeOptionId = upgradeOption.UpgradeOptionId,
                    UpgradeType = Enum.GetName(typeof(UpgradeType), upgradeOption.UpgradeType)

                };
                upgradeoptions.Add(dto);
            }
            return upgradeoptions;
        }

        public ICollection<OutKeywordDTO> CreateListOfOutKeywordsDTO(ICollection<Keyword> requestKeywords)
        {
            var keywords = new List<OutKeywordDTO>();
            foreach (var keyword in requestKeywords)
            {
                var keywordDto = new OutKeywordDTO
                {
                    AbilityValue = keyword.AbilityValue,
                    ActionType = Enum.GetName(typeof(ActionType), keyword.ActionType),
                    Name = keyword.Name,
                    ShortDescription = keyword.ShortDescription
                };
                keywords.Add(keywordDto);
            }
            return keywords;
        }

        public ICollection<OutWeaponDTO> CreateListOfOutWeaponsDTO(ICollection<Weapon> requestWeapons)
        {
            var weapons = new List<OutWeaponDTO>();
            foreach (var weapon in requestWeapons)
            {
                var dto = new OutWeaponDTO
                {
                    //AttackValue = item.AttackValue,
                    MaxRange = weapon.MaxRange,
                    MinRange = weapon.MinRange,
                    Name = weapon.Name,
                    RangeType = Enum.GetName(typeof(RangeType), weapon.RangeType),
                    AttackValue = new AttackValueDTO
                    {
                        BlackDie = weapon.AttackValue.BlackDie,
                        RedDie = weapon.AttackValue.RedDie,
                        WhiteDie = weapon.AttackValue.WhiteDie
                    }
                };
                var weaponsKeywords = CreateListOfOutKeywordsDTO(weapon.Keywords);

                dto.Keywords = weaponsKeywords;
                weapons.Add(dto);
            }
            return weapons;
        }
        public OutWeaponDTO CreateOutWeaponsDTO(Weapon weapon)
        {
            OutWeaponDTO weaponDto = new OutWeaponDTO();
            if (weapon is not null)
            {
                weaponDto.Name = weapon.Name;
                weaponDto.AttackValue = new AttackValueDTO
                {
                    BlackDie = weapon.AttackValue.BlackDie,
                    RedDie = weapon.AttackValue.RedDie,
                    WhiteDie = weapon.AttackValue.WhiteDie,
                };
                weaponDto.AttackSurge = Enum.GetName(typeof(AttackSurge), weapon.AttackSurge);
                weaponDto.MaxRange = weapon.MaxRange;
                weaponDto.MinRange = weapon.MinRange;
                weaponDto.RangeType = Enum.GetName(typeof(RangeType), weapon.RangeType);
                weaponDto.Keywords = CreateListOfOutKeywordsDTO(weapon.Keywords);
            }

            return weaponDto;
        }


        // In DTO Section:
        public ICollection<UpgradeOption> PostListOfUpgradeOptions(IEnumerable<InUpgradeOptionDTO> requestUpgradeOptions)
        {
            var upgradeOptions = new List<UpgradeOption>();

            // loop through UpgradeCategories and convert UpgradeOptionDTO to UpgradeOption if there are any
            if (requestUpgradeOptions.Count() != 0)
            {
                foreach (var upgradeOptionDto in requestUpgradeOptions)
                {
                    var upgradeOption = new UpgradeOption
                    {
                        UpgradeOptionId = upgradeOptionDto.UpgradeOptionId,
                        UpgradeType = (UpgradeType)upgradeOptionDto.UpgradeType
                    };

                    upgradeOptions.Add(upgradeOption);
                }

            }

            return upgradeOptions;
        }

        public async Task<ICollection<Keyword>> PostListOfKeywords(IEnumerable<InKeywordDTO> requestKeywords)
        {
            var keywords = new List<Keyword>();
            // loop through Keywords and convert KeywordDTO to keyword if there are any
            if (requestKeywords.Count() != 0)
            {
                //Loop through all Keywords and add each one, or add the reference for an existing weapon
                foreach (var keywordDto in requestKeywords)
                {
                    Keyword keyword = await _uow.Keywords.GetKeywordByName(keywordDto.Name);

                    if (keyword is null)
                    {
                        keyword = new Keyword();
                        keyword.Name = keywordDto.Name;
                        keyword.AbilityValue = keywordDto.AbilityValue;
                        keyword.ActionType = (ActionType)keywordDto.ActionType;
                        keyword.ShortDescription = keywordDto.ShortDescription;

                    }

                    keywords.Add(keyword);
                }
            }

            return keywords;
        }

        public async Task<ICollection<Weapon>> PostListOfWeapons(IEnumerable<InWeaponDTO> requestWeapons)
        {
            var weapons = new List<Weapon>();

            if (requestWeapons.Count() != 0)
            {
                //Loop through all keywords and add each one, or add the reference for an existing weapon
                foreach (var weaponDto in requestWeapons)
                {
                    Weapon weapon = await _uow.Weapons.GetWeaponByName(weaponDto.Name);
                    // if weaponExists is true build the weapon - This might be deprecated in the future, it might be better to add Weapons on its own
                    if (weapon is null)
                    {
                        weapon = new Weapon();
                        weapon.Name = weaponDto.Name;
                        weapon.AttackSurge = (AttackSurge)weaponDto.AttackSurge;
                        weapon.RangeType = (RangeType)weaponDto.RangeType;
                        weapon.MaxRange = weaponDto.MaxRange;
                        weapon.MinRange = weaponDto.MinRange;
                        weapon.AttackValue = new AttackValue
                        {
                            BlackDie = weaponDto.AttackValue.BlackDie,
                            RedDie = weaponDto.AttackValue.RedDie,
                            WhiteDie = weaponDto.AttackValue.WhiteDie
                        };
                        // loop through Keywords and convert KeywordDTO to keyword if there are any
                        if (weaponDto.Keywords.Count() != 0)
                        {
                            weapon.Keywords = await PostListOfKeywords(weaponDto.Keywords);
                        }
                    }

                    weapons.Add(weapon);
                }
            }

            return weapons;
        }
        public async Task<Weapon> PostWeapon(InWeaponDTO requestWeapon)
        {
            Weapon weapon = await _uow.Weapons.GetWeaponByName(requestWeapon.Name);
            if (weapon is null)
            {
                weapon = new Weapon();
                weapon.MaxRange = requestWeapon.MaxRange;
                weapon.MinRange = requestWeapon.MinRange;
                weapon.Name = requestWeapon.Name;
                weapon.AttackSurge = (AttackSurge)requestWeapon.AttackSurge;
                weapon.RangeType = (RangeType)requestWeapon.RangeType;
                weapon.AttackValue = new AttackValue
                {
                    BlackDie = requestWeapon.AttackValue.BlackDie,
                    RedDie = requestWeapon.AttackValue.RedDie,
                    WhiteDie = requestWeapon.AttackValue.WhiteDie
                };

                if (requestWeapon.Keywords.Count() != 0)
                {
                    weapon.Keywords = await PostListOfKeywords(requestWeapon.Keywords);
                }
            }

            return weapon;
        }

        public ICollection<OutCommandDTO> GetCommandsForArmy(IEnumerable<ChosenCommand> armyChosenCommands)
        {
            List<OutCommandDTO> commands = new();

            foreach (var command in armyChosenCommands)
            {
                var commandDto = new OutCommandDTO();
                commandDto.ChosenCommandId = command.Id;
                commandDto.CommandId = command.Command.Id;
                commandDto.Name = command.Command.Name;
                commands.Add(commandDto);
            }

            return commands;
        }

        public ICollection<OutUpgradeDTO> GetChosenUpgradesForUnit(IEnumerable<ChosenUpgrade> unitChosenUpgrades)
        {
            List<OutUpgradeDTO> upgrades = new();

            foreach (var upgrade in unitChosenUpgrades)
            {
                var upgradeDto = new OutUpgradeDTO
                {
                    ChosenUpgradeId = upgrade.Id,
                    Name = upgrade.Upgrade.Name,
                    PointCost = upgrade.Upgrade.PointCost,
                    UpgradeType = Enum.GetName(typeof(UpgradeType), upgrade.Upgrade.UpgradeType)
                };
                upgrades.Add(upgradeDto);
            }

            return upgrades;
        }

        public ICollection<OutUnitDTO> GetChosenUnitsForArmy(IEnumerable<ChosenUnit> armyChosenUnits)
        {
            List<OutUnitDTO> units = new();

            foreach (var unit in armyChosenUnits)
            {
                var unitDto = new OutUnitDTO
                {
                    ChosenUnitId = unit.Id,
                    UnitId = unit.UnitId,
                    Name = unit.Unit.Name,
                    PointCost = unit.Unit.PointCost,
                    Rank = Enum.GetName(typeof(RankType), unit.Unit.Rank)
                };

                //if (unit.ChosenUpgrades.Count != 0)
                //{
                //    ICollection<OutUpgradeDTO> upgrades = GetChosenUpgradesForUnit(unit.ChosenUpgrades);
                //    unitDto.Upgrades = upgrades;
                //}
                units.Add(unitDto);
            }

            return units;
        }

        public ICollection<OutUpgradeDTO> GetChosenUpgradesForArmy(IEnumerable<ChosenUpgrade> armyChosenUpgrades)
        {
            List<OutUpgradeDTO> upgrades = new();

            foreach (var upgrade in armyChosenUpgrades)
            {
                var upgradeDto = new OutUpgradeDTO
                {
                    ChosenUpgradeId= upgrade.Id,
                    Name = upgrade.Upgrade.Name,
                    PointCost = upgrade.Upgrade.PointCost,
                    ChosenUpgradeOption = upgrade.ChosenUpgradeOption,
                    UpgradeType = Enum.GetName(typeof(UpgradeType), upgrade.UpgradeType)
                };

                //if (unit.ChosenUpgrades.Count != 0)
                //{
                //    ICollection<OutUpgradeDTO> upgrades = GetChosenUpgradesForUnit(unit.ChosenUpgrades);
                //    unitDto.Upgrades = upgrades;
                //}
                upgrades.Add(upgradeDto);
            }

            return upgrades;
        }
    }
}

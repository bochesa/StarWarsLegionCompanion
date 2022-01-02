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
    public interface IDTOServices
    {
        ICollection<OutUpgradeOptionDTO> CreateListOfOutUpgradeOptionsDTO(ICollection<UpgradeOption> unitUpgradeOptions);
        ICollection<OutKeywordDTO> CreateListOfOutKeywordsDTO(ICollection<Keyword> requestKeywords);
        ICollection<OutWeaponDTO> CreateListOfOutWeaponsDTO(ICollection<Weapon> requestWeapons);
        ICollection<UpgradeOption> PostListOfUpgradeOptions(IEnumerable<InUpgradeOptionDTO> requestUpgradeOptions);
        Task<ICollection<Keyword>> PostListOfKeywords(IEnumerable<InKeywordDTO> requestKeywords);
        Task<ICollection<Weapon>> PostListOfWeapons(IEnumerable<InWeaponDTO> requestWeapons);
    }
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
                    Amount = upgradeOption.Amount,
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
                    Text = keyword.Text
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
                        Amount = upgradeOptionDto.Amount,
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
                        keyword.Text = keywordDto.Text;

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
    }
}

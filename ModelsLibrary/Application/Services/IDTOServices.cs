using System.Collections.Generic;
using System.Threading.Tasks;
using UtilityLibrary.Application.Handlers;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Services
{
    public interface IDTOServices
    {
        ICollection<OutUpgradeOptionDTO> CreateListOfOutUpgradeOptionsDTO(ICollection<UpgradeOption> unitUpgradeOptions);
        ICollection<OutKeywordDTO> CreateListOfOutKeywordsDTO(ICollection<Keyword> requestKeywords);
        ICollection<OutWeaponDTO> CreateListOfOutWeaponsDTO(ICollection<Weapon> requestWeapons);
        OutWeaponDTO CreateOutWeaponsDTO(Weapon weapon);
        ICollection<UpgradeOption> PostListOfUpgradeOptions(IEnumerable<InUpgradeOptionDTO> requestUpgradeOptions);
        Task<ICollection<Keyword>> PostListOfKeywords(IEnumerable<InKeywordDTO> requestKeywords);
        Task<ICollection<Weapon>> PostListOfWeapons(IEnumerable<InWeaponDTO> requestWeapons);
        Task<Weapon> PostWeapon(InWeaponDTO requestWeapon);
        ICollection<OutCommandDTO> GetCommandsForArmy(IEnumerable<ChosenCommand> armyChosenCommands);
        ICollection<OutUpgradeDTO> GetChosenUpgradesForUnit(IEnumerable<ChosenUpgrade> unitChosenUpgrades);
        ICollection<OutUnitDTO> GetChosenUnitsForArmy(IEnumerable<ChosenUnit> armyChosenUnits);
    }
}

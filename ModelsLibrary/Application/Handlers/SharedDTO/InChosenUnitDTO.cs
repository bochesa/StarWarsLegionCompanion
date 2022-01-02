using System.Collections.Generic;

namespace UtilityLibrary.Application.Handlers
{
    public class InChosenUnitDTO
    {
        public int UnitId { get; set; }
        public IEnumerable<InChosenUpgradeDTO> ChosenUpgrades { get; set; }

    }
}

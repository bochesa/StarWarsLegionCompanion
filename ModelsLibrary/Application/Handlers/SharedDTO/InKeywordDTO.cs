using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Application.Handlers
{
    public class InKeywordDTO
    {
        public string Name { get; set; }
        public int? AbilityValue { get; set; }
        public string Text { get; set; }
        public int ActionType { get; set; }
    }
    public class InChosenUnitDTO
    {
        public int UnitId { get; set; }
        public IEnumerable<InChosenUpgradeDTO> ChosenUpgrades { get; set; }

    }
    public class InChosenUpgradeDTO
    {
        public int UpgradeId { get; set; }
    }
}

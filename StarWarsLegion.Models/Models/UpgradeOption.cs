using System.Collections.Generic;

namespace UtilityLibrary.Models
{
    public class UpgradeOption
    {
        public int Id { get; set; }
        public UpgradeType UpgradeType { get; set; }
        public int Amount { get; set; }
        public int UnitId { get; set; }
    }
}

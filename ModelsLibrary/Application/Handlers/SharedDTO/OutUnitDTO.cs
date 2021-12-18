using System.Collections.Generic;

namespace UtilityLibrary.Application.Handlers
{
    public class OutUnitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PointCost { get; set; }
        public string Rank { get; set; }
        public List<OutUpgradeDTO> Upgrades { get; set; }
    }
}

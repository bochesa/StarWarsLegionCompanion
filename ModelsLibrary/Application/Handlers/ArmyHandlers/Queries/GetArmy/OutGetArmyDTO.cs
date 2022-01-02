using System.Collections.Generic;

namespace UtilityLibrary.Application.Handlers
{
    public class OutGetArmyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Player { get; set; }
        public string Faction { get; set; }
        public int PointLimit { get; set; }
        public ICollection<OutCommandDTO> Commands { get; set; } = new List<OutCommandDTO>();
        public ICollection<OutUnitDTO> Units { get; set; } = new List<OutUnitDTO>();
    }
}

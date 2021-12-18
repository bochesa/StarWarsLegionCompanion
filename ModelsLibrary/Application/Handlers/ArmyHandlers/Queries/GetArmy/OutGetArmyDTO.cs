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
        public List<OutCommandDTO> Commands { get; set; }
        public List<OutUnitDTO> Units { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class ChosenUnit
    {
        public int Id { get; set; }
        public int ArmyId { get; set; }
        public int UnitId { get; set; }
    }
    public class ChosenUpgrade
    {
        public int Id { get; set; }
        public int ArmyId { get; set; }
        public int UnitId { get; set; }
    }
}

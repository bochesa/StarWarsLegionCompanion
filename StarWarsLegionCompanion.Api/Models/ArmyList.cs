using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class ArmyList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int FactionId { get; set; }
        public virtual Faction Faction { get; set; }
        public int PointLimit { get; set; }
        public List<Unit> Units { get; set; }

    }
}

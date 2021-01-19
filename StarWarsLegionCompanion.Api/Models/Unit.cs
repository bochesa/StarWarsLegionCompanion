using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsUnique { get; set; }
        public int WoundThreshold { get; set; }
        public int Courage { get; set; }
        public string Faction { get; set; }
        public string Rank { get; set; }
        public string UnitType { get; set; }
        public int Speed { get; set; }
        public int MinisInUnit { get; set; }
        public int PointCost { get; set; }
        public bool IsDefenseRed { get; set; }
        public bool IsDefenseSurge { get; set; }
        public int AttackSurgeId { get; set; }
        public virtual AttackSurge AttackSurge { get; set; }
        public List<Keyword> Keywords { get; set; }

    }
}

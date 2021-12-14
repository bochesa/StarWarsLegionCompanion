using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class InPostNewUnitDTO : IRequest<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsUnique { get; set; }
        public int Faction { get; set; }
        public int Rank { get; set; }
        public int UnitType { get; set; }
        public int WoundThreshold { get; set; }
        public int Courage { get; set; }
        public int Speed { get; set; }
        public int MinisInUnit { get; set; }
        public int PointCost { get; set; }
        public bool IsDefenseRed { get; set; }
        public bool IsDefenseSurge { get; set; }
        public int AttackSurge { get; set; }
        public IEnumerable<InKeywordDTO> Keywords { get; set; }
        public IEnumerable<InWeaponDTO> Weapons { get; set; }
        public IEnumerable<InUpgradeOptionDTO> UpgradeCategories { get; set; }
    }
}

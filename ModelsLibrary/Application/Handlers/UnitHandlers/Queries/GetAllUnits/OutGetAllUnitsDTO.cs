using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class OutGetAllUnitsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsUnique { get; set; }
        //public string Faction { get; set; }
        public string Rank { get; set; }
        //public string UnitType { get; set; }
        //public int WoundThreshold { get; set; }
        //public int Courage { get; set; }
        //public int Speed { get; set; }
        //public int MinisInUnit { get; set; }
        public int PointCost { get; set; }
        public string Image { get; set; }
        //public bool IsDefenseRed { get; set; }
        //public bool IsDefenseSurge { get; set; }
        //public string AttackSurge { get; set; }
        //public List<Keyword> Keywords { get; set; }
        //public List<Weapon> Weapons { get; set; }
        //public List<UpgradeOption> UpgradeOptions { get; set; }
    }
}

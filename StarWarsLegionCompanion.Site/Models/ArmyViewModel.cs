using Microsoft.AspNetCore.Mvc.Rendering;
using StarWarsLegionCompanion.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Site.Models
{
    public class ArmyViewModel
    {
        public Army Army { get; set; }
        public List<ChosenUnit> ChosenUnitList { get; set; }
        public List<List<ChosenUnit>> ChosenUnitsGrouped { get; set; }
        public List<Unit> CurrentUnits { get; set; }
        public List<Unit> AvailableUnits { get; set; }
        public List<List<Unit>> AvailableUnitsGrouped { get; set; }
        public List<List<Unit>> CurrentUnitsGrouped { get; set; }
        public int AccumulatedPointCost { get; set; }
        public List<ChosenUpgrade> ChosenUpgrades { get; set; }
        public List<Upgrade> CurrentUpgrades { get; set; }
        public List<Upgrade> AvailableUpgrades { get; set; }

        public List<SelectListItem> Factions { get; set; } = new List<SelectListItem>();

    }
}

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
        public List<Unit> AvailableUnits { get; set; }
        public ArmyList Armylist { get; set; }
        public List<ArmyList> ArmyLists { get; set; }
        
        public List<SelectListItem> Factions { get; set; } = new List<SelectListItem>();

    }
}

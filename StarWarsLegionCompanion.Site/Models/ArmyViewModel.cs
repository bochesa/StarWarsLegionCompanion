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
        public Army Army { get; set; }
        public List<Army> ArmyList { get; set; }
        
        public List<SelectListItem> Factions { get; set; } = new List<SelectListItem>();

    }
}

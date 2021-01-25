using StarWarsLegionCompanion.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Site.Models
{
    public class UnitViewModel
    {
        public List<Unit> AvailableUnits{ get; set; }
        public List<Unit> CurrentUnits { get; set; }

    }
}

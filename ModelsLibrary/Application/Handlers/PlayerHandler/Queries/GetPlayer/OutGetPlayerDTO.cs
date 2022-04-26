using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class OutGetPlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Måske skal det vær en ArmyDto
        public List<Army> Armies { get; set; }
    }
}

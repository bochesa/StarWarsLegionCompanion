using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace StarWarsLegion.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = null;
        public List<FactionType> Factions { get; set; } = new ();
    }
}

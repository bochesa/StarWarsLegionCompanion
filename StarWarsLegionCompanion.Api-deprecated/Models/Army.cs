using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Army
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerId { get; set; }
        [NotMapped, JsonIgnore]
        public virtual Player Player { get; set; }
        public int FactionId { get; set; }
        [NotMapped]
        public virtual Faction Faction { get; set; }
        public int PointLimit { get; set; }

    }
}

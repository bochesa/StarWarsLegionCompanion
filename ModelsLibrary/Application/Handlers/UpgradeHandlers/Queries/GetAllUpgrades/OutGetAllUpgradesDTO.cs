using Microsoft.EntityFrameworkCore;
using UtilityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Application.Handlers
{
    public class OutGetAllUpgradesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUnique { get; set; }
        public int PointCost { get; set; }
        public List<Restriction> Restrictions { get; set; } = new();
        public string Text { get; set; }
        public int WoundThreshold { get; set; }
        public bool IsExhaustable { get; set; } = false;
        public bool IsFreeAction { get; set; } = false;
        public string Image { get; set; }
    }
}

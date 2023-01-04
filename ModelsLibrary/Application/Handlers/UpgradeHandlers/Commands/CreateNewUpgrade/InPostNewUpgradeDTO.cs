using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class InPostNewUpgradeDTO : IRequest<int>
    {
        public string Name { get; set; }
        public bool IsUnique { get; set; } = false;
        public int PointCost { get; set; }
        public string Text { get; set; }
        public int WoundThreshold { get; set; }
        public bool IsExhaustable { get; set; } = false;
        public bool IsFreeAction { get; set; } = false;
        public int UpgradeType { get; set; }
        public string Reconfigure { get; set; }
        public InWeaponDTO Weapon { get; set; }
        public IEnumerable<InKeywordDTO> Keywords { get; set; }
    }
}

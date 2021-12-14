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
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUnique { get; set; }
        public int PointCost { get; set; }
        public string Text { get; set; }
        public int? WoundThreshold { get; set; } = null;
        public bool IsExhaustable { get; set; }
        public bool IsFreeAction { get; set; }
        public int UpgradeType { get; set; }
        public InWeaponDTO Weapon { get; set; }
        public IEnumerable<InKeywordDTO> Keywords { get; set; }
    }
}

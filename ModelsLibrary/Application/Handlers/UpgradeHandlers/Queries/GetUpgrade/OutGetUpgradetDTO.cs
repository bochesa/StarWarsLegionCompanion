using System.Collections.Generic;

namespace UtilityLibrary.Application.Handlers
{
    public class OutGetUpgradetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUnique { get; set; }
        public int PointCost { get; set; }
        public string Text { get; set; }
        public int? WoundThreshold { get; set; }
        public bool IsExhaustable { get; set; }
        public bool IsFreeAction { get; set; }
        public string UpgradeType { get; set; }
        public OutWeaponDTO? Weapon { get; set; }
        public IEnumerable<OutKeywordDTO>? Keywords { get; set; }
    }
}

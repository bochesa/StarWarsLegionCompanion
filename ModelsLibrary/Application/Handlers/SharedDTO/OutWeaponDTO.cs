using System.Collections.Generic;

namespace UtilityLibrary.Application.Handlers
{
    public class OutWeaponDTO
    {
        public string Name { get; set; }
        public string RangeType { get; set; }
        public int? MinRange { get; set; }
        public int? MaxRange { get; set; }
        public string AttackSurge { get; set; }
        public virtual AttackValueDTO AttackValue { get; set; }
        public virtual IEnumerable<OutKeywordDTO> Keywords { get; set; }
    }
}

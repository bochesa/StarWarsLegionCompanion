using System.Collections.Generic;

namespace UtilityLibrary.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit? Unit { get; set; } = null;
        public int Pips { get; set; }
        public string Text { get; set; }
        public string UnitActivated { get; set; }

    }
}

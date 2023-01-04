using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.Models
{
    public class KeywordModel : Keyword
    {
        public bool IsCardAction { get; set; } = false;
        public bool IsFreeAction { get; set; } = false;
        public bool IsTypeNotNone { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class OutGetAllKeywordsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int KeywordType { get; set; }
        public int AbilityValue { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int ActionType { get; set; }
    }
}

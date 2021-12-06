using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public string FullName
        //{
        //    get
        //    {
        //        if (AbilityValue != null)
        //        {
        //            return $"{Name} {AbilityValue}";
        //        }
        //        else return Name;
        //    }
        //}
        public int? AbilityValue { get; set; }
        public string Text { get; set; }
        public ActionType ActionType { get; set; }
    }
}

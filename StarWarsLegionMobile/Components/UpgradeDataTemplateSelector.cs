using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.Components
{
    public class UpgradeDataTemplateSelector : DataTemplateSelector
    {

        public DataTemplate Normal { get; set; }
        public DataTemplate Special { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var upgrade = (ChosenUnitUpgradeModel)item;

            if (upgrade != null)
            {
                return Special;
            }
            
            return Normal;

        }
    }
}

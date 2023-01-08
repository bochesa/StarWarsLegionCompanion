using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.Messages
{
    public class UpdateArmyBuilderList : ValueChangedMessage<Army>
    {
        public UpdateArmyBuilderList(Army value) : base(value)
        {
        }
    }
    public class UpdateArmyFaction : ValueChangedMessage<string>
    {
        public UpdateArmyFaction(string value) : base(value)
        {
        }
    }
}

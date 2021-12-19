using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilityLibrary.Application.Handlers
{
    public class InRemoveArmyUpgradeDTO : IRequest<int>
    {
        public int ChosenUpgradeId { get; set; }
    }
}

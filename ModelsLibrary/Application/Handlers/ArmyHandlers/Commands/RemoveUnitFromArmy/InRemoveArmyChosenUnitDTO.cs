using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilityLibrary.Application.Handlers
{
    public class InRemoveArmyChosenUnitDTO : IRequest<int>
    {
        //public int ArmyId { get; set; }
        public int ChosenUnitId { get; set; }
    }
}
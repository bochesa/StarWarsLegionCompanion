using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityLibrary.Application.Handlers
{
    public class InPostNewArmyDTO : IRequest<int>
    {
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public int Faction { get; set; }
        public int PointLimit { get; set; }
        public IEnumerable<int> ChosenCommandIds { get; set; }
        public IEnumerable<InChosenUnitDTO> ChosenUnits { get; set; }
    }
}

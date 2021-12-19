using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class InAddArmyChosenUnitDTO : IRequest<int>
    {
        public int ArmyId { get; set; }
        public int UnitId { get; set; }
    }

    public class AddArmyChosenUnitHandler : IRequestHandler<InAddArmyChosenUnitDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public AddArmyChosenUnitHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InAddArmyChosenUnitDTO request, CancellationToken cancellationToken)
        {
            var army = await _uow.Armies.GetArmyByIdWithPopulatedLists(request.ArmyId);

            //var unit = await _uow.Units.Get(request.UnitId);

            army.ChosenUnits.Add(new ChosenUnit { UnitId = request.UnitId });

            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }
    }
}

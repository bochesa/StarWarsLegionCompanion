using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;

namespace UtilityLibrary.Application.Handlers
{
    public class InRemoveArmyCommandDTO : IRequest<int>
    {
        public int ArmyId { get; set; }
        public int CommandId { get; set; }
    }

    public class RemoveArmyCommandHandler : IRequestHandler<InRemoveArmyCommandDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public RemoveArmyCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InRemoveArmyCommandDTO request, CancellationToken cancellationToken)
        {
            //var army = await _uow.Armies.RemoveChosenCommandFromArmy(request.ArmyId, request.CommandId);
            var army = await _uow.Armies.GetArmyByIdWithPopulatedLists(request.ArmyId);
            var CommandToRemove = army.ChosenCommands.Find(c => c.CommandId == request.CommandId);

            army.ChosenCommands.Remove(CommandToRemove);

            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }
    }
}

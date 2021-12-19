using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class AddArmyCommandHandler : IRequestHandler<InAddArmyCommandDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public AddArmyCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<int> Handle(InAddArmyCommandDTO request, CancellationToken cancellationToken)
        {
            var army = await _uow.Armies.GetArmyByIdWithPopulatedLists(request.ArmyId);

            var command = await _uow.Commands.Get(request.CommandId);

            army.ChosenCommands.Add(new ChosenCommand { Command = command });

            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }
    }
}

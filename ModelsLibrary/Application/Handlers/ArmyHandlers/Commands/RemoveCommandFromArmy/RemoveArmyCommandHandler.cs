using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;

namespace UtilityLibrary.Application.Handlers
{
    public class RemoveArmyCommandHandler : IRequestHandler<InRemoveArmyCommandDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public RemoveArmyCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InRemoveArmyCommandDTO request, CancellationToken cancellationToken)
        {
            await _uow.Armies.RemoveCommand(request.ChosenCommandId);

            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }
    }
}

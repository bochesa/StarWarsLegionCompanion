using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;

namespace UtilityLibrary.Application.Handlers
{
    public class RemoveArmyUpgradeHandler : IRequestHandler<InRemoveArmyUpgradeDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public RemoveArmyUpgradeHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InRemoveArmyUpgradeDTO request, CancellationToken cancellationToken)
        {
            await _uow.Armies.RemoveUpgrade(request.ChosenUpgradeId);

            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }
    }
}

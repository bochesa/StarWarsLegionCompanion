using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;

namespace UtilityLibrary.Application.Handlers
{
    public class RemoveArmyChosenUnitHandler : IRequestHandler<InRemoveArmyChosenUnitDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public RemoveArmyChosenUnitHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InRemoveArmyChosenUnitDTO request, CancellationToken cancellationToken)
        {

            await _uow.Armies.RemoveUnit(request.ChosenUnitId);

            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }
    }
}
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class AddArmyChosenUpgradeHandler : IRequestHandler<InAddArmyChosenUpgradeDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public AddArmyChosenUpgradeHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InAddArmyChosenUpgradeDTO request, CancellationToken cancellationToken)
        {
            var chosenUnit = await _uow.Armies.GetChosenUnitById(request.ChosenUnitId);
            
            //chosenUnit.ChosenUpgrades.Add(new ChosenUpgrade { UpgradeId = request.UpgradeId });

            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }


    }
}

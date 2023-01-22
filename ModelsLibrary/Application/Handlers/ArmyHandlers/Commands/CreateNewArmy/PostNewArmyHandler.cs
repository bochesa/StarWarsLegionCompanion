using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class PostNewArmyHandler : IRequestHandler<InPostNewArmyDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public PostNewArmyHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InPostNewArmyDTO request, CancellationToken cancellationToken)
        {

            var army = new Army
            {
                Name = request.Name,
                Player = await _uow.Players.Get(request.PlayerId),
                Faction = (FactionType)request.Faction
            };

            if (request.ChosenCommandIds.Count() != 0)
            {
                foreach (var commandId in request.ChosenCommandIds)
                {
                    var newChosenCommand = new ChosenCommand
                    {
                        Command = await _uow.Commands.Get(commandId),
                    };
                    army.ChosenCommands.Add(newChosenCommand);
                }
            }

            if (request.ChosenUnits.Count() != 0)
            {
                foreach (var requestUnit in request.ChosenUnits)
                {
                    var newChosenUnit = new ChosenUnit
                    {
                        Unit = await _uow.Units.Get(requestUnit.UnitId),
                        //ChosenUpgrades = new List<ChosenUpgrade>()
                    };
                    army.ChosenUnits.Add(newChosenUnit);
                }
            }
            if (request.ChosenUpgrades.Count() != 0)
            {
                foreach (var upgrade in request.ChosenUpgrades)
                {
                    var newUpgrade = new ChosenUpgrade
                    {
                        Upgrade = await _uow.Upgrades.Get(upgrade.UpgradeId)
                    };
                    army.ChosenUpgrades.Add(newUpgrade);
                }
            }

            await _uow.Armies.Add(army);
            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }
    }
}

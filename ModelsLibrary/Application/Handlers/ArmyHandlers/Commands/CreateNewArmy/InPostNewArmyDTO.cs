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
    public class InPostNewArmyDTO : IRequest<int>
    {
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public int Faction { get; set; }
        public int PointLimit { get; set; }
        public IEnumerable<int> ChosenCommands { get; set; }
        public IEnumerable<InChosenUnitDTO> ChosenUnits { get; set; }
    }
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
                PointLimit = request.PointLimit,
                Player = await _uow.Players.Get(request.PlayerId),
                Faction = (FactionType)request.Faction,
                ChosenCommands = new List<ChosenCommand>(),
                ChosenUnits = new List<ChosenUnit>()
            };

            if (request.ChosenCommands.Count() != 0)
            {
                foreach (var commandId in request.ChosenCommands)
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
                        ChosenUpgrades = new List<ChosenUpgrade>()
                    };
                    foreach (var upgrade in requestUnit.ChosenUpgrades)
                    {
                        var newUpgrade = new ChosenUpgrade
                        {
                            Upgrade = await _uow.Upgrades.Get(upgrade.UpgradeId)
                        };
                        newChosenUnit.ChosenUpgrades.Add(newUpgrade);
                    }
                    army.ChosenUnits.Add(newChosenUnit);
                }
            }


            await _uow.Armies.Add(army);
            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;
        }
    }
}

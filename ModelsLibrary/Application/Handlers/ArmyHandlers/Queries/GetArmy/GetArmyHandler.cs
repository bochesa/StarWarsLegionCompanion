using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class GetArmyHandler : IRequestHandler<InGetArmyDTO, OutGetArmyDTO>
    {
        private readonly IUnitOfWork _uow;

        public GetArmyHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OutGetArmyDTO> Handle(InGetArmyDTO request, CancellationToken cancellationToken)
        {
            var army = await _uow.Armies.GetArmyByIdWithPopulatedLists(request.Id);
            OutGetArmyDTO armyDTO = new OutGetArmyDTO
            {
                Id = army.Id,
                Name = army.Name,
                Player = army.Player.Name,
                PointLimit = army.PointLimit,
                Faction = Enum.GetName(typeof(FactionType), army.Faction),
                Commands = new List<OutCommandDTO>(),
                Units = new List<OutUnitDTO>()

            };

            // If there are any commands chosen, they will be looped through and shown as OutCommandDTO
            if (army.ChosenCommands.Count != 0)
            {
                foreach (var command in army.ChosenCommands)
                {
                    var commandDto = new OutCommandDTO();
                    commandDto.Id = command.Command.Id;
                    commandDto.Name = command.Command.Name;
                    armyDTO.Commands.Add(commandDto);
                }
            }

            // If there are any chosen units in the army, they are looped through and shown with their upgrades
            if (army.ChosenUnits.Count != 0)
            {
                foreach (var unit in army.ChosenUnits)
                {
                    var unitDto = new OutUnitDTO
                    {
                        Id = unit.Id,
                        Name = unit.Unit.Name,
                        PointCost = unit.Unit.PointCost,
                        Rank = Enum.GetName(typeof(RankType), unit.Unit.Rank),
                        Upgrades = new List<OutUpgradeDTO>()
                    };
                    foreach (var upgrade in unit.ChosenUpgrades)
                    {
                        var upgradeDto = new OutUpgradeDTO
                        {
                            Id = upgrade.Id,
                            Name = upgrade.Upgrade.Name,
                            PointCost = upgrade.Upgrade.PointCost,
                            UpgradeType = Enum.GetName(typeof(UpgradeType),
                            upgrade.Upgrade.UpgradeType)
                        };
                        unitDto.Upgrades.Add(upgradeDto);
                    }

                    armyDTO.Units.Add(unitDto);
                }
            }

            return armyDTO;

        }
    }
}

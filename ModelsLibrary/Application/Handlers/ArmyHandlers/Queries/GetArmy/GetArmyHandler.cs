using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Application.Services;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class GetArmyHandler : IRequestHandler<InGetArmyDTO, OutGetArmyDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IDTOServices _services;

        public GetArmyHandler(IUnitOfWork uow, IDTOServices services)
        {
            _uow = uow;
            _services = services;
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
            };

            // If there are any commands chosen, they will be looped through and shown as OutCommandDTO
            if (army.ChosenCommands.Count != 0)
            {
                ICollection<OutCommandDTO> commands = _services.GetCommandsForArmy(army.ChosenCommands);
                armyDTO.Commands = commands;
            }

            // If there are any chosen units in the army, they are looped through and shown with their upgrades
            if (army.ChosenUnits.Count != 0)
            {
                ICollection<OutUnitDTO> units = _services.GetChosenUnitsForArmy(army.ChosenUnits);
                armyDTO.Units = units;
            }

            return armyDTO;

        }
    }
}

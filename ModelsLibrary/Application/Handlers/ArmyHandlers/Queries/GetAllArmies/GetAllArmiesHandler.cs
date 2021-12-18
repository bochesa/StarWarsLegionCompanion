using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class GetAllArmiesHandler : IRequestHandler<InGetAllArmiesDTO, List<OutGetAllArmiesDTO>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllArmiesHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<OutGetAllArmiesDTO>> Handle(InGetAllArmiesDTO request, CancellationToken cancellationToken)
        {
            var armyData = await _uow.Armies.GetAll();
            List<OutGetAllArmiesDTO> armyDtos = new();

            foreach (var army in armyData)
            {
                OutGetAllArmiesDTO armyDto = new OutGetAllArmiesDTO
                {
                    Id = army.Id,
                    Name = army.Name,
                    PointLimit = army.PointLimit,
                    Faction = Enum.GetName(typeof(FactionType), army.Faction)
                };
                armyDtos.Add(armyDto);
            }

            return armyDtos;
        }
    }
}

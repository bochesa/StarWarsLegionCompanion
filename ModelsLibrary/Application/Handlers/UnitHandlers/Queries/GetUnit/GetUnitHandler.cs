using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Application.Services;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class GetUnitHandler : IRequestHandler<InGetUnitDTO, OutGetUnitDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IDTOServices _services;

        public GetUnitHandler(IUnitOfWork uow, IDTOServices services)
        {
            _uow = uow;
            _services = services;
        }

        public async Task<OutGetUnitDTO> Handle(InGetUnitDTO request, CancellationToken cancellationToken)
        {
            var unit = await _uow.Units.GetUnitByIdWithPopulatedLists(request.Id);

            OutGetUnitDTO unitDto = new OutGetUnitDTO
            {
                Id = unit.Id,
                AttackSurge = Enum.GetName(typeof(AttackSurge), unit.AttackSurge),
                Courage = unit.Courage,
                Faction = Enum.GetName(typeof(FactionType), unit.Faction),
                IsDefenseRed = unit.IsDefenseRed,
                IsDefenseSurge = unit.IsDefenseSurge,
                IsUnique = unit.IsUnique,
                MinisInUnit = unit.MinisInUnit,
                Name = unit.Name,
                PointCost = unit.PointCost,
                Rank = Enum.GetName(typeof(RankType), unit.Rank),
                Speed = unit.Speed,
                SurName = unit.SurName,
                UnitType = Enum.GetName(typeof(UnitType), unit.UnitType),
                WoundThreshold = unit.WoundThreshold
            };

            var upgradeoptions = _services.CreateListOfOutUpgradeOptionsDTO(unit.UpgradeOptions);
            var weapons = _services.CreateListOfOutWeaponsDTO(unit.Weapons);
            var keywords = _services.CreateListOfOutKeywordsDTO(unit.Keywords);

            unitDto.UpgradeOptions = upgradeoptions;
            unitDto.Weapons = weapons;
            unitDto.Keywords = keywords;

            return unitDto;
        }
    }
}

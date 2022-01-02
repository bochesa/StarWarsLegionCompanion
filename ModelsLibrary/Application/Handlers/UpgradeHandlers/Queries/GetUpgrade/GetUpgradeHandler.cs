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
    public class GetUpgradeHandler : IRequestHandler<InGetUpgradeDTO, OutGetUpgradetDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IDTOServices _services;

        public GetUpgradeHandler(IUnitOfWork uow, IDTOServices services)
        {
            _uow = uow;
            _services = services;
        }

        public async Task<OutGetUpgradetDTO> Handle(InGetUpgradeDTO request, CancellationToken cancellationToken)
        {
            var upgrade = await _uow.Upgrades.GetUpgradeByIdWithPopulatedLists(request.Id);

            OutGetUpgradetDTO upgradetDTO = new OutGetUpgradetDTO
            {
                Id = upgrade.Id,
                IsExhaustable = upgrade.IsExhaustable,
                IsFreeAction = upgrade.IsFreeAction,
                IsUnique = upgrade.IsUnique,
                Keywords = _services.CreateListOfOutKeywordsDTO(upgrade.Keywords),
                Name = upgrade.Name,
                PointCost = upgrade.PointCost,
                Text = upgrade.Text,
                UpgradeType = Enum.GetName(typeof(UpgradeType), upgrade.UpgradeType),
                WoundThreshold = upgrade.WoundThreshold,

            };
            if (upgrade.Weapon is not null)
            {
                upgradetDTO.Weapon = _services.CreateOutWeaponsDTO(upgrade.Weapon);
            }

            return upgradetDTO;
        }
    }
}

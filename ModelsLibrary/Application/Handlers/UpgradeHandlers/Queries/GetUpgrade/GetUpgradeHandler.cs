using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class GetUpgradeHandler : IRequestHandler<InGetUpgradeDTO, OutGetUpgradetDTO>
    {
        private readonly IUnitOfWork _uow;

        public GetUpgradeHandler(IUnitOfWork uow)
        {
            _uow = uow;
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
                Keywords = new List<OutKeywordDTO>(),
                Name = upgrade.Name,
                PointCost = upgrade.PointCost,
                Text = upgrade.Text,
                UpgradeType = Enum.GetName(typeof(UpgradeType), upgrade.UpgradeType),
                WoundThreshold = upgrade.WoundThreshold
            };
            // Add weapon if any
            if (upgrade.Weapon != null)
            {
                OutWeaponDTO weaponDto = new OutWeaponDTO
                {
                    Name = upgrade.Weapon.Name,
                    AttackValue = new AttackValueDTO
                    {
                        BlackDie = upgrade.Weapon.AttackValue.BlackDie,
                        RedDie = upgrade.Weapon.AttackValue.RedDie,
                        WhiteDie = upgrade.Weapon.AttackValue.WhiteDie,
                    },
                    MaxRange = upgrade.Weapon.MaxRange,
                    MinRange = upgrade.Weapon.MinRange,
                    RangeType = Enum.GetName(typeof(RangeType), upgrade.Weapon.RangeType),
                    Keywords = new List<OutKeywordDTO>()
                };
                // populate weapon Keywords
                if (upgrade.Weapon.Keywords.Count > 0)
                {
                    List<OutKeywordDTO> weaponKeywords = new List<OutKeywordDTO>();
                    foreach (var keyword in upgrade.Weapon.Keywords)
                    {
                        OutKeywordDTO keyworddto = new OutKeywordDTO
                        {
                            AbilityValue = keyword.AbilityValue,
                            ActionType = Enum.GetName(typeof(ActionType), keyword.ActionType),
                            Name = keyword.Name,
                            Text = keyword.Text,
                        };
                        weaponKeywords.Add(keyworddto);
                    }
                    weaponDto.Keywords = weaponKeywords;
                }
                upgradetDTO.Weapon = weaponDto;
            }
            // populate upgrade keywords
            if (upgrade.Keywords.Count > 0)
            {
                List<OutKeywordDTO> upgradeKeywords = new List<OutKeywordDTO>();
                foreach (var keyword in upgrade.Keywords)
                {
                    OutKeywordDTO keyworddto = new OutKeywordDTO
                    {
                        AbilityValue = keyword.AbilityValue,
                        ActionType = Enum.GetName(typeof(ActionType), keyword.ActionType),
                        Name = keyword.Name,
                        Text = keyword.Text,
                    };
                    upgradeKeywords.Add(keyworddto);
                }
                upgradetDTO.Keywords = upgradeKeywords;
            }


            return upgradetDTO;
        }
    }
}

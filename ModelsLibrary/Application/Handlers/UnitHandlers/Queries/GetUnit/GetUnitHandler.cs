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
    public class GetUnitHandler : IRequestHandler<InUnitDTO, OutUnitDTO>
    {
        private readonly IUnitOfWork _uow;

        public GetUnitHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OutUnitDTO> Handle(InUnitDTO request, CancellationToken cancellationToken)
        {
            var unit = await _uow.Units.GetUnitByIdWithPopulatedLists(request.Id);

            OutUnitDTO unitDto = new OutUnitDTO
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

            // Loop for converting Upgradeoptions to DTO
            var upgradeoptions = new List<UpgradeOptionDTO>();
            foreach (var item in unit.UpgradeOptions)
            {
                var dto = new UpgradeOptionDTO
                {
                    Amount = item.Amount,
                    Name = Enum.GetName(typeof(UpgradeType), item.UpgradeType)

                };
                upgradeoptions.Add(dto);
            }

            // Loop for converting Weapons including its keywords to DTO
            var weapons = new List<WeaponDTO>();
            foreach (var item in unit.Weapons)
            {
                var dto = new WeaponDTO
                {
                    //AttackValue = item.AttackValue,
                    MaxRange = item.MaxRange,
                    MinRange = item.MinRange,
                    Name = item.Name,
                    RangeType = Enum.GetName(typeof(RangeType), item.RangeType),
                };
                var attackDto = new AttackValueDTO
                {
                    BlackDie = item.AttackValue.BlackDie,
                    RedDie = item.AttackValue.RedDie,
                    WhiteDie = item.AttackValue.WhiteDie
                };
                dto.AttackValue = attackDto;
                var weaponsKeywords = new List<KeywordDTO>();
                foreach (var keyword in item.Keywords)
                {
                    var keywordDto = new KeywordDTO
                    {
                        AbilityValue = keyword.AbilityValue,
                        ActionType = Enum.GetName(typeof(ActionType), keyword.ActionType),
                        Name = keyword.Name,
                        Text = keyword.Text
                    };
                    weaponsKeywords.Add(keywordDto);
                }
                dto.Keywords = weaponsKeywords;
                weapons.Add(dto);
            }

            // Loop for converting The units Keywords to DTO
            var keywords = new List<KeywordDTO>();
            foreach (var keyword in unit.Keywords)
            {
                var keywordDto = new KeywordDTO
                {
                    AbilityValue = keyword.AbilityValue,
                    ActionType = Enum.GetName(typeof(ActionType), keyword.ActionType),
                    Name = keyword.Name,
                    Text = keyword.Text
                };
                keywords.Add(keywordDto);
            }


            unitDto.UpgradeOptions = upgradeoptions;
            unitDto.Weapons = weapons;
            unitDto.Keywords = keywords;

            return unitDto;
        }
    }
}

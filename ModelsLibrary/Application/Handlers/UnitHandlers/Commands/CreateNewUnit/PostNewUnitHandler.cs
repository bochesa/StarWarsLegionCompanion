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
    public class PostNewUnitHandler : IRequestHandler<InPostNewUnitDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public PostNewUnitHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InPostNewUnitDTO request, CancellationToken cancellationToken)
        {
            Models.Unit unit = new Models.Unit
            {
                Name = request.Name,
                SurName = request.SurName,
                IsUnique = request.IsUnique,
                Faction = (FactionType)request.Faction,
                Rank = (RankType)request.Rank,
                UnitType = (UnitType)request.UnitType,
                WoundThreshold = request.WoundThreshold,
                Courage = request.Courage,
                Speed = request.Speed,
                MinisInUnit = request.MinisInUnit,
                PointCost = request.PointCost,
                IsDefenseRed = request.IsDefenseRed,
                IsDefenseSurge = request.IsDefenseSurge,
                AttackSurge = (AttackSurge)request.AttackSurge,

            };

            //Loop through all keywords and add each one, or add the reference for an existing weapon
            foreach (var item in request.Weapons)
            {
                bool weaponExists = await _uow.Weapons.WeaponExist(item.Name);

                // if weaponExists is true build the weapon - This might be deprecated in the future, it might be better to add keywords on its own
                if (!weaponExists)
                {
                    var weapon = new Weapon();
                    weapon.Name = item.Name;
                    weapon.RangeType = (RangeType)item.RangeType;
                    weapon.MaxRange = item.MaxRange;
                    weapon.MinRange = item.MinRange;
                    weapon.AttackValue = new AttackValue
                    {
                        BlackDie = item.AttackValue.BlackDie,
                        RedDie = item.AttackValue.RedDie,
                        WhiteDie = item.AttackValue.WhiteDie
                    };
                    unit.Weapons.Add(weapon);
                    await _uow.Weapons.Add(weapon);

                }
                else
                {
                    Weapon weapon = await _uow.Weapons.GetWeaponByName(item.Name);
                    unit.Weapons.Add(weapon);
                }


            }

            //Loop through all Keywords and add each one, or add the reference for an existing weapon
            foreach (var item in request.Keywords)
            {
                bool keywordExists = await _uow.Keywords.KeywordExist(item.Name);

                // if weaponExists is true build the weapon - This might be deprecated in the future, it might be better to add keywords on its own
                if (!keywordExists)
                {
                    var keyword = new Keyword();
                    keyword.Name = item.Name;
                    keyword.AbilityValue = item.AbilityValue;
                    keyword.ActionType = (ActionType)item.ActionType;
                    keyword.Text = item.Text;

                    unit.Keywords.Add(keyword);
                    await _uow.Keywords.Add(keyword);
                }
                else
                {
                    Keyword keyword = await _uow.Keywords.GetKeywordByName(item.Name);
                    unit.Keywords.Add(keyword);
                }


            }

            foreach (var item in request.UpgradeCategories)
            {
                var upgradeOption = new UpgradeOption
                {
                    Amount = item.Amount,
                    UpgradeType = (UpgradeType)item.UpgradeType
                };

                unit.UpgradeOptions.Add(upgradeOption);
            }

            await _uow.Units.Add(unit);
            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;

        }
    }
}

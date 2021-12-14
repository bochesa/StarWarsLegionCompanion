﻿using MediatR;
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
    public class PostNewUpgradeHandler : IRequestHandler<InPostNewUpgradeDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public PostNewUpgradeHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InPostNewUpgradeDTO request, CancellationToken cancellationToken)
        {
            Upgrade upgrade = new Upgrade
            {
                IsExhaustable = request.IsExhaustable,
                IsFreeAction = request.IsFreeAction,
                IsUnique = request.IsUnique,
                Name = request.Name,
                PointCost = request.PointCost,
                Text = request.Text,
                UpgradeType = (UpgradeType)request.UpgradeType,
                WoundThreshold = request.WoundThreshold,
                Keywords = new List<Keyword>()
            };

            Weapon weapon = new Weapon
            {
                MaxRange = request.Weapon.MaxRange,
                MinRange = request.Weapon.MinRange,
                Name = request.Weapon.Name,
                RangeType = (RangeType)request.Weapon.RangeType,
                AttackValue = new AttackValue
                {
                    BlackDie = request.Weapon.AttackValue.BlackDie,
                    RedDie = request.Weapon.AttackValue.RedDie,
                    WhiteDie = request.Weapon.AttackValue.WhiteDie
                },
                Keywords = new List<Keyword>()
            };

            upgrade.Weapon = weapon;
            await _uow.Weapons.Add(weapon);
            // loop through Keywords and convert KeywordDTO to keyword if there are any
            if (request.Weapon.Keywords.Count() != 0)
            {
                foreach (var item in request.Weapon.Keywords)
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

                        weapon.Keywords.Add(keyword);
                        await _uow.Keywords.Add(keyword);
                    }
                    else
                    {
                        Keyword keyword = await _uow.Keywords.GetKeywordByName(item.Name);
                        weapon.Keywords.Add(keyword);
                    }
                }
            }
            await _uow.Upgrades.Add(upgrade);

            int changes = await _uow.Complete();
            return changes;
        }
    }
}
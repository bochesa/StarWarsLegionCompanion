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
    public class PostNewUpgradeHandler : IRequestHandler<InPostNewUpgradeDTO, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IDTOServices _services;

        public PostNewUpgradeHandler(IUnitOfWork uow, IDTOServices services)
        {
            _uow = uow;
            _services = services;
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
                WoundThreshold = request.WoundThreshold
            };

            if (request.Reconfigure != null)
            {
                // insert logic from _services, for handling the reference for the flipped card
            }

            if (request.Weapon is not null)
            {
                upgrade.Weapon = await _services.PostWeapon(request.Weapon);
            }

            if (request.Keywords is not null)
            {
                upgrade.Keywords = await _services.PostListOfKeywords(request.Keywords);
            }


            await _uow.Upgrades.Add(upgrade);

            int changes = await _uow.Complete();
            return changes;
        }
    }
}

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
    public class PostNewUnitHandler : IRequestHandler<InPostNewUnitDTO, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IDTOServices _services;

        public PostNewUnitHandler(IUnitOfWork uow, IDTOServices services)
        {
            _uow = uow;
            _services = services;
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
                Image = request.Image,
                Weapons = await _services.PostListOfWeapons(request.Weapons),
                Keywords = await _services.PostListOfKeywords(request.Keywords),
                UpgradeOptions = _services.PostListOfUpgradeOptions(request.UpgradeCategories),

            };

            await _uow.Units.Add(unit);
            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;

        }
    }
}

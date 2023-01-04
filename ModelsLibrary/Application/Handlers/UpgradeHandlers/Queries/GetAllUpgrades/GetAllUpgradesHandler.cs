using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;

namespace UtilityLibrary.Application.Handlers
{
    public class GetAllUpgradesHandler : IRequestHandler<InGetAllUpgradesDTO, List<OutGetAllUpgradesDTO>>
    {

        private readonly IUnitOfWork _uow;

        public GetAllUpgradesHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<List<OutGetAllUpgradesDTO>> Handle(InGetAllUpgradesDTO request, CancellationToken cancellationToken)
        {
            var upgrades = await _uow.Upgrades.GetAll();
            var upgradesDto = new List<OutGetAllUpgradesDTO>();

            foreach (var item in upgrades)
            {
                OutGetAllUpgradesDTO unitDto = new OutGetAllUpgradesDTO
                {
                    Name = item.Name,
                    Id = item.Id,
                    Image = item.Image,
                    IsExhaustable= item.IsExhaustable,  
                    IsFreeAction= item.IsFreeAction,
                    IsUnique= item.IsUnique,
                    PointCost= item.PointCost,
                    Restriction= item.Restriction,
                    Text= item.Text,
                    WoundThreshold = item.WoundThreshold
                };
                upgradesDto.Add(unitDto);
            }

            return upgradesDto;
        }
    }
}

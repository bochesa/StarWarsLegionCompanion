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
    public class GetAllUnitsHandler : IRequestHandler<InGetAllUnitsDTO, List<OutGetAllUnitsDTO>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllUnitsHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<OutGetAllUnitsDTO>> Handle(InGetAllUnitsDTO request, CancellationToken cancellationToken)
        {
            var units = await _uow.Units.GetAll();
            List<OutGetAllUnitsDTO> unitDtos = new();

            foreach (var item in units)
            {
                OutGetAllUnitsDTO unitDto = new OutGetAllUnitsDTO
                {
                    Name = item.Name,
                    Id = item.Id,
                    PointCost = item.PointCost,
                    IsUnique = item.IsUnique,
                    SurName = item.SurName,
                    Rank = Enum.GetName(typeof(RankType), item.Rank),
                    Image= item.Image
                };
                unitDtos.Add(unitDto);
            }

            return unitDtos;
        }
    }
}

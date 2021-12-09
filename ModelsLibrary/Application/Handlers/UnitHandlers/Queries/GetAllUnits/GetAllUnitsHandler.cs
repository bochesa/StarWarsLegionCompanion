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
            //CaseStatus = Enum.GetName(typeof(CaseStatus), item.CaseStatus),
            foreach (var item in units)
            {
                OutGetAllUnitsDTO unitDto = new OutGetAllUnitsDTO
                {
                    Name = item.Name,
                };
                unitDtos.Add(unitDto);
            }

            return unitDtos;
        }
    }
}

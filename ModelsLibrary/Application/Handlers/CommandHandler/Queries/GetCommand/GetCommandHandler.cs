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
    public class GetCommandHandler : IRequestHandler<InGetCommandDTO, OutGetCommandDTO>
    {
        private readonly IUnitOfWork _uow;

        public GetCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OutGetCommandDTO> Handle(InGetCommandDTO request, CancellationToken cancellationToken)
        {
            var data = await _uow.Commands.GetCommandByIdWithUnit(request.Id);
            OutGetCommandDTO commandDto = new OutGetCommandDTO
            {
                Id = data.Id,
                Name = data.Name,
                Pips = data.Pips,
                Text = data.Text,
                UnitActivated = data.UnitActivated,
                UnitName = data.Unit.Name
            };
            return commandDto;
        }
    }
}

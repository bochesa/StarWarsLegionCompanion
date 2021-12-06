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
    public class GetUnitHandler : IRequestHandler<OutUnitDTO, Models.Unit>
    {
        private readonly IUnitOfWork _uow;

        public GetUnitHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Models.Unit> Handle(OutUnitDTO request, CancellationToken cancellationToken)
        {
            return await _uow.Units.Get(request.Id);
        }
    }
}

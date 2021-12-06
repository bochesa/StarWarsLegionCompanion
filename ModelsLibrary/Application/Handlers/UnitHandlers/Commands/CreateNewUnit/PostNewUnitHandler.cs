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
            };
            await _uow.Units.Add(unit);
            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;

        }
    }
}

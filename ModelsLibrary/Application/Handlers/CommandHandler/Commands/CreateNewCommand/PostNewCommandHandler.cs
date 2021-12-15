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
    public class PostNewCommandHandler : IRequestHandler<InPostNewCommand, int>
    {
        private readonly IUnitOfWork _uow;

        public PostNewCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InPostNewCommand request, CancellationToken cancellationToken)
        {
            Command command = new Command
            {
                Name = request.Name,
                Pips = request.Pips,
                UnitActivated = request.UnitActivated,
                Text = request.Text,
                Unit = await _uow.Units.Get(request.UnitId)
            };

            await _uow.Commands.Add(command);
            int changes = await _uow.Complete();
            _uow.Dispose();
            return changes;

        }
    }
}

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
    public class InRemoveArmyCommandDTO : IRequest<int>
    {
        public int ArmyId { get; set; }
        public int CommandId { get; set; }
    }

    public class RemoveArmyCommandHandler : IRequestHandler<InRemoveArmyCommandDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public RemoveArmyCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<int> Handle(InRemoveArmyCommandDTO request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

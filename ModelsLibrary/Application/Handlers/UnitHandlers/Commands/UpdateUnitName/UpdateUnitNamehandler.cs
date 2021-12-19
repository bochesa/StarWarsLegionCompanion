using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;

namespace UtilityLibrary.Application.Handlers
{
    public class UpdateUnitNamehandler : IRequestHandler<InUpdateUnitNameDTO, int>
    {
        private readonly IUnitOfWork _uow;

        public UpdateUnitNamehandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(InUpdateUnitNameDTO request, CancellationToken cancellationToken)
        {
            var unit = await _uow.Units.Get(request.Id);

            var unitUpdates = new JsonPatchDocument<Models.Unit>();

            unitUpdates.Replace(o => o.Name, request.Value);

            unitUpdates.ApplyTo(unit);

            int changes;
            changes = await _uow.Complete();

            return changes;


        }
    }
}

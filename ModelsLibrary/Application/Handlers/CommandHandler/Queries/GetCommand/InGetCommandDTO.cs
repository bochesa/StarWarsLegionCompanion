using MediatR;

namespace UtilityLibrary.Application.Handlers
{
    public class InGetCommandDTO : IRequest<OutGetCommandDTO>
    {
        public int Id { get; set; }
    }
}

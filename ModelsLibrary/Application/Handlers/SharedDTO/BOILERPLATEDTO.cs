using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UtilityLibrary.Application.Handlers
{
    public class InGet_DTO : IRequest<OutGet_DTO>
    {
        public int Id { get; set; }
    }
    public class OutGet_DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Get_Handler : IRequestHandler<InGet_DTO, OutGet_DTO>
    {
        public Task<OutGet_DTO> Handle(InGet_DTO request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

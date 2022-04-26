using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Application.Handlers
{
    public class InGetPlayerDTO : IRequest<OutGetPlayerDTO>
    {
        public int Id { get; set; }
    }
}

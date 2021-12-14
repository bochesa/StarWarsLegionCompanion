using MediatR;
using System.Collections.Generic;

namespace UtilityLibrary.Application.Handlers
{
    public class InGetAllCommandsDTO : IRequest<List<OutGetAllCommandsDTO>>
    {
    }
}

﻿using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilityLibrary.Application.Handlers
{
    public class InGetAllArmiesDTO : IRequest<List<OutGetAllArmiesDTO>>
    {
    }
}

﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Application.Handlers
{
    public class InGetUnitDTO : IRequest<OutGetUnitDTO>
    {
        public int Id { get; set; }
    }
}
